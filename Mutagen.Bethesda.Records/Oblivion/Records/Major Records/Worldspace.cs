using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Mutagen.Bethesda.Oblivion.Internals;
using Noggog;
using Noggog.Utility;

namespace Mutagen.Bethesda.Oblivion
{
    public partial class Worldspace
    {
        [Flags]
        public enum Flag
        {
            SmallWorld = 0x01,
            CantFastTravel = 0x02,
            OblivionWorldspace = 0x04,
            NoLODWater = 0x10,
        }

        private static readonly Worldspace_TranslationMask XmlFolderTranslation = new Worldspace_TranslationMask(true)
        {
            SubCells = new MaskItem<bool, WorldspaceBlock_TranslationMask>(false, null),
            Road = new MaskItem<bool, Road_TranslationMask>(false, null),
            TopCell = new MaskItem<bool, Cell_TranslationMask>(false, null),
        };
        private static readonly TranslationCrystal XmlFolderTranslationCrystal = XmlFolderTranslation.GetCrystal();

        private static readonly WorldspaceBlock_TranslationMask BlockXmlFolderTranslation = new WorldspaceBlock_TranslationMask(true)
        {
            Items = new MaskItem<bool, WorldspaceSubBlock_TranslationMask>(false, null),
            BlockNumberX = false,
            BlockNumberY = false,
        };
        private static readonly TranslationCrystal BlockXmlFolderTranslationCrystal = BlockXmlFolderTranslation.GetCrystal();

        private static readonly WorldspaceSubBlock_TranslationMask SubBlockXmlFolderTranslation = new WorldspaceSubBlock_TranslationMask(true)
        {
            BlockNumberX = false,
            BlockNumberY = false,
        };
        private static readonly TranslationCrystal SubBlockXmlFolderTranslationCrystal = SubBlockXmlFolderTranslation.GetCrystal();

