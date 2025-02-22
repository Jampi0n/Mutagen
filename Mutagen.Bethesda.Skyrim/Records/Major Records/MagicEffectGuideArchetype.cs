using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Skyrim;

public partial class MagicEffectGuideArchetype
{
    public FormLink<IHazardGetter> Association => this.AssociationKey.ToLink<IHazardGetter>();

    IFormLink<IHazardGetter> IMagicEffectGuideArchetype.Association => this.Association;
    IFormLinkGetter<IHazardGetter> IMagicEffectGuideArchetypeGetter.Association => this.Association;

    public MagicEffectGuideArchetype()
        : base(TypeEnum.Guide)
    {
    }
}

public partial interface IMagicEffectGuideArchetype
{
    new IFormLink<IHazardGetter> Association { get; }
}

public partial interface IMagicEffectGuideArchetypeGetter
{
    IFormLinkGetter<IHazardGetter> Association { get; }
}

partial class MagicEffectGuideArchetypeBinaryOverlay
{
    public IFormLinkGetter<IHazardGetter> Association => this.AssociationKey.ToLink<IHazardGetter>();
}