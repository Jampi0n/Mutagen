using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.Skyrim;

public partial class MagicEffectSpawnHazardArchetype
{
    public FormLink<IHazardGetter> Association => this.AssociationKey.ToLink<IHazardGetter>();

    IFormLink<IHazardGetter> IMagicEffectSpawnHazardArchetype.Association => this.Association;
    IFormLinkGetter<IHazardGetter> IMagicEffectSpawnHazardArchetypeGetter.Association => this.Association;

    public MagicEffectSpawnHazardArchetype()
        : base(TypeEnum.SpawnHazard)
    {
    }
}

public partial interface IMagicEffectSpawnHazardArchetype
{
    new IFormLink<IHazardGetter> Association { get; }
}

public partial interface IMagicEffectSpawnHazardArchetypeGetter
{
    IFormLinkGetter<IHazardGetter> Association { get; }
}

partial class MagicEffectSpawnHazardArchetypeBinaryOverlay
{
    public IFormLinkGetter<IHazardGetter> Association => this.AssociationKey.ToLink<IHazardGetter>();
}