        public static async Task<TryGet<Worldspace>> TryCreateXmFolder(
            DirectoryPath dir,
            ErrorMaskBuilder errorMask)
        {
            var path = Path.Combine(dir.Path, $"{nameof(Worldspace)}.xml");
            if (!File.Exists(path))
            {
                return TryGet<Worldspace>.Failure;
            }
            var worldspaceNode = XDocument.Load(path).Root;
            var ret = CreateFromXml(
                node: worldspaceNode,
                errorMask: errorMask,
                translationMask: XmlFolderTranslationCrystal);
            var usingOffsetLenNode = worldspaceNode.Element("UsingOffsetLength");
            if (usingOffsetLenNode != null && usingOffsetLenNode.TryGetAttribute("value", out bool val))
            {
                ret.UsingOffsetLength = val;
            }
            var roadPath = Path.Combine(dir.Path, $"{nameof(Road)}.xml");
            if (File.Exists(roadPath))
            {
                ret.Road = Road.CreateFromXml(
                    roadPath,
                    translationMask: null,
                    errorMask: errorMask);
            }
            var topCellpath = Path.Combine(dir.Path, $"{nameof(TopCell)}.xml");
            if (File.Exists(topCellpath))
            {
                ret.TopCell = Cell.CreateFromXml(
                    topCellpath,
                    translationMask: null,
                    errorMask: errorMask);
            }
            var subCellsDir = new DirectoryPath(Path.Combine(dir.Path, $"SubCells"));
            if (!subCellsDir.Exists) return TryGet<Worldspace>.Succeed(ret);

            bool TryGetIndices(string str, out short x, out short y)
            {
                var split = str.Split(',');
                x = -1;
                y = -1;
                if (split.Length != 2) return false;
                int prefixIndex = split[0].IndexOf(" - (");
                if (prefixIndex == -1) return false;
                if (!split[1].EndsWith(")")) return false;
                split[0] = split[0].Substring(prefixIndex + 4).Trim();
                split[1] = split[1].Substring(0, split[1].Length - 1).Trim();
                if (split[0].Length < 2 || split[1].Length < 2) return false;
                if (!split[0].EndsWith("X")) return false;
                if (!split[1].EndsWith("Y")) return false;
                return short.TryParse(split[0].Substring(0, split[0].Length - 1), out x)
                    && short.TryParse(split[1].Substring(0, split[1].Length - 1), out y);
            }

            List<Task<WorldspaceBlock>> tasks = new List<Task<WorldspaceBlock>>();
            foreach (var blockDir in subCellsDir.EnumerateDirectories(includeSelf: false, recursive: false)
                .SelectWhere(d =>
                {
                    if (Mutagen.Bethesda.FolderTranslation.TryGetItemIndex(d.Name, out var index))
                    {
                        return TryGet<(int Index, DirectoryPath Dir)>.Succeed((index, d));
                    }
                    return TryGet<(int Index, DirectoryPath Dir)>.Failure;
                })
                .OrderBy(d => d.Index)
                .Select(d => d.Dir))
            {
                if (!TryGetIndices(blockDir.Name, out var blockX, out var blockY)) continue;
                tasks.Add(Task.Run(async () =>
                {
                    WorldspaceBlock wb = WorldspaceBlock.CreateFromXml(
                        path: Path.Combine(blockDir.Path, "Group.xml"),
                        errorMask: errorMask,
                        translationMask: BlockXmlFolderTranslation);
                    wb.BlockNumberX = blockX;
                    wb.BlockNumberY = blockY;

                    List<Task<WorldspaceSubBlock>> subTasks = new List<Task<WorldspaceSubBlock>>();
                    foreach (var subBlockFile in blockDir.EnumerateFiles()
                        .SelectWhere(d =>
                        {
                            if (Mutagen.Bethesda.FolderTranslation.TryGetItemIndex(d.Name, out var index))
                            {
                                return TryGet<(int Index, FilePath File)>.Succeed((index, d));
                            }
                            return TryGet<(int Index, FilePath File)>.Failure;
                        })
                        .OrderBy(d => d.Index)
                        .Select(d => d.File))
                    {
                        if (!TryGetIndices(subBlockFile.NameWithoutExtension, out var subBlockX, out var subBlockY)) continue;
                        subTasks.Add(Task.Run(() =>
                        {
                            WorldspaceSubBlock wsb = WorldspaceSubBlock.CreateFromXml(
                                path: subBlockFile.Path,
                                errorMask: errorMask,
                                translationMask: SubBlockXmlFolderTranslation);
                            wsb.BlockNumberX = subBlockX;
                            wsb.BlockNumberY = subBlockY;
                            return wsb;
                        }));
                    }
                    var subBlocks = await Task.WhenAll(subTasks).ConfigureAwait(false);
                    wb.Items.AddRange(subBlocks);
                    return wb;
                }));
            }
            var blocks = await Task.WhenAll(tasks).ConfigureAwait(false);
            ret.SubCells.AddRange(blocks);
            return TryGet<Worldspace>.Succeed(ret);
        }

