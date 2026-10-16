using System;

namespace Spellwork2.Enums;

[Flags]
public enum SpellSchoolMasks
{
    SPELL_SCHOOL_MASK_NONE    = 0x00,                       // not exist
    SPELL_SCHOOL_MASK_NORMAL  = (1 << SpellSchools.SPELL_SCHOOL_NORMAL ), // PHYSICAL (Armor)
    SPELL_SCHOOL_MASK_HOLY    = (1 << SpellSchools.SPELL_SCHOOL_HOLY),
    SPELL_SCHOOL_MASK_FIRE    = (1 << SpellSchools.SPELL_SCHOOL_FIRE),
    SPELL_SCHOOL_MASK_NATURE  = (1 << SpellSchools.SPELL_SCHOOL_NATURE),
    SPELL_SCHOOL_MASK_FROST   = (1 << SpellSchools.SPELL_SCHOOL_FROST),
    SPELL_SCHOOL_MASK_SHADOW  = (1 << SpellSchools.SPELL_SCHOOL_SHADOW),
    SPELL_SCHOOL_MASK_ARCANE  = (1 << SpellSchools.SPELL_SCHOOL_ARCANE),
    
    
}