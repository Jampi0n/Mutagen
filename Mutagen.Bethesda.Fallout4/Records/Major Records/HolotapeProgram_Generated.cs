/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Interfaces;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda.Fallout4.Internals;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Overlay;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Mutagen.Bethesda.Plugins.Binary.Translations;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Internals;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.Internals;
using Mutagen.Bethesda.Plugins.Records.Mapping;
using Mutagen.Bethesda.Translations.Binary;
using Noggog;
using RecordTypeInts = Mutagen.Bethesda.Fallout4.Internals.RecordTypeInts;
using RecordTypes = Mutagen.Bethesda.Fallout4.Internals.RecordTypes;
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
namespace Mutagen.Bethesda.Fallout4
{
    #region Class
    public partial class HolotapeProgram :
        AHolotapeData,
        IEquatable<IHolotapeProgramGetter>,
        IHolotapeProgram,
        ILoquiObjectSetter<HolotapeProgram>
    {
        #region Ctor
        public HolotapeProgram()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region File
        public String File { get; set; } = string.Empty;
        #endregion

        #region To String

        public override void ToString(
            StructuredStringBuilder sb,
            string? name = null)
        {
            HolotapeProgramMixIn.ToString(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IHolotapeProgramGetter rhs) return false;
            return ((HolotapeProgramCommon)((IHolotapeProgramGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IHolotapeProgramGetter? obj)
        {
            return ((HolotapeProgramCommon)((IHolotapeProgramGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((HolotapeProgramCommon)((IHolotapeProgramGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            AHolotapeData.Mask<TItem>,
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem File)
            : base()
            {
                this.File = File;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem File;
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
                if (!base.Equals(rhs)) return false;
                if (!object.Equals(this.File, rhs.File)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.File);
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                if (!eval(this.File)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                if (eval(this.File)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new HolotapeProgram.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
                obj.File = eval(this.File);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(HolotapeProgram.Mask<bool>? printMask = null)
            {
                var sb = new StructuredStringBuilder();
                ToString(sb, printMask);
                return sb.ToString();
            }

            public void ToString(StructuredStringBuilder sb, HolotapeProgram.Mask<bool>? printMask = null)
            {
                sb.AppendLine($"{nameof(HolotapeProgram.Mask<TItem>)} =>");
                sb.AppendLine("[");
                using (sb.IncreaseDepth())
                {
                    if (printMask?.File ?? true)
                    {
                        sb.AppendItem(File, "File");
                    }
                }
                sb.AppendLine("]");
            }
            #endregion

        }

        public new class ErrorMask :
            AHolotapeData.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? File;
            #endregion

            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                HolotapeProgram_FieldIndex enu = (HolotapeProgram_FieldIndex)index;
                switch (enu)
                {
                    case HolotapeProgram_FieldIndex.File:
                        return File;
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                HolotapeProgram_FieldIndex enu = (HolotapeProgram_FieldIndex)index;
                switch (enu)
                {
                    case HolotapeProgram_FieldIndex.File:
                        this.File = ex;
                        break;
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                HolotapeProgram_FieldIndex enu = (HolotapeProgram_FieldIndex)index;
                switch (enu)
                {
                    case HolotapeProgram_FieldIndex.File:
                        this.File = (Exception?)obj;
                        break;
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                if (File != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString()
            {
                var sb = new StructuredStringBuilder();
                ToString(sb, null);
                return sb.ToString();
            }

            public override void ToString(StructuredStringBuilder sb, string? name = null)
            {
                sb.AppendLine($"{(name ?? "ErrorMask")} =>");
                sb.AppendLine("[");
                using (sb.IncreaseDepth())
                {
                    if (this.Overall != null)
                    {
                        sb.AppendLine("Overall =>");
                        sb.AppendLine("[");
                        using (sb.IncreaseDepth())
                        {
                            sb.AppendLine($"{this.Overall}");
                        }
                        sb.AppendLine("]");
                    }
                    ToString_FillInternal(sb);
                }
                sb.AppendLine("]");
            }
            protected override void ToString_FillInternal(StructuredStringBuilder sb)
            {
                base.ToString_FillInternal(sb);
                {
                    sb.AppendItem(File, "File");
                }
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.File = this.File.Combine(rhs.File);
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static new ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public new class TranslationMask :
            AHolotapeData.TranslationMask,
            ITranslationMask
        {
            #region Members
            public bool File;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
                this.File = defaultOn;
            }

            #endregion

            protected override void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                base.GetCrystal(ret);
                ret.Add((File, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => HolotapeProgramBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams? translationParams = null)
        {
            ((HolotapeProgramBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }
        #region Binary Create
        public new static HolotapeProgram CreateFromBinary(
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            var ret = new HolotapeProgram();
            ((HolotapeProgramSetterCommon)((IHolotapeProgramGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                translationParams: translationParams);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out HolotapeProgram item,
            TypedParseParams? translationParams = null)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(
                frame: frame,
                translationParams: translationParams);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.ToString(StructuredStringBuilder sb, string? name) => this.ToString(sb, name);

        void IClearable.Clear()
        {
            ((HolotapeProgramSetterCommon)((IHolotapeProgramGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new HolotapeProgram GetNew()
        {
            return new HolotapeProgram();
        }

    }
    #endregion

    #region Interface
    public partial interface IHolotapeProgram :
        IAHolotapeData,
        IHolotapeProgramGetter,
        ILoquiObjectSetter<IHolotapeProgram>
    {
        new String File { get; set; }
    }

    public partial interface IHolotapeProgramGetter :
        IAHolotapeDataGetter,
        IBinaryItem,
        ILoquiObject<IHolotapeProgramGetter>
    {
        static new ILoquiRegistration StaticRegistration => HolotapeProgram_Registration.Instance;
        String File { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class HolotapeProgramMixIn
    {
        public static void Clear(this IHolotapeProgram item)
        {
            ((HolotapeProgramSetterCommon)((IHolotapeProgramGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static HolotapeProgram.Mask<bool> GetEqualsMask(
            this IHolotapeProgramGetter item,
            IHolotapeProgramGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((HolotapeProgramCommon)((IHolotapeProgramGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this IHolotapeProgramGetter item,
            string? name = null,
            HolotapeProgram.Mask<bool>? printMask = null)
        {
            return ((HolotapeProgramCommon)((IHolotapeProgramGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this IHolotapeProgramGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            HolotapeProgram.Mask<bool>? printMask = null)
        {
            ((HolotapeProgramCommon)((IHolotapeProgramGetter)item).CommonInstance()!).ToString(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IHolotapeProgramGetter item,
            IHolotapeProgramGetter rhs,
            HolotapeProgram.TranslationMask? equalsMask = null)
        {
            return ((HolotapeProgramCommon)((IHolotapeProgramGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IHolotapeProgram lhs,
            IHolotapeProgramGetter rhs,
            out HolotapeProgram.ErrorMask errorMask,
            HolotapeProgram.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((HolotapeProgramSetterTranslationCommon)((IHolotapeProgramGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = HolotapeProgram.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IHolotapeProgram lhs,
            IHolotapeProgramGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((HolotapeProgramSetterTranslationCommon)((IHolotapeProgramGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static HolotapeProgram DeepCopy(
            this IHolotapeProgramGetter item,
            HolotapeProgram.TranslationMask? copyMask = null)
        {
            return ((HolotapeProgramSetterTranslationCommon)((IHolotapeProgramGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static HolotapeProgram DeepCopy(
            this IHolotapeProgramGetter item,
            out HolotapeProgram.ErrorMask errorMask,
            HolotapeProgram.TranslationMask? copyMask = null)
        {
            return ((HolotapeProgramSetterTranslationCommon)((IHolotapeProgramGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static HolotapeProgram DeepCopy(
            this IHolotapeProgramGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((HolotapeProgramSetterTranslationCommon)((IHolotapeProgramGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IHolotapeProgram item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            ((HolotapeProgramSetterCommon)((IHolotapeProgramGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                translationParams: translationParams);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Fallout4
{
    #region Field Index
    internal enum HolotapeProgram_FieldIndex
    {
        File = 0,
    }
    #endregion

    #region Registration
    internal partial class HolotapeProgram_Registration : ILoquiRegistration
    {
        public static readonly HolotapeProgram_Registration Instance = new HolotapeProgram_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Fallout4.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Fallout4.ProtocolKey,
            msgID: 355,
            version: 0);

        public const string GUID = "600c5389-62be-4b50-bc98-093fa0e20fb6";

        public const ushort AdditionalFieldCount = 1;

        public const ushort FieldCount = 1;

        public static readonly Type MaskType = typeof(HolotapeProgram.Mask<>);

        public static readonly Type ErrorMaskType = typeof(HolotapeProgram.ErrorMask);

        public static readonly Type ClassType = typeof(HolotapeProgram);

        public static readonly Type GetterType = typeof(IHolotapeProgramGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IHolotapeProgram);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Fallout4.HolotapeProgram";

        public const string Name = "HolotapeProgram";

        public const string Namespace = "Mutagen.Bethesda.Fallout4";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(HolotapeProgramBinaryWriteTranslation);
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
    internal partial class HolotapeProgramSetterCommon : AHolotapeDataSetterCommon
    {
        public new static readonly HolotapeProgramSetterCommon Instance = new HolotapeProgramSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IHolotapeProgram item)
        {
            ClearPartial();
            item.File = string.Empty;
            base.Clear(item);
        }
        
        public override void Clear(IAHolotapeData item)
        {
            Clear(item: (IHolotapeProgram)item);
        }
        
        #region Mutagen
        public void RemapLinks(IHolotapeProgram obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
            base.RemapLinks(obj, mapping);
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IHolotapeProgram item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            PluginUtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                translationParams: translationParams,
                fillStructs: HolotapeProgramBinaryCreateTranslation.FillBinaryStructs);
        }
        
        public override void CopyInFromBinary(
            IAHolotapeData item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            CopyInFromBinary(
                item: (HolotapeProgram)item,
                frame: frame,
                translationParams: translationParams);
        }
        
        #endregion
        
    }
    internal partial class HolotapeProgramCommon : AHolotapeDataCommon
    {
        public new static readonly HolotapeProgramCommon Instance = new HolotapeProgramCommon();

        public HolotapeProgram.Mask<bool> GetEqualsMask(
            IHolotapeProgramGetter item,
            IHolotapeProgramGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new HolotapeProgram.Mask<bool>(false);
            ((HolotapeProgramCommon)((IHolotapeProgramGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IHolotapeProgramGetter item,
            IHolotapeProgramGetter rhs,
            HolotapeProgram.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.File = string.Equals(item.File, rhs.File);
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string ToString(
            IHolotapeProgramGetter item,
            string? name = null,
            HolotapeProgram.Mask<bool>? printMask = null)
        {
            var sb = new StructuredStringBuilder();
            ToString(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
            return sb.ToString();
        }
        
        public void ToString(
            IHolotapeProgramGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            HolotapeProgram.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                sb.AppendLine($"HolotapeProgram =>");
            }
            else
            {
                sb.AppendLine($"{name} (HolotapeProgram) =>");
            }
            sb.AppendLine("[");
            using (sb.IncreaseDepth())
            {
                ToStringFields(
                    item: item,
                    sb: sb,
                    printMask: printMask);
            }
            sb.AppendLine("]");
        }
        
        protected static void ToStringFields(
            IHolotapeProgramGetter item,
            StructuredStringBuilder sb,
            HolotapeProgram.Mask<bool>? printMask = null)
        {
            AHolotapeDataCommon.ToStringFields(
                item: item,
                sb: sb,
                printMask: printMask);
            if (printMask?.File ?? true)
            {
                sb.AppendItem(item.File, "File");
            }
        }
        
        public static HolotapeProgram_FieldIndex ConvertFieldIndex(AHolotapeData_FieldIndex index)
        {
            switch (index)
            {
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IHolotapeProgramGetter? lhs,
            IHolotapeProgramGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            if (!base.Equals((IAHolotapeDataGetter)lhs, (IAHolotapeDataGetter)rhs, crystal)) return false;
            if ((crystal?.GetShouldTranslate((int)HolotapeProgram_FieldIndex.File) ?? true))
            {
                if (!string.Equals(lhs.File, rhs.File)) return false;
            }
            return true;
        }
        
        public override bool Equals(
            IAHolotapeDataGetter? lhs,
            IAHolotapeDataGetter? rhs,
            TranslationCrystal? crystal)
        {
            return Equals(
                lhs: (IHolotapeProgramGetter?)lhs,
                rhs: rhs as IHolotapeProgramGetter,
                crystal: crystal);
        }
        
        public virtual int GetHashCode(IHolotapeProgramGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.File);
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IAHolotapeDataGetter item)
        {
            return GetHashCode(item: (IHolotapeProgramGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return HolotapeProgram.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> GetContainedFormLinks(IHolotapeProgramGetter obj)
        {
            foreach (var item in base.GetContainedFormLinks(obj))
            {
                yield return item;
            }
            yield break;
        }
        
        #endregion
        
    }
    internal partial class HolotapeProgramSetterTranslationCommon : AHolotapeDataSetterTranslationCommon
    {
        public new static readonly HolotapeProgramSetterTranslationCommon Instance = new HolotapeProgramSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IHolotapeProgram item,
            IHolotapeProgramGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IAHolotapeData)item,
                (IAHolotapeDataGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
            if ((copyMask?.GetShouldTranslate((int)HolotapeProgram_FieldIndex.File) ?? true))
            {
                item.File = rhs.File;
            }
        }
        
        
        public override void DeepCopyIn(
            IAHolotapeData item,
            IAHolotapeDataGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IHolotapeProgram)item,
                rhs: (IHolotapeProgramGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public HolotapeProgram DeepCopy(
            IHolotapeProgramGetter item,
            HolotapeProgram.TranslationMask? copyMask = null)
        {
            HolotapeProgram ret = (HolotapeProgram)((HolotapeProgramCommon)((IHolotapeProgramGetter)item).CommonInstance()!).GetNew();
            ((HolotapeProgramSetterTranslationCommon)((IHolotapeProgramGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public HolotapeProgram DeepCopy(
            IHolotapeProgramGetter item,
            out HolotapeProgram.ErrorMask errorMask,
            HolotapeProgram.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            HolotapeProgram ret = (HolotapeProgram)((HolotapeProgramCommon)((IHolotapeProgramGetter)item).CommonInstance()!).GetNew();
            ((HolotapeProgramSetterTranslationCommon)((IHolotapeProgramGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = HolotapeProgram.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public HolotapeProgram DeepCopy(
            IHolotapeProgramGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            HolotapeProgram ret = (HolotapeProgram)((HolotapeProgramCommon)((IHolotapeProgramGetter)item).CommonInstance()!).GetNew();
            ((HolotapeProgramSetterTranslationCommon)((IHolotapeProgramGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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

namespace Mutagen.Bethesda.Fallout4
{
    public partial class HolotapeProgram
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => HolotapeProgram_Registration.Instance;
        public new static ILoquiRegistration StaticRegistration => HolotapeProgram_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => HolotapeProgramCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return HolotapeProgramSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => HolotapeProgramSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Fallout4
{
    public partial class HolotapeProgramBinaryWriteTranslation :
        AHolotapeDataBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new readonly static HolotapeProgramBinaryWriteTranslation Instance = new HolotapeProgramBinaryWriteTranslation();

        public static void WriteEmbedded(
            IHolotapeProgramGetter item,
            MutagenWriter writer)
        {
            StringBinaryTranslation.Instance.Write(
                writer: writer,
                item: item.File,
                binaryType: StringBinaryType.NullTerminate);
        }

        public void Write(
            MutagenWriter writer,
            IHolotapeProgramGetter item,
            TypedWriteParams? translationParams = null)
        {
            WriteEmbedded(
                item: item,
                writer: writer);
        }

        public override void Write(
            MutagenWriter writer,
            object item,
            TypedWriteParams? translationParams = null)
        {
            Write(
                item: (IHolotapeProgramGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

        public override void Write(
            MutagenWriter writer,
            IAHolotapeDataGetter item,
            TypedWriteParams? translationParams = null)
        {
            Write(
                item: (IHolotapeProgramGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

    }

    internal partial class HolotapeProgramBinaryCreateTranslation : AHolotapeDataBinaryCreateTranslation
    {
        public new readonly static HolotapeProgramBinaryCreateTranslation Instance = new HolotapeProgramBinaryCreateTranslation();

        public static void FillBinaryStructs(
            IHolotapeProgram item,
            MutagenFrame frame)
        {
            item.File = StringBinaryTranslation.Instance.Parse(
                reader: frame,
                stringBinaryType: StringBinaryType.NullTerminate,
                parseWhole: false);
        }

    }

}
namespace Mutagen.Bethesda.Fallout4
{
    #region Binary Write Mixins
    public static class HolotapeProgramBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Fallout4
{
    internal partial class HolotapeProgramBinaryOverlay :
        AHolotapeDataBinaryOverlay,
        IHolotapeProgramGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => HolotapeProgram_Registration.Instance;
        public new static ILoquiRegistration StaticRegistration => HolotapeProgram_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => HolotapeProgramCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => HolotapeProgramSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.ToString(StructuredStringBuilder sb, string? name) => this.ToString(sb, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => HolotapeProgramBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams? translationParams = null)
        {
            ((HolotapeProgramBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }

        #region File
        public String File { get; private set; } = string.Empty;
        protected int FileEndingPos;
        #endregion
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected HolotapeProgramBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static HolotapeProgramBinaryOverlay HolotapeProgramFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            TypedParseParams? parseParams = null)
        {
            var ret = new HolotapeProgramBinaryOverlay(
                bytes: stream.RemainingMemory,
                package: package);
            int offset = stream.Position;
            ret.File = BinaryStringUtility.ParseUnknownLengthString(ret._data, package.MetaData.Encodings.NonTranslated);
            ret.FileEndingPos = ret.File.Length + 1;
            stream.Position += ret.FileEndingPos;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static HolotapeProgramBinaryOverlay HolotapeProgramFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            TypedParseParams? parseParams = null)
        {
            return HolotapeProgramFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                parseParams: parseParams);
        }

        #region To String

        public override void ToString(
            StructuredStringBuilder sb,
            string? name = null)
        {
            HolotapeProgramMixIn.ToString(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IHolotapeProgramGetter rhs) return false;
            return ((HolotapeProgramCommon)((IHolotapeProgramGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IHolotapeProgramGetter? obj)
        {
            return ((HolotapeProgramCommon)((IHolotapeProgramGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((HolotapeProgramCommon)((IHolotapeProgramGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