        public override async Task WriteToXmlFolder(
            DirectoryPath? dir, 
            string name, 
            XElement node, 
            int counter,
            ErrorMaskBuilder errorMask)
        {
            dir = new DirectoryPath(Path.Combine(dir.Value.Path, FolderTranslation.GetFileString(this, counter)));
            dir.Value.Create();

            var worldspaceNode = new XElement("topnode");
            this.WriteToXml(
                name: name,
                node: worldspaceNode,
                errorMask: errorMask,
                translationMask: XmlFolderTranslationCrystal);
            worldspaceNode.Elements().First().SaveIfChanged(Path.Combine(dir.Value.Path, $"{nameof(Worldspace)}.xml"));
            if (this.Road_IsSet
                && this.Road != null)
            {
                this.Road.WriteToXml(
                    path: Path.Combine(dir.Value.Path, $"{nameof(Road)}.xml"),
                    errorMask: errorMask,
                    translationMask: null);
            }
            if (this.TopCell_IsSet
                && this.TopCell != null)
            {
                this.TopCell.WriteToXml(
                    path: Path.Combine(dir.Value.Path, $"{nameof(TopCell)}.xml"),
                    errorMask: errorMask,
                    translationMask: null);
            }
            int blockCount = 0;
            List<Task> blockTasks = new List<Task>();
            foreach (var block in this.SubCells)
            {
                int blockStamp = blockCount++;
                blockTasks.Add(Task.Run(async () =>
                {
                    List<Task> subBlockTasks = new List<Task>();
                    var blockDir = new DirectoryPath(Path.Combine(dir.Value.Path, $"SubCells/{blockStamp} - ({block.BlockNumberX}X, {block.BlockNumberY}Y)/"));
                    blockDir.Create();
                    int subBlockCount = 0;
                    block.WriteToXml(
                        Path.Combine(blockDir.Path, "Group.xml"),
                        errorMask: errorMask,
                        translationMask: BlockXmlFolderTranslationCrystal);
                    foreach (var subBlock in block.Items)
                    {
                        int subBlockStamp = subBlockCount++;
                        subBlockTasks.Add(Task.Run(() =>
                        {
                            subBlock.WriteToXml(
                                path: Path.Combine(blockDir.Path, $"{subBlockStamp} - ({subBlock.BlockNumberX}X, {subBlock.BlockNumberY}Y).xml"),
                                translationMask: SubBlockXmlFolderTranslationCrystal,
                                errorMask: errorMask);
                        }));
                    }
                    await Task.WhenAll(subBlockTasks).ConfigureAwait(false);
                }));
            }
            await Task.WhenAll(blockTasks).ConfigureAwait(false);
        }
    }

    namespace Internals
    {
        public partial class WorldspaceCommon
        {
            private static WorldspaceBlock_CopyMask duplicateBlockCopyMask = new WorldspaceBlock_CopyMask(true)
            {
                Items = new MaskItem<CopyOption, WorldspaceSubBlock_CopyMask>(CopyOption.Skip, null)
            };

            private static WorldspaceSubBlock_CopyMask duplicateSubBlockCopyMask = new WorldspaceSubBlock_CopyMask(true)
            {
                Items = new MaskItem<CopyOption, Cell_CopyMask>(CopyOption.Skip, null)
            };

            partial void PostDuplicate(Worldspace obj, Worldspace rhs, Func<FormKey> getNextFormKey, IList<(IMajorRecordCommon Record, FormKey OriginalFormKey)> duplicatedRecords)
            {
                if (rhs.Road_IsSet
                    && rhs.Road != null)
                {
                    obj.Road = (Road)rhs.Road.Duplicate(getNextFormKey, duplicatedRecords);
                }
                if (rhs.TopCell_IsSet
                    && rhs.TopCell != null)
                {
                    obj.TopCell = (Cell)rhs.TopCell.Duplicate(getNextFormKey, duplicatedRecords);
                }
                obj.SubCells.SetTo(rhs.SubCells.Items.Select((block) =>
                {
                    var blockRet = new WorldspaceBlock();
                    blockRet.CopyFieldsFrom(block, duplicateBlockCopyMask);
                    blockRet.Items.SetTo(block.Items.Select((subBlock) =>
                    {
                        var subBlockRet = new WorldspaceSubBlock();
                        subBlockRet.CopyFieldsFrom(subBlock, duplicateSubBlockCopyMask);
                        subBlockRet.Items.SetTo(subBlock.Items.Select(c => (Cell)c.Duplicate(getNextFormKey, duplicatedRecords)));
                        return subBlockRet;
                    }));
                    return blockRet;
                }));
            }
        }

        public partial class WorldspaceBinaryWriteTranslation
        {
            static partial void WriteBinaryOffsetLengthCustom(MutagenWriter writer, IWorldspaceInternalGetter item, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                if (!item.OffsetData_IsSet) return;
                if (!item.UsingOffsetLength) return;
                using (HeaderExport.ExportSubRecordHeader(writer, Worldspace_Registration.XXXX_HEADER))
                {
                    writer.Write(item.OffsetData.Length);
                }
                writer.Write(Worldspace_Registration.OFST_HEADER.Type);
                writer.WriteZeros(2);
                writer.Write(item.OffsetData);
            }

