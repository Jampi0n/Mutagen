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
using Mutagen.Bethesda.Skyrim;
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
    public partial class LocationObjectType :
        ALocationTarget,
        IEquatable<ILocationObjectTypeGetter>,
        ILocationObjectType,
        ILoquiObjectSetter<LocationObjectType>
    {
        #region Ctor
        public LocationObjectType()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Type
        public TargetObjectType Type { get; set; } = default;
        #endregion

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            LocationObjectTypeMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not ILocationObjectTypeGetter rhs) return false;
            return ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(ILocationObjectTypeGetter? obj)
        {
            return ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            ALocationTarget.Mask<TItem>,
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem Type)
            : base()
            {
                this.Type = Type;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Type;
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
                if (!object.Equals(this.Type, rhs.Type)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Type);
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                if (!eval(this.Type)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                if (eval(this.Type)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new LocationObjectType.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
                obj.Type = eval(this.Type);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(LocationObjectType.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, LocationObjectType.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(LocationObjectType.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (printMask?.Type ?? true)
                    {
                        fg.AppendItem(Type, "Type");
                    }
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public new class ErrorMask :
            ALocationTarget.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Type;
            #endregion

            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                LocationObjectType_FieldIndex enu = (LocationObjectType_FieldIndex)index;
                switch (enu)
                {
                    case LocationObjectType_FieldIndex.Type:
                        return Type;
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                LocationObjectType_FieldIndex enu = (LocationObjectType_FieldIndex)index;
                switch (enu)
                {
                    case LocationObjectType_FieldIndex.Type:
                        this.Type = ex;
                        break;
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                LocationObjectType_FieldIndex enu = (LocationObjectType_FieldIndex)index;
                switch (enu)
                {
                    case LocationObjectType_FieldIndex.Type:
                        this.Type = (Exception?)obj;
                        break;
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                if (Type != null) return true;
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

            public override void ToString(FileGeneration fg, string? name = null)
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
            protected override void ToString_FillInternal(FileGeneration fg)
            {
                base.ToString_FillInternal(fg);
                fg.AppendItem(Type, "Type");
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Type = this.Type.Combine(rhs.Type);
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
            ALocationTarget.TranslationMask,
            ITranslationMask
        {
            #region Members
            public bool Type;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
                this.Type = defaultOn;
            }

            #endregion

            protected override void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                base.GetCrystal(ret);
                ret.Add((Type, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => LocationObjectTypeBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((LocationObjectTypeBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #region Binary Create
        public new static LocationObjectType CreateFromBinary(
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new LocationObjectType();
            ((LocationObjectTypeSetterCommon)((ILocationObjectTypeGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out LocationObjectType item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(
                frame: frame,
                recordTypeConverter: recordTypeConverter);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        void IClearable.Clear()
        {
            ((LocationObjectTypeSetterCommon)((ILocationObjectTypeGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new LocationObjectType GetNew()
        {
            return new LocationObjectType();
        }

    }
    #endregion

    #region Interface
    public partial interface ILocationObjectType :
        IALocationTarget,
        ILocationObjectTypeGetter,
        ILoquiObjectSetter<ILocationObjectType>
    {
        new TargetObjectType Type { get; set; }
    }

    public partial interface ILocationObjectTypeGetter :
        IALocationTargetGetter,
        IBinaryItem,
        ILoquiObject<ILocationObjectTypeGetter>
    {
        static new ILoquiRegistration Registration => LocationObjectType_Registration.Instance;
        TargetObjectType Type { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class LocationObjectTypeMixIn
    {
        public static void Clear(this ILocationObjectType item)
        {
            ((LocationObjectTypeSetterCommon)((ILocationObjectTypeGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static LocationObjectType.Mask<bool> GetEqualsMask(
            this ILocationObjectTypeGetter item,
            ILocationObjectTypeGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this ILocationObjectTypeGetter item,
            string? name = null,
            LocationObjectType.Mask<bool>? printMask = null)
        {
            return ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this ILocationObjectTypeGetter item,
            FileGeneration fg,
            string? name = null,
            LocationObjectType.Mask<bool>? printMask = null)
        {
            ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this ILocationObjectTypeGetter item,
            ILocationObjectTypeGetter rhs,
            LocationObjectType.TranslationMask? equalsMask = null)
        {
            return ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs,
                crystal: equalsMask?.GetCrystal());
        }

        public static void DeepCopyIn(
            this ILocationObjectType lhs,
            ILocationObjectTypeGetter rhs,
            out LocationObjectType.ErrorMask errorMask,
            LocationObjectType.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((LocationObjectTypeSetterTranslationCommon)((ILocationObjectTypeGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = LocationObjectType.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this ILocationObjectType lhs,
            ILocationObjectTypeGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((LocationObjectTypeSetterTranslationCommon)((ILocationObjectTypeGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static LocationObjectType DeepCopy(
            this ILocationObjectTypeGetter item,
            LocationObjectType.TranslationMask? copyMask = null)
        {
            return ((LocationObjectTypeSetterTranslationCommon)((ILocationObjectTypeGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static LocationObjectType DeepCopy(
            this ILocationObjectTypeGetter item,
            out LocationObjectType.ErrorMask errorMask,
            LocationObjectType.TranslationMask? copyMask = null)
        {
            return ((LocationObjectTypeSetterTranslationCommon)((ILocationObjectTypeGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static LocationObjectType DeepCopy(
            this ILocationObjectTypeGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((LocationObjectTypeSetterTranslationCommon)((ILocationObjectTypeGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this ILocationObjectType item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((LocationObjectTypeSetterCommon)((ILocationObjectTypeGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim.Internals
{
    #region Field Index
    public enum LocationObjectType_FieldIndex
    {
        Type = 0,
    }
    #endregion

    #region Registration
    public partial class LocationObjectType_Registration : ILoquiRegistration
    {
        public static readonly LocationObjectType_Registration Instance = new LocationObjectType_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Skyrim.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Skyrim.ProtocolKey,
            msgID: 231,
            version: 0);

        public const string GUID = "b0933e27-071b-4751-8a06-52e3703c2e5c";

        public const ushort AdditionalFieldCount = 1;

        public const ushort FieldCount = 1;

        public static readonly Type MaskType = typeof(LocationObjectType.Mask<>);

        public static readonly Type ErrorMaskType = typeof(LocationObjectType.ErrorMask);

        public static readonly Type ClassType = typeof(LocationObjectType);

        public static readonly Type GetterType = typeof(ILocationObjectTypeGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(ILocationObjectType);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Skyrim.LocationObjectType";

        public const string Name = "LocationObjectType";

        public const string Namespace = "Mutagen.Bethesda.Skyrim";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(LocationObjectTypeBinaryWriteTranslation);
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
    public partial class LocationObjectTypeSetterCommon : ALocationTargetSetterCommon
    {
        public new static readonly LocationObjectTypeSetterCommon Instance = new LocationObjectTypeSetterCommon();

        partial void ClearPartial();
        
        public void Clear(ILocationObjectType item)
        {
            ClearPartial();
            item.Type = default;
            base.Clear(item);
        }
        
        public override void Clear(IALocationTarget item)
        {
            Clear(item: (ILocationObjectType)item);
        }
        
        #region Mutagen
        public void RemapLinks(ILocationObjectType obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
            base.RemapLinks(obj, mapping);
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            ILocationObjectType item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            PluginUtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter,
                fillStructs: LocationObjectTypeBinaryCreateTranslation.FillBinaryStructs);
        }
        
        public override void CopyInFromBinary(
            IALocationTarget item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            CopyInFromBinary(
                item: (LocationObjectType)item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }
        
        #endregion
        
    }
    public partial class LocationObjectTypeCommon : ALocationTargetCommon
    {
        public new static readonly LocationObjectTypeCommon Instance = new LocationObjectTypeCommon();

        public LocationObjectType.Mask<bool> GetEqualsMask(
            ILocationObjectTypeGetter item,
            ILocationObjectTypeGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new LocationObjectType.Mask<bool>(false);
            ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            ILocationObjectTypeGetter item,
            ILocationObjectTypeGetter rhs,
            LocationObjectType.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.Type = item.Type == rhs.Type;
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string ToString(
            ILocationObjectTypeGetter item,
            string? name = null,
            LocationObjectType.Mask<bool>? printMask = null)
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
            ILocationObjectTypeGetter item,
            FileGeneration fg,
            string? name = null,
            LocationObjectType.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"LocationObjectType =>");
            }
            else
            {
                fg.AppendLine($"{name} (LocationObjectType) =>");
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
            ILocationObjectTypeGetter item,
            FileGeneration fg,
            LocationObjectType.Mask<bool>? printMask = null)
        {
            ALocationTargetCommon.ToStringFields(
                item: item,
                fg: fg,
                printMask: printMask);
            if (printMask?.Type ?? true)
            {
                fg.AppendItem(item.Type, "Type");
            }
        }
        
        public static LocationObjectType_FieldIndex ConvertFieldIndex(ALocationTarget_FieldIndex index)
        {
            switch (index)
            {
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            ILocationObjectTypeGetter? lhs,
            ILocationObjectTypeGetter? rhs,
            TranslationCrystal? crystal)
        {
            if (!EqualsMaskHelper.RefEquality(lhs, rhs, out var isEqual)) return isEqual;
            if (!base.Equals((IALocationTargetGetter)lhs, (IALocationTargetGetter)rhs, crystal)) return false;
            if ((crystal?.GetShouldTranslate((int)LocationObjectType_FieldIndex.Type) ?? true))
            {
                if (lhs.Type != rhs.Type) return false;
            }
            return true;
        }
        
        public override bool Equals(
            IALocationTargetGetter? lhs,
            IALocationTargetGetter? rhs,
            TranslationCrystal? crystal)
        {
            return Equals(
                lhs: (ILocationObjectTypeGetter?)lhs,
                rhs: rhs as ILocationObjectTypeGetter,
                crystal: crystal);
        }
        
        public virtual int GetHashCode(ILocationObjectTypeGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.Type);
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IALocationTargetGetter item)
        {
            return GetHashCode(item: (ILocationObjectTypeGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return LocationObjectType.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<IFormLinkGetter> GetContainedFormLinks(ILocationObjectTypeGetter obj)
        {
            foreach (var item in base.GetContainedFormLinks(obj))
            {
                yield return item;
            }
            yield break;
        }
        
        #endregion
        
    }
    public partial class LocationObjectTypeSetterTranslationCommon : ALocationTargetSetterTranslationCommon
    {
        public new static readonly LocationObjectTypeSetterTranslationCommon Instance = new LocationObjectTypeSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            ILocationObjectType item,
            ILocationObjectTypeGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IALocationTarget)item,
                (IALocationTargetGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
            if ((copyMask?.GetShouldTranslate((int)LocationObjectType_FieldIndex.Type) ?? true))
            {
                item.Type = rhs.Type;
            }
        }
        
        
        public override void DeepCopyIn(
            IALocationTarget item,
            IALocationTargetGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (ILocationObjectType)item,
                rhs: (ILocationObjectTypeGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public LocationObjectType DeepCopy(
            ILocationObjectTypeGetter item,
            LocationObjectType.TranslationMask? copyMask = null)
        {
            LocationObjectType ret = (LocationObjectType)((LocationObjectTypeCommon)((ILocationObjectTypeGetter)item).CommonInstance()!).GetNew();
            ((LocationObjectTypeSetterTranslationCommon)((ILocationObjectTypeGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public LocationObjectType DeepCopy(
            ILocationObjectTypeGetter item,
            out LocationObjectType.ErrorMask errorMask,
            LocationObjectType.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            LocationObjectType ret = (LocationObjectType)((LocationObjectTypeCommon)((ILocationObjectTypeGetter)item).CommonInstance()!).GetNew();
            ((LocationObjectTypeSetterTranslationCommon)((ILocationObjectTypeGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = LocationObjectType.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public LocationObjectType DeepCopy(
            ILocationObjectTypeGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            LocationObjectType ret = (LocationObjectType)((LocationObjectTypeCommon)((ILocationObjectTypeGetter)item).CommonInstance()!).GetNew();
            ((LocationObjectTypeSetterTranslationCommon)((ILocationObjectTypeGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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
    public partial class LocationObjectType
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => LocationObjectType_Registration.Instance;
        public new static LocationObjectType_Registration Registration => LocationObjectType_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => LocationObjectTypeCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return LocationObjectTypeSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => LocationObjectTypeSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class LocationObjectTypeBinaryWriteTranslation :
        ALocationTargetBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new readonly static LocationObjectTypeBinaryWriteTranslation Instance = new LocationObjectTypeBinaryWriteTranslation();

        public static void WriteEmbedded(
            ILocationObjectTypeGetter item,
            MutagenWriter writer)
        {
            EnumBinaryTranslation<TargetObjectType, MutagenFrame, MutagenWriter>.Instance.Write(
                writer,
                item.Type,
                length: 4);
        }

        public void Write(
            MutagenWriter writer,
            ILocationObjectTypeGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            WriteEmbedded(
                item: item,
                writer: writer);
        }

        public override void Write(
            MutagenWriter writer,
            object item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (ILocationObjectTypeGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public override void Write(
            MutagenWriter writer,
            IALocationTargetGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (ILocationObjectTypeGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class LocationObjectTypeBinaryCreateTranslation : ALocationTargetBinaryCreateTranslation
    {
        public new readonly static LocationObjectTypeBinaryCreateTranslation Instance = new LocationObjectTypeBinaryCreateTranslation();

        public static void FillBinaryStructs(
            ILocationObjectType item,
            MutagenFrame frame)
        {
            item.Type = EnumBinaryTranslation<TargetObjectType, MutagenFrame, MutagenWriter>.Instance.Parse(
                reader: frame,
                length: 4);
        }

    }

}
namespace Mutagen.Bethesda.Skyrim
{
    #region Binary Write Mixins
    public static class LocationObjectTypeBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class LocationObjectTypeBinaryOverlay :
        ALocationTargetBinaryOverlay,
        ILocationObjectTypeGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => LocationObjectType_Registration.Instance;
        public new static LocationObjectType_Registration Registration => LocationObjectType_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => LocationObjectTypeCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => LocationObjectTypeSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => LocationObjectTypeBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((LocationObjectTypeBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public TargetObjectType Type => (TargetObjectType)BinaryPrimitives.ReadInt32LittleEndian(_data.Span.Slice(0x0, 0x4));
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected LocationObjectTypeBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static LocationObjectTypeBinaryOverlay LocationObjectTypeFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new LocationObjectTypeBinaryOverlay(
                bytes: stream.RemainingMemory.Slice(0, 0x4),
                package: package);
            int offset = stream.Position;
            stream.Position += 0x4;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static LocationObjectTypeBinaryOverlay LocationObjectTypeFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            return LocationObjectTypeFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                recordTypeConverter: recordTypeConverter);
        }

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            LocationObjectTypeMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (obj is not ILocationObjectTypeGetter rhs) return false;
            return ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)this).CommonInstance()!).Equals(this, rhs, crystal: null);
        }

        public bool Equals(ILocationObjectTypeGetter? obj)
        {
            return ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)this).CommonInstance()!).Equals(this, obj, crystal: null);
        }

        public override int GetHashCode() => ((LocationObjectTypeCommon)((ILocationObjectTypeGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

