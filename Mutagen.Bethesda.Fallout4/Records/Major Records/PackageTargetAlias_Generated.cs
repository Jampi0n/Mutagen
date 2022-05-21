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
using Mutagen.Bethesda.Plugins.Binary.Headers;
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
using Noggog.StructuredStrings;
using Noggog.StructuredStrings.CSharp;
using RecordTypeInts = Mutagen.Bethesda.Fallout4.Internals.RecordTypeInts;
using RecordTypes = Mutagen.Bethesda.Fallout4.Internals.RecordTypes;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Disposables;
using System.Reactive.Linq;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Fallout4
{
    #region Class
    public partial class PackageTargetAlias :
        APackageTarget,
        IEquatable<IPackageTargetAliasGetter>,
        ILoquiObjectSetter<PackageTargetAlias>,
        IPackageTargetAlias
    {
        #region Ctor
        public PackageTargetAlias()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Alias
        public Int32 Alias { get; set; } = default;
        #endregion

        #region To String

        public override void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            PackageTargetAliasMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IPackageTargetAliasGetter rhs) return false;
            return ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IPackageTargetAliasGetter? obj)
        {
            return ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            APackageTarget.Mask<TItem>,
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem initialValue)
            : base(initialValue)
            {
                this.Alias = initialValue;
            }

            public Mask(
                TItem CountOrDistance,
                TItem Alias)
            : base(CountOrDistance: CountOrDistance)
            {
                this.Alias = Alias;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Alias;
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
                if (!object.Equals(this.Alias, rhs.Alias)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Alias);
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                if (!eval(this.Alias)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                if (eval(this.Alias)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new PackageTargetAlias.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
                obj.Alias = eval(this.Alias);
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public string Print(PackageTargetAlias.Mask<bool>? printMask = null)
            {
                var sb = new StructuredStringBuilder();
                Print(sb, printMask);
                return sb.ToString();
            }

            public void Print(StructuredStringBuilder sb, PackageTargetAlias.Mask<bool>? printMask = null)
            {
                sb.AppendLine($"{nameof(PackageTargetAlias.Mask<TItem>)} =>");
                using (sb.Brace())
                {
                    if (printMask?.Alias ?? true)
                    {
                        sb.AppendItem(Alias, "Alias");
                    }
                }
            }
            #endregion

        }

        public new class ErrorMask :
            APackageTarget.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Alias;
            #endregion

            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                PackageTargetAlias_FieldIndex enu = (PackageTargetAlias_FieldIndex)index;
                switch (enu)
                {
                    case PackageTargetAlias_FieldIndex.Alias:
                        return Alias;
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                PackageTargetAlias_FieldIndex enu = (PackageTargetAlias_FieldIndex)index;
                switch (enu)
                {
                    case PackageTargetAlias_FieldIndex.Alias:
                        this.Alias = ex;
                        break;
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                PackageTargetAlias_FieldIndex enu = (PackageTargetAlias_FieldIndex)index;
                switch (enu)
                {
                    case PackageTargetAlias_FieldIndex.Alias:
                        this.Alias = (Exception?)obj;
                        break;
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                if (Alias != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString() => this.Print();

            public override void Print(StructuredStringBuilder sb, string? name = null)
            {
                sb.AppendLine($"{(name ?? "ErrorMask")} =>");
                using (sb.Brace())
                {
                    if (this.Overall != null)
                    {
                        sb.AppendLine("Overall =>");
                        using (sb.Brace())
                        {
                            sb.AppendLine($"{this.Overall}");
                        }
                    }
                    PrintFillInternal(sb);
                }
            }
            protected override void PrintFillInternal(StructuredStringBuilder sb)
            {
                base.PrintFillInternal(sb);
                {
                    sb.AppendItem(Alias, "Alias");
                }
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Alias = this.Alias.Combine(rhs.Alias);
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
            APackageTarget.TranslationMask,
            ITranslationMask
        {
            #region Members
            public bool Alias;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
                this.Alias = defaultOn;
            }

            #endregion

            protected override void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                base.GetCrystal(ret);
                ret.Add((Alias, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => PackageTargetAliasBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams? translationParams = null)
        {
            ((PackageTargetAliasBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }
        #region Binary Create
        public new static PackageTargetAlias CreateFromBinary(
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            var ret = new PackageTargetAlias();
            ((PackageTargetAliasSetterCommon)((IPackageTargetAliasGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                translationParams: translationParams);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out PackageTargetAlias item,
            TypedParseParams? translationParams = null)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(
                frame: frame,
                translationParams: translationParams);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        void IClearable.Clear()
        {
            ((PackageTargetAliasSetterCommon)((IPackageTargetAliasGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new PackageTargetAlias GetNew()
        {
            return new PackageTargetAlias();
        }

    }
    #endregion

    #region Interface
    public partial interface IPackageTargetAlias :
        IAPackageTarget,
        ILoquiObjectSetter<IPackageTargetAlias>,
        IPackageTargetAliasGetter
    {
        new Int32 Alias { get; set; }
    }

    public partial interface IPackageTargetAliasGetter :
        IAPackageTargetGetter,
        IBinaryItem,
        ILoquiObject<IPackageTargetAliasGetter>
    {
        static new ILoquiRegistration StaticRegistration => PackageTargetAlias_Registration.Instance;
        Int32 Alias { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class PackageTargetAliasMixIn
    {
        public static void Clear(this IPackageTargetAlias item)
        {
            ((PackageTargetAliasSetterCommon)((IPackageTargetAliasGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static PackageTargetAlias.Mask<bool> GetEqualsMask(
            this IPackageTargetAliasGetter item,
            IPackageTargetAliasGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string Print(
            this IPackageTargetAliasGetter item,
            string? name = null,
            PackageTargetAlias.Mask<bool>? printMask = null)
        {
            return ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)item).CommonInstance()!).Print(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void Print(
            this IPackageTargetAliasGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            PackageTargetAlias.Mask<bool>? printMask = null)
        {
            ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)item).CommonInstance()!).Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IPackageTargetAliasGetter item,
            IPackageTargetAliasGetter rhs,
            PackageTargetAlias.TranslationMask? equalsMask = null)
        {
            return ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this IPackageTargetAlias lhs,
            IPackageTargetAliasGetter rhs,
            out PackageTargetAlias.ErrorMask errorMask,
            PackageTargetAlias.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((PackageTargetAliasSetterTranslationCommon)((IPackageTargetAliasGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = PackageTargetAlias.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IPackageTargetAlias lhs,
            IPackageTargetAliasGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((PackageTargetAliasSetterTranslationCommon)((IPackageTargetAliasGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static PackageTargetAlias DeepCopy(
            this IPackageTargetAliasGetter item,
            PackageTargetAlias.TranslationMask? copyMask = null)
        {
            return ((PackageTargetAliasSetterTranslationCommon)((IPackageTargetAliasGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static PackageTargetAlias DeepCopy(
            this IPackageTargetAliasGetter item,
            out PackageTargetAlias.ErrorMask errorMask,
            PackageTargetAlias.TranslationMask? copyMask = null)
        {
            return ((PackageTargetAliasSetterTranslationCommon)((IPackageTargetAliasGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static PackageTargetAlias DeepCopy(
            this IPackageTargetAliasGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((PackageTargetAliasSetterTranslationCommon)((IPackageTargetAliasGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IPackageTargetAlias item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            ((PackageTargetAliasSetterCommon)((IPackageTargetAliasGetter)item).CommonSetterInstance()!).CopyInFromBinary(
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
    internal enum PackageTargetAlias_FieldIndex
    {
        CountOrDistance = 0,
        Alias = 1,
    }
    #endregion

    #region Registration
    internal partial class PackageTargetAlias_Registration : ILoquiRegistration
    {
        public static readonly PackageTargetAlias_Registration Instance = new PackageTargetAlias_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Fallout4.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Fallout4.ProtocolKey,
            msgID: 580,
            version: 0);

        public const string GUID = "6a0a228c-2ee7-4c6f-997c-90e26b2ad719";

        public const ushort AdditionalFieldCount = 1;

        public const ushort FieldCount = 2;

        public static readonly Type MaskType = typeof(PackageTargetAlias.Mask<>);

        public static readonly Type ErrorMaskType = typeof(PackageTargetAlias.ErrorMask);

        public static readonly Type ClassType = typeof(PackageTargetAlias);

        public static readonly Type GetterType = typeof(IPackageTargetAliasGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IPackageTargetAlias);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Fallout4.PackageTargetAlias";

        public const string Name = "PackageTargetAlias";

        public const string Namespace = "Mutagen.Bethesda.Fallout4";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(PackageTargetAliasBinaryWriteTranslation);
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
    internal partial class PackageTargetAliasSetterCommon : APackageTargetSetterCommon
    {
        public new static readonly PackageTargetAliasSetterCommon Instance = new PackageTargetAliasSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IPackageTargetAlias item)
        {
            ClearPartial();
            item.Alias = default;
            base.Clear(item);
        }
        
        public override void Clear(IAPackageTarget item)
        {
            Clear(item: (IPackageTargetAlias)item);
        }
        
        #region Mutagen
        public void RemapLinks(IPackageTargetAlias obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
            base.RemapLinks(obj, mapping);
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IPackageTargetAlias item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            PluginUtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                translationParams: translationParams,
                fillStructs: PackageTargetAliasBinaryCreateTranslation.FillBinaryStructs);
        }
        
        public override void CopyInFromBinary(
            IAPackageTarget item,
            MutagenFrame frame,
            TypedParseParams? translationParams = null)
        {
            CopyInFromBinary(
                item: (PackageTargetAlias)item,
                frame: frame,
                translationParams: translationParams);
        }
        
        #endregion
        
    }
    internal partial class PackageTargetAliasCommon : APackageTargetCommon
    {
        public new static readonly PackageTargetAliasCommon Instance = new PackageTargetAliasCommon();

        public PackageTargetAlias.Mask<bool> GetEqualsMask(
            IPackageTargetAliasGetter item,
            IPackageTargetAliasGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new PackageTargetAlias.Mask<bool>(false);
            ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IPackageTargetAliasGetter item,
            IPackageTargetAliasGetter rhs,
            PackageTargetAlias.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.Alias = item.Alias == rhs.Alias;
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string Print(
            IPackageTargetAliasGetter item,
            string? name = null,
            PackageTargetAlias.Mask<bool>? printMask = null)
        {
            var sb = new StructuredStringBuilder();
            Print(
                item: item,
                sb: sb,
                name: name,
                printMask: printMask);
            return sb.ToString();
        }
        
        public void Print(
            IPackageTargetAliasGetter item,
            StructuredStringBuilder sb,
            string? name = null,
            PackageTargetAlias.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                sb.AppendLine($"PackageTargetAlias =>");
            }
            else
            {
                sb.AppendLine($"{name} (PackageTargetAlias) =>");
            }
            using (sb.Brace())
            {
                ToStringFields(
                    item: item,
                    sb: sb,
                    printMask: printMask);
            }
        }
        
        protected static void ToStringFields(
            IPackageTargetAliasGetter item,
            StructuredStringBuilder sb,
            PackageTargetAlias.Mask<bool>? printMask = null)
        {
            APackageTargetCommon.ToStringFields(
                item: item,
                sb: sb,
                printMask: printMask);
            if (printMask?.Alias ?? true)
            {
                sb.AppendItem(item.Alias, "Alias");
            }
        }
        
        public static PackageTargetAlias_FieldIndex ConvertFieldIndex(APackageTarget_FieldIndex index)
        {
            switch (index)
            {
                case APackageTarget_FieldIndex.CountOrDistance:
                    return (PackageTargetAlias_FieldIndex)((int)index);
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IPackageTargetAliasGetter? lhs,
            IPackageTargetAliasGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            if (!base.Equals((IAPackageTargetGetter)lhs, (IAPackageTargetGetter)rhs, crystal)) return false;
            if ((crystal?.GetShouldTranslate((int)PackageTargetAlias_FieldIndex.Alias) ?? true))
            {
                if (lhs.Alias != rhs.Alias) return false;
            }
            return true;
        }
        
        public override bool Equals(
            IAPackageTargetGetter? lhs,
            IAPackageTargetGetter? rhs,
            TranslationCrystal? crystal)
        {
            return Equals(
                lhs: (IPackageTargetAliasGetter?)lhs,
                rhs: rhs as IPackageTargetAliasGetter,
                crystal: crystal);
        }
        
        public virtual int GetHashCode(IPackageTargetAliasGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.Alias);
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IAPackageTargetGetter item)
        {
            return GetHashCode(item: (IPackageTargetAliasGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return PackageTargetAlias.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> EnumerateFormLinks(IPackageTargetAliasGetter obj)
        {
            foreach (var item in base.EnumerateFormLinks(obj))
            {
                yield return item;
            }
            yield break;
        }
        
        #endregion
        
    }
    internal partial class PackageTargetAliasSetterTranslationCommon : APackageTargetSetterTranslationCommon
    {
        public new static readonly PackageTargetAliasSetterTranslationCommon Instance = new PackageTargetAliasSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IPackageTargetAlias item,
            IPackageTargetAliasGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IAPackageTarget)item,
                (IAPackageTargetGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
            if ((copyMask?.GetShouldTranslate((int)PackageTargetAlias_FieldIndex.Alias) ?? true))
            {
                item.Alias = rhs.Alias;
            }
        }
        
        
        public override void DeepCopyIn(
            IAPackageTarget item,
            IAPackageTargetGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IPackageTargetAlias)item,
                rhs: (IPackageTargetAliasGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public PackageTargetAlias DeepCopy(
            IPackageTargetAliasGetter item,
            PackageTargetAlias.TranslationMask? copyMask = null)
        {
            PackageTargetAlias ret = (PackageTargetAlias)((PackageTargetAliasCommon)((IPackageTargetAliasGetter)item).CommonInstance()!).GetNew();
            ((PackageTargetAliasSetterTranslationCommon)((IPackageTargetAliasGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public PackageTargetAlias DeepCopy(
            IPackageTargetAliasGetter item,
            out PackageTargetAlias.ErrorMask errorMask,
            PackageTargetAlias.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            PackageTargetAlias ret = (PackageTargetAlias)((PackageTargetAliasCommon)((IPackageTargetAliasGetter)item).CommonInstance()!).GetNew();
            ((PackageTargetAliasSetterTranslationCommon)((IPackageTargetAliasGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = PackageTargetAlias.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public PackageTargetAlias DeepCopy(
            IPackageTargetAliasGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            PackageTargetAlias ret = (PackageTargetAlias)((PackageTargetAliasCommon)((IPackageTargetAliasGetter)item).CommonInstance()!).GetNew();
            ((PackageTargetAliasSetterTranslationCommon)((IPackageTargetAliasGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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
    public partial class PackageTargetAlias
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => PackageTargetAlias_Registration.Instance;
        public new static ILoquiRegistration StaticRegistration => PackageTargetAlias_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => PackageTargetAliasCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return PackageTargetAliasSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => PackageTargetAliasSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Fallout4
{
    public partial class PackageTargetAliasBinaryWriteTranslation :
        APackageTargetBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new readonly static PackageTargetAliasBinaryWriteTranslation Instance = new PackageTargetAliasBinaryWriteTranslation();

        public static void WriteEmbedded(
            IPackageTargetAliasGetter item,
            MutagenWriter writer)
        {
            APackageTargetBinaryWriteTranslation.WriteEmbedded(
                item: item,
                writer: writer);
            writer.Write(item.Alias);
        }

        public void Write(
            MutagenWriter writer,
            IPackageTargetAliasGetter item,
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
                item: (IPackageTargetAliasGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

        public override void Write(
            MutagenWriter writer,
            IAPackageTargetGetter item,
            TypedWriteParams? translationParams = null)
        {
            Write(
                item: (IPackageTargetAliasGetter)item,
                writer: writer,
                translationParams: translationParams);
        }

    }

    internal partial class PackageTargetAliasBinaryCreateTranslation : APackageTargetBinaryCreateTranslation
    {
        public new readonly static PackageTargetAliasBinaryCreateTranslation Instance = new PackageTargetAliasBinaryCreateTranslation();

        public static void FillBinaryStructs(
            IPackageTargetAlias item,
            MutagenFrame frame)
        {
            APackageTargetBinaryCreateTranslation.FillBinaryStructs(
                item: item,
                frame: frame);
            item.Alias = frame.ReadInt32();
        }

    }

}
namespace Mutagen.Bethesda.Fallout4
{
    #region Binary Write Mixins
    public static class PackageTargetAliasBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Fallout4
{
    internal partial class PackageTargetAliasBinaryOverlay :
        APackageTargetBinaryOverlay,
        IPackageTargetAliasGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => PackageTargetAlias_Registration.Instance;
        public new static ILoquiRegistration StaticRegistration => PackageTargetAlias_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => PackageTargetAliasCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => PackageTargetAliasSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.Print(StructuredStringBuilder sb, string? name) => this.Print(sb, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => PackageTargetAliasBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            TypedWriteParams? translationParams = null)
        {
            ((PackageTargetAliasBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                translationParams: translationParams);
        }

        public Int32 Alias => BinaryPrimitives.ReadInt32LittleEndian(_data.Slice(0xC, 0x4));
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected PackageTargetAliasBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static PackageTargetAliasBinaryOverlay PackageTargetAliasFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            TypedParseParams? parseParams = null)
        {
            var ret = new PackageTargetAliasBinaryOverlay(
                bytes: stream.RemainingMemory.Slice(0, 0x10),
                package: package);
            int offset = stream.Position;
            stream.Position += 0x10;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static PackageTargetAliasBinaryOverlay PackageTargetAliasFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            TypedParseParams? parseParams = null)
        {
            return PackageTargetAliasFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                parseParams: parseParams);
        }

        #region To String

        public override void Print(
            StructuredStringBuilder sb,
            string? name = null)
        {
            PackageTargetAliasMixIn.Print(
                item: this,
                sb: sb,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not IPackageTargetAliasGetter rhs) return false;
            return ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(IPackageTargetAliasGetter? obj)
        {
            return ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((PackageTargetAliasCommon)((IPackageTargetAliasGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