            static partial void WriteBinaryOffsetDataCustom(MutagenWriter writer, IWorldspaceInternalGetter item, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                if (item.UsingOffsetLength) return;
                if (!item.OffsetData_IsSet) return;
                using (HeaderExport.ExportSubRecordHeader(writer, Worldspace_Registration.OFST_HEADER))
                {
                    ByteArrayBinaryTranslation.Instance.Write(writer, item.OffsetData);
                }
            }

            static partial void CustomBinaryEndExport(MutagenWriter writer, IWorldspaceInternalGetter obj, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                if (obj.SubCells.Count == 0
                    && !obj.Road_IsSet
                    && !obj.TopCell_IsSet) return;
                using (HeaderExport.ExportHeader(writer, Group_Registration.GRUP_HEADER, ObjectType.Group))
                {
                    FormKeyBinaryTranslation.Instance.Write(
                        writer,
                        obj.FormKey,
                        masterReferences);
                    writer.Write((int)GroupTypeEnum.WorldChildren);
                    writer.Write(obj.SubCellsTimestamp);

                    if (obj.Road_IsSet)
                    {
                        obj.Road.WriteToBinary(
                            writer,
                            masterReferences: masterReferences,
                            errorMask: errorMask);
                    }
                    if (obj.TopCell_IsSet)
                    {
                        obj.TopCell.WriteToBinary(
                            writer,
                            masterReferences: masterReferences,
                            errorMask: errorMask);
                    }
                    Mutagen.Bethesda.Binary.ListBinaryTranslation<IWorldspaceBlockInternalGetter>.Instance.Write(
                        writer: writer,
                        items: obj.SubCells,
                        fieldIndex: (int)Worldspace_FieldIndex.SubCells,
                        errorMask: errorMask,
                        transl: (MutagenWriter subWriter, IWorldspaceBlockInternalGetter subItem, ErrorMaskBuilder listSubMask) =>
                        {
                            subItem.WriteToBinary(
                                writer: subWriter,
                                masterReferences: masterReferences,
                                errorMask: listSubMask);
                        });
                }
            }
        }

        public partial class WorldspaceBinaryCreateTranslation
        {
            static partial void FillBinaryOffsetLengthCustom(MutagenFrame frame, Worldspace item, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                item.UsingOffsetLength = true;
                var xxxxMeta = frame.MetaData.ReadSubRecord(frame);
                if (xxxxMeta.RecordType != Worldspace_Registration.XXXX_HEADER
                    || xxxxMeta.RecordLength != 4)
                {
                    errorMask.ReportExceptionOrThrow(new ArgumentException());
                    return;
                }
                var contentLen = frame.Reader.ReadInt32();
                var ofstMeta = frame.MetaData.ReadSubRecord(frame);
                if (ofstMeta.RecordType != Worldspace_Registration.OFST_HEADER
                    || ofstMeta.RecordLength != 0)
                {
                    errorMask.ReportExceptionOrThrow(new ArgumentException());
                    return;
                }
                item.OffsetData = frame.Reader.ReadBytes(contentLen);
            }

            static partial void FillBinaryOffsetDataCustom(MutagenFrame frame, Worldspace item, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                if (item.UsingOffsetLength) return;
                if (!HeaderTranslation.ReadNextSubRecordType(frame.Reader, out var len).Equals(Worldspace_Registration.OFST_HEADER))
                {
                    throw new ArgumentException();
                }
                item.OffsetData = frame.Reader.ReadBytes(len);
            }

