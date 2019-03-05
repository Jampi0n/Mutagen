﻿using Loqui;
using Loqui.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Generation
{
    public class FolderExportModule : GenerationModule
    {
        public override async Task<IEnumerable<string>> RequiredUsingStatements(ObjectGeneration obj)
        {
            if (obj.GetObjectType() != ObjectType.Mod) return Enumerable.Empty<string>();
            return new string[]
            {
                "System.Threading.Tasks",
                "Noggog.Utility"
            };
        }

        public override async Task GenerateInClass(ObjectGeneration obj, FileGeneration fg)
        {
            await base.GenerateInClass(obj, fg);
            switch (obj.GetObjectType())
            {
                case ObjectType.Record:
                    await GenerateForRecord(obj, fg);
                    break;
                case ObjectType.Mod:
                    GenerateForMod(obj, fg);
                    break;
                case ObjectType.Subrecord:
                case ObjectType.Group:
                default:
                    break;
            }
        }

        private void GenerateForMod(ObjectGeneration obj, FileGeneration fg)
        {
            using (var args = new FunctionWrapper(fg,
                $"public static async Task<({obj.Name} Mod, {obj.Mask(MaskType.Error)} ErrorMask)> Create_Xml_Folder"))
            {
                args.Add("DirectoryPath dir");
                args.Add("ModKey modKey");
                args.Add("bool doMasks = true");
            }
            using (new BraceWrapper(fg))
            {
                fg.AppendLine($"ErrorMaskBuilder errorMaskBuilder = null;");
                fg.AppendLine($"var ret = new {obj.Name}(modKey);");
                foreach (var field in obj.IterateFields())
                {
                    if (!(field is LoquiType loqui))
                    {
                        throw new ArgumentException();
                    }
                    switch (loqui.TargetObjectGeneration.GetObjectType())
                    {
                        case ObjectType.Record:
                            using (var args = new ArgsWrapper(fg,
                                $"ret.{field.Name}.CopyFieldsFrom({loqui.TypeName}.Create_Xml",
                                suffixLine: ");")
                            {
                                SemiColon = false
                            })
                            {
                                args.Add($"path: Path.Combine(dir.Path, \"{field.Name}.xml\")");
                                args.Add($"errorMask: errorMaskBuilder");
                                args.Add($"translationMask: null");
                            }
                            break;
                        case ObjectType.Group:
                            if (!loqui.TryGetSpecificationAsObject("T", out var subObj)) continue;
                            using (var args = new ArgsWrapper(fg,
                                $"await ret.{field.Name}.Create_Xml_Folder<{subObj.Name}>"))
                            {
                                args.Add($"dir: dir");
                                args.Add($"name: nameof({field.Name})");
                                args.Add($"errorMask: errorMaskBuilder");
                                args.Add($"index: (int){field.IndexEnumName}");
                            }
                            break;
                        default:
                            break;
                    }
                }
                BinaryTranslationModule.GenerateModLinking(obj, fg);
                fg.AppendLine("return (ret, null);");
            }

            using (var args = new FunctionWrapper(fg,
                $"public async Task<{obj.Mask(MaskType.Error)}> Write_XmlFolder"))
            {
                args.Add("DirectoryPath dir");
                args.Add("bool doMasks = true");
            }
            using (new BraceWrapper(fg))
            {
                fg.AppendLine($"ErrorMaskBuilder errorMaskBuilder = null;");
                fg.AppendLine("dir.Create();");
                foreach (var field in obj.IterateFields())
                {
                    if (!(field is LoquiType loqui))
                    {
                        throw new ArgumentException();
                    }
                    switch (loqui.TargetObjectGeneration.GetObjectType())
                    {
                        case ObjectType.Record:
                            using (var args = new ArgsWrapper(fg,
                                $"this.{field.Name}.Write_Xml"))
                            {
                                args.Add($"path: Path.Combine(dir.Path, \"{field.Name}.xml\")");
                                args.Add($"errorMask: errorMaskBuilder");
                                args.Add($"translationMask: null");
                            }
                            break;
                        case ObjectType.Group:
                            ObjectGeneration subObj;
                            if (field is GroupType group)
                            {
                                if (!group.TryGetSpecificationAsObject("T", out subObj)) continue;
                                using (var args = new ArgsWrapper(fg,
                                    $"await {field.Name}.Write_Xml_Folder<{subObj.Name}, {subObj.Mask(MaskType.Error)}>"))
                                {
                                    args.Add($"dir: dir.Path");
                                    args.Add($"name: nameof({field.Name})");
                                    args.Add($"errorMask: errorMaskBuilder");
                                    args.Add($"index: (int){field.IndexEnumName}");
                                }
                            }
                            else
                            {
                                using (var args = new ArgsWrapper(fg,
                                    $"await {field.Name}.Write_Xml_Folder"))
                                {
                                    args.Add($"dir: dir.Path");
                                    args.Add($"name: nameof({field.Name})");
                                    args.Add($"errorMask: errorMaskBuilder");
                                    args.Add($"index: (int){field.IndexEnumName}");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                fg.AppendLine("return null;");
            }
        }

        private async Task GenerateForRecord(ObjectGeneration obj, FileGeneration fg)
        {
            if (!obj.IsTopClass) return;

            using (var args = new FunctionWrapper(fg,
                $"public{await obj.FunctionOverride()}void Write_Xml_Folder"))
            {
                args.Add("DirectoryPath? dir");
                args.Add("string name");
                args.Add("XElement node");
                args.Add("int counter");
                args.Add($"ErrorMaskBuilder errorMask");
            }
            using (new BraceWrapper(fg))
            {
                using (var args = new ArgsWrapper(fg,
                    "Write_Xml"))
                {
                    args.Add("node: node");
                    args.Add("errorMask: errorMask");
                    args.Add("translationMask: null");
                }
            }
        }
    }
}
