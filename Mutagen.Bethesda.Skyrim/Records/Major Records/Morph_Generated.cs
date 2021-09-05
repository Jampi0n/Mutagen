/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.Internals;
using Mutagen.Bethesda.Skyrim.Internals;
using Mutagen.Bethesda.Translations.Binary;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Skyrim
{
    #region Class
    public partial class Morph :
        IEquatable<IMorphGetter>,
        ILoquiObjectSetter<Morph>,
        IMorph
    {
        #region Ctor
        public Morph()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Data
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private MemorySlice<Byte> _Data = new byte[32];
        public MemorySlice<Byte> Data
        {
            get => _Data;
            set => this._Data = value;
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ReadOnlyMemorySlice<Byte> IMorphGetter.Data => this.Data;
        #endregion

        #region To String

        public void ToString(
            FileGeneration fg,
            string? name = null)
        {
            MorphMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IMorphGetter rhs) return false;
            return ((MorphCommon)((IMorphGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IMorphGetter? obj)
        {
            return ((MorphCommon)((IMorphGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((MorphCommon)((IMorphGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public class Mask<TItem> :
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem Data)
            {
                this.Data = Data;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Data;
            #endregion

            #region Equals
            public override bool Equals(object? obj)
            {
                if (!(obj is Mask<TItem> rhs)) return false;
                return Equals(rhs);
            }

            public bool Equals(Mask<TItem>? rhs)
            {
                if (rhs == null) return false;
                if (!object.Equals(this.Data, rhs.Data)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Data);
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public bool All(Func<TItem, bool> eval)
            {
                if (!eval(this.Data)) return false;
                return true;
            }
            #endregion

            #region Any
            public bool Any(Func<TItem, bool> eval)
            {
                if (eval(this.Data)) return true;
                return false;
            }
            #endregion

            #region Translate
            public Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new Morph.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                obj.Data = eval(this.Data);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(Morph.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, Morph.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(Morph.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (printMask?.Data ?? true)
                    {
                        fg.AppendItem(Data, "Data");
                    }
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public class ErrorMask :
            IErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Overall { get; set; }
            private List<string>? _warnings;
            public List<string> Warnings
            {
                get
                {
                    if (_warnings == null)
                    {
                        _warnings = new List<string>();
                    }
                    return _warnings;
                }
            }
            public Exception? Data;
            #endregion

            #region IErrorMask
            public object? GetNthMask(int index)
            {
                Morph_FieldIndex enu = (Morph_FieldIndex)index;
                switch (enu)
                {
                    case Morph_FieldIndex.Data:
                        return Data;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthException(int index, Exception ex)
            {
                Morph_FieldIndex enu = (Morph_FieldIndex)index;
                switch (enu)
                {
                    case Morph_FieldIndex.Data:
                        this.Data = ex;
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthMask(int index, object obj)
            {
                Morph_FieldIndex enu = (Morph_FieldIndex)index;
                switch (enu)
                {
                    case Morph_FieldIndex.Data:
                        this.Data = (Exception?)obj;
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public bool IsInError()
            {
                if (Overall != null) return true;
                if (Data != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString()
            {
                var fg = new FileGeneration();
                ToString(fg, null);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, string? name = null)
            {
                fg.AppendLine($"{(name ?? "ErrorMask")} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (this.Overall != null)
                    {
                        fg.AppendLine("Overall =>");
                        fg.AppendLine("[");
                        using (new DepthWrapper(fg))
                        {
                            fg.AppendLine($"{this.Overall}");
                        }
                        fg.AppendLine("]");
                    }
                    ToString_FillInternal(fg);
                }
                fg.AppendLine("]");
            }
            protected void ToString_FillInternal(FileGeneration fg)
            {
                fg.AppendItem(Data, "Data");
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Data = this.Data.Combine(rhs.Data);
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public class TranslationMask : ITranslationMask
        {
            #region Members
            private TranslationCrystal? _crystal;
            public readonly bool DefaultOn;
            public bool OnOverall;
            public bool Data;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
            {
                this.DefaultOn = defaultOn;
                this.OnOverall = onOverall;
                this.Data = defaultOn;
            }

            #endregion

            public TranslationCrystal GetCrystal()
            {
                if (_crystal != null) return _crystal;
                var ret = new List<(bool On, TranslationCrystal? SubCrystal)>();
                GetCrystal(ret);
                _crystal = new TranslationCrystal(ret.ToArray());
                return _crystal;
            }

            protected void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                ret.Add((Data, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => MorphBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((MorphBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #region Binary Create
        public static Morph CreateFromBinary(
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            var ret = new Morph();
            ((MorphSetterCommon)((IMorphGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                translationParams: translationParams);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out Morph item,
            TypedParseParams? translationParams = null)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(
                frame: frame,
                translationParams: translationParams);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        void IClearable.Clear()
        {
            ((MorphSetterCommon)((IMorphGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static Morph GetNew()
        {
            return new Morph();
        }

    }
    #endregion

    #region Interface
    public partial interface IMorph :
        ILoquiObjectSetter<IMorph>,
        IMorphGetter
    {
        new MemorySlice<Byte> Data { get; set; }
    }

    public partial interface IMorphGetter :
        ILoquiObject,
        IBinaryItem,
        ILoquiObject<IMorphGetter>
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object? CommonSetterInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonSetterTranslationInstance();
        static ILoquiRegistration Registration => Morph_Registration.Instance;
        ReadOnlyMemorySlice<Byte> Data { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class MorphMixIn
    {
        public static void Clear(this IMorph item)
        {
            ((MorphSetterCommon)((IMorphGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static Morph.Mask<bool> GetEqualsMask(
            this IMorphGetter item,
            IMorphGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((MorphCommon)((IMorphGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this IMorphGetter item,
            string? name = null,
            Morph.Mask<bool>? printMask = null)
        {
            return ((MorphCommon)((IMorphGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this IMorphGetter item,
            FileGeneration fg,
            string? name = null,
            Morph.Mask<bool>? printMask = null)
        {
            ((MorphCommon)((IMorphGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IMorphGetter item,
            IMorphGetter rhs,
            Morph.TranslationMask? equalsMask = null)
        {
            return ((MorphCommon)((IMorphGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IMorph lhs,
            IMorphGetter rhs)
        {
            ((MorphSetterTranslationCommon)((IMorphGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: default,
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IMorph lhs,
            IMorphGetter rhs,
            Morph.TranslationMask? copyMask = null)
        {
            ((MorphSetterTranslationCommon)((IMorphGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this IMorph lhs,
            IMorphGetter rhs,
            out Morph.ErrorMask errorMask,
            Morph.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((MorphSetterTranslationCommon)((IMorphGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = Morph.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IMorph lhs,
            IMorphGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((MorphSetterTranslationCommon)((IMorphGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static Morph DeepCopy(
            this IMorphGetter item,
            Morph.TranslationMask? copyMask = null)
        {
            return ((MorphSetterTranslationCommon)((IMorphGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static Morph DeepCopy(
            this IMorphGetter item,
            out Morph.ErrorMask errorMask,
            Morph.TranslationMask? copyMask = null)
        {
            return ((MorphSetterTranslationCommon)((IMorphGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static Morph DeepCopy(
            this IMorphGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((MorphSetterTranslationCommon)((IMorphGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IMorph item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            ((MorphSetterCommon)((IMorphGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                translationParams: translationParams);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim.Internals
{
    #region Field Index
    public enum Morph_FieldIndex
    {
        Data = 0,
    }
    #endregion

    #region Registration
    public partial class Morph_Registration : ILoquiRegistration
    {
        public static readonly Morph_Registration Instance = new Morph_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Skyrim.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Skyrim.ProtocolKey,
            msgID: 84,
            version: 0);

        public const string GUID = "db314c60-7ba5-4df9-8229-527af27db99a";

        public const ushort AdditionalFieldCount = 1;

        public const ushort FieldCount = 1;

        public static readonly Type MaskType = typeof(Morph.Mask<>);

        public static readonly Type ErrorMaskType = typeof(Morph.ErrorMask);

        public static readonly Type ClassType = typeof(Morph);

        public static readonly Type GetterType = typeof(IMorphGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IMorph);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Skyrim.Morph";

        public const string Name = "Morph";

        public const string Namespace = "Mutagen.Bethesda.Skyrim";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(MorphBinaryWriteTranslation);
        #region Interface
        ProtocolKey ILoquiRegistration.ProtocolKey => ProtocolKey;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        ushort ILoquiRegistration.FieldCount => FieldCount;
        ushort ILoquiRegistration.AdditionalFieldCount => AdditionalFieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        Type ILoquiRegistration.SetterType => SetterType;
        Type? ILoquiRegistration.InternalSetterType => InternalSetterType;
        Type ILoquiRegistration.GetterType => GetterType;
        Type? ILoquiRegistration.InternalGetterType => InternalGetterType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        string ILoquiRegistration.Namespace => Namespace;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type? ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => throw new NotImplementedException();
        string ILoquiRegistration.GetNthName(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsNthDerivative(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsProtected(ushort index) => throw new NotImplementedException();
        Type ILoquiRegistration.GetNthType(ushort index) => throw new NotImplementedException();
        #endregion

    }
    #endregion

    #region Common
    public partial class MorphSetterCommon
    {
        public static readonly MorphSetterCommon Instance = new MorphSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IMorph item)
        {
            ClearPartial();
            item.Data = new byte[32];
        }
        
        #region Mutagen
        public void RemapLinks(IMorph obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IMorph item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            PluginUtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                translationParams: translationParams,
                fillStructs: MorphBinaryCreateTranslation.FillBinaryStructs);
        }
        
        #endregion
        
    }
    public partial class MorphCommon
    {
        public static readonly MorphCommon Instance = new MorphCommon();

        public Morph.Mask<bool> GetEqualsMask(
            IMorphGetter item,
            IMorphGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new Morph.Mask<bool>(false);
            ((MorphCommon)((IMorphGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IMorphGetter item,
            IMorphGetter rhs,
            Morph.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.Data = MemoryExtensions.SequenceEqual(item.Data.Span, rhs.Data.Span);
        }
        
        public string ToString(
            IMorphGetter item,
            string? name = null,
            Morph.Mask<bool>? printMask = null)
        {
            var fg = new FileGeneration();
            ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
            return fg.ToString();
        }
        
        public void ToString(
            IMorphGetter item,
            FileGeneration fg,
            string? name = null,
            Morph.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"Morph =>");
            }
            else
            {
                fg.AppendLine($"{name} (Morph) =>");
            }
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                ToStringFields(
                    item: item,
                    fg: fg,
                    printMask: printMask);
            }
            fg.AppendLine("]");
        }
        
        protected static void ToStringFields(
            IMorphGetter item,
            FileGeneration fg,
            Morph.Mask<bool>? printMask = null)
        {
            if (printMask?.Data ?? true)
            {
                fg.AppendLine($"Data => {SpanExt.ToHexString(item.Data)}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IMorphGetter? lhs,
            IMorphGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            if ((crystal?.GetShouldTranslate((int)Morph_FieldIndex.Data) ?? true))
            {
                if (!MemoryExtensions.SequenceEqual(lhs.Data.Span, rhs.Data.Span)) return false;
            }
            return true;
        }
        
        public virtual int GetHashCode(IMorphGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.Data);
            return hash.ToHashCode();
        }
        
        #endregion
        
        
        public object GetNew()
        {
            return Morph.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> GetContainedFormLinks(IMorphGetter obj)
        {
            yield break;
        }
        
        #endregion
        
    }
    public partial class MorphSetterTranslationCommon
    {
        public static readonly MorphSetterTranslationCommon Instance = new MorphSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IMorph item,
            IMorphGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            if ((copyMask?.GetShouldTranslate((int)Morph_FieldIndex.Data) ?? true))
            {
                item.Data = rhs.Data.ToArray();
            }
        }
        
        #endregion
        
        public Morph DeepCopy(
            IMorphGetter item,
            Morph.TranslationMask? copyMask = null)
        {
            Morph ret = (Morph)((MorphCommon)((IMorphGetter)item).CommonInstance()!).GetNew();
            ((MorphSetterTranslationCommon)((IMorphGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public Morph DeepCopy(
            IMorphGetter item,
            out Morph.ErrorMask errorMask,
            Morph.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            Morph ret = (Morph)((MorphCommon)((IMorphGetter)item).CommonInstance()!).GetNew();
            ((MorphSetterTranslationCommon)((IMorphGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = Morph.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public Morph DeepCopy(
            IMorphGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            Morph ret = (Morph)((MorphCommon)((IMorphGetter)item).CommonInstance()!).GetNew();
            ((MorphSetterTranslationCommon)((IMorphGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: true);
            return ret;
        }
        
    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim
{
    public partial class Morph
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => Morph_Registration.Instance;
        public static Morph_Registration Registration => Morph_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => MorphCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterInstance()
        {
            return MorphSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => MorphSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IMorphGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object IMorphGetter.CommonSetterInstance() => this.CommonSetterInstance();
        [DebuggerStepThrough]
        object IMorphGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class MorphBinaryWriteTranslation : IBinaryWriteTranslator
    {
        public readonly static MorphBinaryWriteTranslation Instance = new MorphBinaryWriteTranslation();

        public static void WriteEmbedded(
            IMorphGetter item,
            MutagenWriter writer)
        {
            ByteArrayBinaryTranslation<MutagenFrame, MutagenWriter>.Instance.Write(
                writer: writer,
                item: item.Data);
        }

        public void Write(
            MutagenWriter writer,
            IMorphGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            WriteEmbedded(
                item: item,
                writer: writer);
        }

        public void Write(
            MutagenWriter writer,
            object item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (IMorphGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class MorphBinaryCreateTranslation
    {
        public readonly static MorphBinaryCreateTranslation Instance = new MorphBinaryCreateTranslation();

        public static void FillBinaryStructs(
            IMorph item,
            MutagenFrame frame)
        {
            item.Data = ByteArrayBinaryTranslation<MutagenFrame, MutagenWriter>.Instance.Parse(reader: frame.SpawnWithLength(32));
        }

    }

}
namespace Mutagen.Bethesda.Skyrim
{
    #region Binary Write Mixins
    public static class MorphBinaryTranslationMixIn
    {
        public static void WriteToBinary(
            this IMorphGetter item,
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((MorphBinaryWriteTranslation)item.BinaryWriteTranslator).Write(
                item: item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }
    #endregion


}
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class MorphBinaryOverlay :
        PluginBinaryOverlay,
        IMorphGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => Morph_Registration.Instance;
        public static Morph_Registration Registration => Morph_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => MorphCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => MorphSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object IMorphGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object? IMorphGetter.CommonSetterInstance() => null;
        [DebuggerStepThrough]
        object IMorphGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => MorphBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((MorphBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public ReadOnlyMemorySlice<Byte> Data => _data.Span.Slice(0x0, 0x20).ToArray();
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected MorphBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static MorphBinaryOverlay MorphFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new MorphBinaryOverlay(
                bytes: stream.RemainingMemory.Slice(0, 0x20),
                package: package);
            int offset = stream.Position;
            stream.Position += 0x20;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static MorphBinaryOverlay MorphFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            return MorphFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                recordTypeConverter: recordTypeConverter);
        }

        #region To String

        public void ToString(
            FileGeneration fg,
            string? name = null)
        {
            MorphMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IMorphGetter rhs) return false;
            return ((MorphCommon)((IMorphGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IMorphGetter? obj)
        {
            return ((MorphCommon)((IMorphGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((MorphCommon)((IMorphGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