            public static async Task CustomBinaryEndImport(MutagenFrame frame, Worldspace obj, MasterReferences masterReferences, ErrorMaskBuilder errorMask)
            {
                if (frame.Reader.Complete) return;
                var next = HeaderTranslation.GetNextType(
                    reader: frame.Reader,
                    contentLength: out var len,
                    finalPos: out var _,
                    hopGroup: false);
                if (!next.Equals(Group_Registration.GRUP_HEADER)) return;
                frame.Reader.Position += 8;
                var formKey = FormKey.Factory(masterReferences, frame.Reader.ReadUInt32());
                var grupType = (GroupTypeEnum)frame.Reader.ReadInt32();
                if (grupType == GroupTypeEnum.WorldChildren)
                {
                    obj.SubCellsTimestamp = frame.Reader.ReadBytes(4);
                    if (formKey != obj.FormKey)
                    {
                        errorMask.ReportExceptionOrThrow(
                            new ArgumentException("Cell children group did not match the FormID of the parent worldspace."));
                        return;
                    }
                }
                else
                {
                    frame.Reader.Position -= 16;
                    return;
                }
                var subFrame = MutagenFrame.ByLength(frame.Reader, len - 20);
                for (int i = 0; i < 3; i++)
                {
                    if (subFrame.Complete) return;
                    var subType = HeaderTranslation.GetNextSubRecordType(frame.Reader, out var subLen);
                    switch (subType.TypeInt)
                    {
                        case 0x44414F52: // "ROAD":
                            if (LoquiBinaryTranslation<Road>.Instance.Parse(
                                frame: subFrame,
                                item: out var road,
                                fieldIndex: (int)Worldspace_FieldIndex.Road,
                                masterReferences: masterReferences,
                                errorMask: errorMask))
                            {
                                obj.Road = road;
                            }
                            else
                            {
                                obj.Road_Unset();
                            }
                            break;
                        case 0x4C4C4543: // "CELL":
                            var topCell = await LoquiBinaryAsyncTranslation<Cell>.Instance.Parse(
                                frame: subFrame,
                                fieldIndex: (int)Worldspace_FieldIndex.TopCell,
                                masterReferences: masterReferences,
                                errorMask: errorMask).ConfigureAwait(false);
                            if (topCell.Succeeded)
                            {
                                obj.TopCell = topCell.Value;
                            }
                            else
                            {
                                obj.TopCell_Unset();
                            }
                            break;
                        case 0x50555247: // "GRUP":
                            await Mutagen.Bethesda.Binary.ListAsyncBinaryTranslation<WorldspaceBlock>.Instance.ParseRepeatedItem(
                                frame: frame,
                                item: obj.SubCells,
                                triggeringRecord: Worldspace_Registration.GRUP_HEADER,
                                fieldIndex: (int)Worldspace_FieldIndex.SubCells,
                                lengthLength: frame.MetaData.MajorConstants.LengthLength,
                                errorMask: errorMask,
                                transl: (MutagenFrame r, ErrorMaskBuilder subErrorMask) =>
                                {
                                    return LoquiBinaryAsyncTranslation<WorldspaceBlock>.Instance.Parse(
                                        frame: r,
                                        masterReferences: masterReferences,
                                        errorMask: errorMask);
                                }).ConfigureAwait(false);
                            break;
                        default:
                            return;
                    }
                }
            }
        }

        public partial class WorldspaceBinaryWrapper
        {
            private ReadOnlyMemorySlice<byte>? _grupData;

            private int? _RoadLocation;
            public bool Road_IsSet => this._RoadLocation.HasValue;
            public IRoadInternalGetter Road => RoadBinaryWrapper.RoadFactory(new BinaryMemoryReadStream(_grupData.Value.Slice(_RoadLocation.Value)), _package);

            private int? _TopCellLocation;
            public bool TopCell_IsSet => this._TopCellLocation.HasValue;
            public ICellInternalGetter TopCell => CellBinaryWrapper.CellFactory(new BinaryMemoryReadStream(_grupData.Value.Slice(_TopCellLocation.Value)), _package);

            public ReadOnlySpan<byte> SubCellsTimestamp => _grupData != null ? _package.Meta.Group(_grupData.Value).LastModifiedSpan : UtilityTranslation.Zeros.Slice(0, 4);

            public IReadOnlySetList<IWorldspaceBlockInternalGetter> SubCells { get; private set; } = EmptySetList<IWorldspaceBlockInternalGetter>.Instance;

            private int? _OffsetLengthLocation;
            public bool UsingOffsetLength => this._OffsetLengthLocation.HasValue;

