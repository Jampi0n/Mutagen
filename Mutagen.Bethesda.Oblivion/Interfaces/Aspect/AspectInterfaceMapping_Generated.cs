/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections.Generic;
using Mutagen.Bethesda.Plugins.Records.Mapping;
using Mutagen.Bethesda.Plugins.Aspects;
using Loqui;

namespace Mutagen.Bethesda.Oblivion
{
    internal class OblivionAspectInterfaceMapping : IInterfaceMapping
    {
        public IReadOnlyDictionary<Type, InterfaceMappingResult> InterfaceToObjectTypes { get; }

        public GameCategory GameCategory => GameCategory.Oblivion;

        public OblivionAspectInterfaceMapping()
        {
            var dict = new Dictionary<Type, InterfaceMappingResult>();
            dict[typeof(IModeled)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                Activator_Registration.Instance,
                AlchemicalApparatus_Registration.Instance,
                Ammunition_Registration.Instance,
                AnimatedObject_Registration.Instance,
                BodyData_Registration.Instance,
                Book_Registration.Instance,
                Climate_Registration.Instance,
                Container_Registration.Instance,
                Creature_Registration.Instance,
                Door_Registration.Instance,
                FacePart_Registration.Instance,
                Flora_Registration.Instance,
                Furniture_Registration.Instance,
                Grass_Registration.Instance,
                Hair_Registration.Instance,
                IdleAnimation_Registration.Instance,
                Ingredient_Registration.Instance,
                Key_Registration.Instance,
                Light_Registration.Instance,
                MagicEffect_Registration.Instance,
                Miscellaneous_Registration.Instance,
                Npc_Registration.Instance,
                Potion_Registration.Instance,
                SigilStone_Registration.Instance,
                SoulGem_Registration.Instance,
                Static_Registration.Instance,
                Tree_Registration.Instance,
                Weapon_Registration.Instance,
                Weather_Registration.Instance,
            });
            dict[typeof(IModeledGetter)] = dict[typeof(IModeled)] with { Setter = false };
            dict[typeof(INamed)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                Activator_Registration.Instance,
                AlchemicalApparatus_Registration.Instance,
                Ammunition_Registration.Instance,
                Armor_Registration.Instance,
                Birthsign_Registration.Instance,
                Book_Registration.Instance,
                Cell_Registration.Instance,
                Class_Registration.Instance,
                Clothing_Registration.Instance,
                Container_Registration.Instance,
                Creature_Registration.Instance,
                DialogTopic_Registration.Instance,
                Door_Registration.Instance,
                Enchantment_Registration.Instance,
                Eye_Registration.Instance,
                Faction_Registration.Instance,
                Flora_Registration.Instance,
                Furniture_Registration.Instance,
                Hair_Registration.Instance,
                Ingredient_Registration.Instance,
                Key_Registration.Instance,
                Light_Registration.Instance,
                LocalVariable_Registration.Instance,
                MagicEffect_Registration.Instance,
                MapMarker_Registration.Instance,
                Miscellaneous_Registration.Instance,
                Npc_Registration.Instance,
                Potion_Registration.Instance,
                Quest_Registration.Instance,
                Race_Registration.Instance,
                ScriptEffect_Registration.Instance,
                SigilStone_Registration.Instance,
                SoulGem_Registration.Instance,
                Spell_Registration.Instance,
                SpellLeveled_Registration.Instance,
                Weapon_Registration.Instance,
                Worldspace_Registration.Instance,
            });
            dict[typeof(INamedGetter)] = dict[typeof(INamed)] with { Setter = false };
            dict[typeof(INamedRequired)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                Activator_Registration.Instance,
                AlchemicalApparatus_Registration.Instance,
                Ammunition_Registration.Instance,
                Armor_Registration.Instance,
                Birthsign_Registration.Instance,
                Book_Registration.Instance,
                Cell_Registration.Instance,
                Class_Registration.Instance,
                Clothing_Registration.Instance,
                Container_Registration.Instance,
                Creature_Registration.Instance,
                DialogTopic_Registration.Instance,
                Door_Registration.Instance,
                Enchantment_Registration.Instance,
                Eye_Registration.Instance,
                Faction_Registration.Instance,
                Flora_Registration.Instance,
                Furniture_Registration.Instance,
                Hair_Registration.Instance,
                Ingredient_Registration.Instance,
                Key_Registration.Instance,
                Light_Registration.Instance,
                LocalVariable_Registration.Instance,
                MagicEffect_Registration.Instance,
                MapMarker_Registration.Instance,
                Miscellaneous_Registration.Instance,
                Npc_Registration.Instance,
                Potion_Registration.Instance,
                Quest_Registration.Instance,
                Race_Registration.Instance,
                ScriptEffect_Registration.Instance,
                SigilStone_Registration.Instance,
                SoulGem_Registration.Instance,
                Spell_Registration.Instance,
                SpellLeveled_Registration.Instance,
                Weapon_Registration.Instance,
                Worldspace_Registration.Instance,
            });
            dict[typeof(INamedRequiredGetter)] = dict[typeof(INamedRequired)] with { Setter = false };
            dict[typeof(IPositionRotation)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                Location_Registration.Instance,
                TeleportDestination_Registration.Instance,
            });
            dict[typeof(IPositionRotationGetter)] = dict[typeof(IPositionRotation)] with { Setter = false };
            dict[typeof(IWeightValue)] = new InterfaceMappingResult(true, new ILoquiRegistration[]
            {
                AlchemicalApparatusData_Registration.Instance,
                AmmunitionData_Registration.Instance,
                ArmorData_Registration.Instance,
                ClothingData_Registration.Instance,
                KeyData_Registration.Instance,
                LightData_Registration.Instance,
                SigilStoneData_Registration.Instance,
                SoulGemData_Registration.Instance,
                WeaponData_Registration.Instance,
            });
            dict[typeof(IWeightValueGetter)] = dict[typeof(IWeightValue)] with { Setter = false };
            InterfaceToObjectTypes = dict;
        }
    }
}

