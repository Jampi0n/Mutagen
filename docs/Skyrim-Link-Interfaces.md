<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
## Table Of Contents

- [Link Interfaces](#link-interfaces)
  - [Interfaces to Concrete Classes](#interfaces-to-concrete-classes)
    - [IAliasVoiceType](#ialiasvoicetype)
    - [IComplexLocation](#icomplexlocation)
    - [IConstructible](#iconstructible)
    - [IDialog](#idialog)
    - [IEffectRecord](#ieffectrecord)
    - [IEmittance](#iemittance)
    - [IHarvestTarget](#iharvesttarget)
    - [IIdleRelation](#iidlerelation)
    - [IItem](#iitem)
    - [IKeywordLinkedReference](#ikeywordlinkedreference)
    - [ILinkedReference](#ilinkedreference)
    - [ILocationRecord](#ilocationrecord)
    - [ILocationTargetable](#ilocationtargetable)
    - [ILockList](#ilocklist)
    - [INpcSpawn](#inpcspawn)
    - [IObjectId](#iobjectid)
    - [IOutfitTarget](#ioutfittarget)
    - [IOwner](#iowner)
    - [IPlaced](#iplaced)
    - [IPlacedSimple](#iplacedsimple)
    - [IPlacedThing](#iplacedthing)
    - [IPlacedTrapTarget](#iplacedtraptarget)
    - [IRegionTarget](#iregiontarget)
    - [IRelatable](#irelatable)
    - [ISound](#isound)
    - [ISpellSpawn](#ispellspawn)
  - [Concrete Classes to Interfaces](#concrete-classes-to-interfaces)
    - [ActionRecord](#actionrecord)
    - [Activator](#activator)
    - [AlchemicalApparatus](#alchemicalapparatus)
    - [Ammunition](#ammunition)
    - [APlaced](#aplaced)
    - [APlacedTrap](#aplacedtrap)
    - [Armor](#armor)
    - [Book](#book)
    - [Cell](#cell)
    - [Container](#container)
    - [DialogResponses](#dialogresponses)
    - [DialogTopic](#dialogtopic)
    - [Door](#door)
    - [Faction](#faction)
    - [Flora](#flora)
    - [FormList](#formlist)
    - [Furniture](#furniture)
    - [Hazard](#hazard)
    - [IdleAnimation](#idleanimation)
    - [IdleMarker](#idlemarker)
    - [Ingestible](#ingestible)
    - [Ingredient](#ingredient)
    - [Key](#key)
    - [Keyword](#keyword)
    - [LandscapeTexture](#landscapetexture)
    - [LeveledItem](#leveleditem)
    - [LeveledNpc](#levelednpc)
    - [LeveledSpell](#leveledspell)
    - [Light](#light)
    - [Location](#location)
    - [LocationReferenceType](#locationreferencetype)
    - [MiscItem](#miscitem)
    - [MoveableStatic](#moveablestatic)
    - [Npc](#npc)
    - [ObjectEffect](#objecteffect)
    - [PlacedNpc](#placednpc)
    - [PlacedObject](#placedobject)
    - [Projectile](#projectile)
    - [Race](#race)
    - [Region](#region)
    - [Scroll](#scroll)
    - [Shout](#shout)
    - [SoulGem](#soulgem)
    - [SoundDescriptor](#sounddescriptor)
    - [SoundMarker](#soundmarker)
    - [Spell](#spell)
    - [Static](#static)
    - [TextureSet](#textureset)
    - [Tree](#tree)
    - [Weapon](#weapon)
    - [Worldspace](#worldspace)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# Link Interfaces
Link Interfaces are used by FormLinks to point to several record types at once.  For example, a Container record might be able to contain Armors, Weapons, Ingredients, etc.

An interface would be defined such as 'IItem', which all Armor, Weapon, Ingredients would all implement.

A `FormLink<IItem>` could then point to all those record types by pointing to the interface instead.
## Interfaces to Concrete Classes
### IAliasVoiceType
- FormList
- Npc
### IComplexLocation
- Cell
- Worldspace
### IConstructible
- AlchemicalApparatus
- Ammunition
- Armor
- Book
- Ingestible
- Ingredient
- Key
- Light
- MiscItem
- Scroll
- SoulGem
- Weapon
### IDialog
- DialogResponses
- DialogTopic
### IEffectRecord
- ObjectEffect
- Spell
### IEmittance
- Light
- Region
### IHarvestTarget
- Ingestible
- Ingredient
- LeveledItem
- MiscItem
### IIdleRelation
- ActionRecord
- IdleAnimation
### IItem
- AlchemicalApparatus
- Ammunition
- Armor
- Book
- Ingestible
- Ingredient
- Key
- LeveledItem
- Light
- MiscItem
- Scroll
- SoulGem
- Weapon
### IKeywordLinkedReference
- APlacedTrap
- Keyword
- PlacedNpc
- PlacedObject
### ILinkedReference
- APlacedTrap
- PlacedNpc
- PlacedObject
### ILocationRecord
- Location
- LocationReferenceType
### ILocationTargetable
- Door
- PlacedNpc
- PlacedObject
### ILockList
- FormList
- Npc
### INpcSpawn
- LeveledNpc
- Npc
### IObjectId
- Activator
- Ammunition
- Armor
- Book
- Container
- Door
- Faction
- FormList
- Furniture
- IdleMarker
- Ingestible
- Key
- Light
- MiscItem
- MoveableStatic
- Npc
- Projectile
- Scroll
- Shout
- SoundMarker
- Spell
- Static
- TextureSet
- Weapon
### IOutfitTarget
- Armor
- LeveledItem
### IOwner
- Faction
- PlacedNpc
### IPlaced
- APlaced
- APlacedTrap
- PlacedNpc
- PlacedObject
### IPlacedSimple
- PlacedNpc
- PlacedObject
### IPlacedThing
- APlacedTrap
- PlacedObject
### IPlacedTrapTarget
- Hazard
- Projectile
### IRegionTarget
- Flora
- LandscapeTexture
- MoveableStatic
- Static
- Tree
### IRelatable
- Faction
- Race
### ISound
- SoundDescriptor
- SoundMarker
### ISpellSpawn
- LeveledSpell
- Spell
## Concrete Classes to Interfaces
### ActionRecord
- IIdleRelation
### Activator
- IObjectId
### AlchemicalApparatus
- IConstructible
- IItem
### Ammunition
- IConstructible
- IItem
- IObjectId
### APlaced
- IPlaced
### APlacedTrap
- IKeywordLinkedReference
- ILinkedReference
- IPlaced
- IPlacedThing
### Armor
- IConstructible
- IItem
- IObjectId
- IOutfitTarget
### Book
- IConstructible
- IItem
- IObjectId
### Cell
- IComplexLocation
### Container
- IObjectId
### DialogResponses
- IDialog
### DialogTopic
- IDialog
### Door
- ILocationTargetable
- IObjectId
### Faction
- IObjectId
- IOwner
- IRelatable
### Flora
- IRegionTarget
### FormList
- IAliasVoiceType
- ILockList
- IObjectId
### Furniture
- IObjectId
### Hazard
- IPlacedTrapTarget
### IdleAnimation
- IIdleRelation
### IdleMarker
- IObjectId
### Ingestible
- IConstructible
- IHarvestTarget
- IItem
- IObjectId
### Ingredient
- IConstructible
- IHarvestTarget
- IItem
### Key
- IConstructible
- IItem
- IObjectId
### Keyword
- IKeywordLinkedReference
### LandscapeTexture
- IRegionTarget
### LeveledItem
- IHarvestTarget
- IItem
- IOutfitTarget
### LeveledNpc
- INpcSpawn
### LeveledSpell
- ISpellSpawn
### Light
- IConstructible
- IEmittance
- IItem
- IObjectId
### Location
- ILocationRecord
### LocationReferenceType
- ILocationRecord
### MiscItem
- IConstructible
- IHarvestTarget
- IItem
- IObjectId
### MoveableStatic
- IObjectId
- IRegionTarget
### Npc
- IAliasVoiceType
- ILockList
- INpcSpawn
- IObjectId
### ObjectEffect
- IEffectRecord
### PlacedNpc
- IKeywordLinkedReference
- ILinkedReference
- ILocationTargetable
- IOwner
- IPlaced
- IPlacedSimple
### PlacedObject
- IKeywordLinkedReference
- ILinkedReference
- ILocationTargetable
- IPlaced
- IPlacedSimple
- IPlacedThing
### Projectile
- IObjectId
- IPlacedTrapTarget
### Race
- IRelatable
### Region
- IEmittance
### Scroll
- IConstructible
- IItem
- IObjectId
### Shout
- IObjectId
### SoulGem
- IConstructible
- IItem
### SoundDescriptor
- ISound
### SoundMarker
- IObjectId
- ISound
### Spell
- IEffectRecord
- IObjectId
- ISpellSpawn
### Static
- IObjectId
- IRegionTarget
### TextureSet
- IObjectId
### Tree
- IRegionTarget
### Weapon
- IConstructible
- IItem
- IObjectId
### Worldspace
- IComplexLocation