            private int? _OffsetDataLocation;
            bool GetOffsetDataIsSetCustom() => this._OffsetDataLocation.HasValue;

            partial void OffsetDataCustomParse(BinaryMemoryReadStream stream, long finalPos, int offset)
            {
                _OffsetDataLocation = (ushort)(stream.Position - offset);
                if (this.UsingOffsetLength)
                {
                    var offsetLenFrame = _package.Meta.SubRecordFrame(_data.Slice(_OffsetLengthLocation.Value));
                    stream.Position += checked((int)(_package.Meta.SubConstants.HeaderLength + BinaryPrimitives.ReadUInt32LittleEndian(offsetLenFrame.ContentSpan)));
                }
            }

            ReadOnlySpan<byte> GetOffsetDataCustom()
            {
                if (this.UsingOffsetLength)
                {
                    var lenFrame = this._package.Meta.SubRecordFrame(_data.Slice(_OffsetLengthLocation.Value));
                    var len = BinaryPrimitives.ReadInt32LittleEndian(lenFrame.ContentSpan);
                    return _data.Slice(_OffsetDataLocation.Value + this._package.Meta.SubConstants.HeaderLength, len);
                }
                else
                {
                    var spanFrame = this._package.Meta.SubRecordFrame(this._data.Slice(_OffsetDataLocation.Value));
                    return spanFrame.ContentSpan;
                }
            }

            partial void OffsetLengthCustomParse(BinaryMemoryReadStream stream, int offset)
            {
                this._OffsetLengthLocation = stream.Position - offset;
            }

            partial void CustomEnd(BinaryMemoryReadStream stream, long finalPos, int offset)
            {
                if (stream.Complete) return;
                var groupMeta = this._package.Meta.GetGroup(stream);
                if (!groupMeta.IsGroup || groupMeta.GroupType != (int)GroupTypeEnum.WorldChildren) return;

                if (this.FormKey != FormKey.Factory(_package.MasterReferences, BinaryPrimitives.ReadUInt32LittleEndian(groupMeta.ContainedRecordTypeSpan)))
                {
                    throw new ArgumentException("Cell children group did not match the FormID of the parent cell.");
                }

                this._grupData = stream.ReadMemory(checked((int)groupMeta.TotalLength));
                stream = new BinaryMemoryReadStream(this._grupData.Value);
                stream.Position += groupMeta.HeaderLength;

                for (int i = 0; i < 3; i++)
                {
                    if (stream.Complete) return;
                    var varMeta = _package.Meta.GetNextRecordVariableMeta(stream);
                    switch (varMeta.RecordTypeInt)
                    {
                        case 0x44414F52: // "ROAD":
                            this._RoadLocation = stream.Position;
                            stream.Position += checked((int)varMeta.TotalLength);
                            break;
                        case 0x4C4C4543: // "CELL":
                            this._TopCellLocation = stream.Position;
                            stream.Position += checked((int)varMeta.TotalLength);
                            if (!stream.Complete)
                            {
                                var subCellGroup = this._package.Meta.GetGroup(stream);
                                if (subCellGroup.IsGroup && subCellGroup.GroupType == (int)GroupTypeEnum.CellChildren)
                                {
                                    stream.Position += checked((int)subCellGroup.TotalLength);
                                }
                            }
                            break;
                        case 0x50555247: // "GRUP":
                            this.SubCells = BinaryWrapperSetList<IWorldspaceBlockInternalGetter>.FactoryByArray(
                                stream.RemainingMemory,
                                _package,
                                getter: (s, p) => WorldspaceBlockBinaryWrapper.WorldspaceBlockFactory(new BinaryMemoryReadStream(s), p),
                                locs: ParseRecordLocations(
                                    stream: new BinaryMemoryReadStream(stream.RemainingMemory),
                                    finalPos: stream.Length,
                                    trigger: WorldspaceBlock_Registration.TRIGGERING_RECORD_TYPE,
                                    constants: MetaDataConstants.Oblivion.GroupConstants,
                                    skipHeader: false));
                            break;
                        default:
                            i = 3; // Break out
                            break;
                    }
                }
            }
        }
    }
}