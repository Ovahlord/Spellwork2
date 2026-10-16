namespace Spellwork2.Enums;

public enum SpellAttr11 : uint
{
    SPELL_ATTR11_UNK0                            = 0x00000001, // TITLE Unknown attribute 0@Attr11
    SPELL_ATTR11_UNK1                            = 0x00000002, // TITLE Unknown attribute 1@Attr11
    SPELL_ATTR11_SCALES_WITH_ITEM_LEVEL          = 0x00000004, // TITLE Scales with Casting Item's Level
    SPELL_ATTR11_UNK3                            = 0x00000008, // TITLE Unknown attribute 3@Attr11
    SPELL_ATTR11_UNK4                            = 0x00000010, // TITLE Unknown attribute 4@Attr11
    SPELL_ATTR11_ABSORB_ENVIRONMENTAL_DAMAGE     = 0x00000020, // TITLE Absorb Falling Damage
    SPELL_ATTR11_UNK6                            = 0x00000040, // TITLE Unknown attribute 6@Attr11
    SPELL_ATTR11_RANK_IGNORES_CASTER_LEVEL       = 0x00000080, // TITLE Ignore Caster's spell level DESCRIPTION Spell_C_GetSpellRank returns SpellLevels->MaxLevel * 5 instead of std::min(SpellLevels->MaxLevel, caster->Level) * 5
    SPELL_ATTR11_UNK8                            = 0x00000100, // TITLE Unknown attribute 8@Attr11
    SPELL_ATTR11_IGNORE_SPELLCAST_OVERRIDE_SHAPESHIFT_REQUIREMENTS  = 0x00000200, // TITLE Ignore Spellcast Override Shapeshift Requirements
    SPELL_ATTR11_UNK10                           = 0x00000400, // TITLE Unknown attribute 10@Attr11
    SPELL_ATTR11_NOT_USABLE_IN_INSTANCES         = 0x00000800, // TITLE Not in Instances
    SPELL_ATTR11_UNK12                           = 0x00001000, // TITLE Unknown attribute 12@Attr11
    SPELL_ATTR11_UNK13                           = 0x00002000, // TITLE Unknown attribute 13@Attr11
    SPELL_ATTR11_CAN_ASSIST_UNINTERACTIBLE                          = 0x00004000, // TITLE Can Assist Uninteractible
    SPELL_ATTR11_UNK15                           = 0x00008000, // TITLE Unknown attribute 15@Attr11
    SPELL_ATTR11_NOT_USABLE_IN_CHALLENGE_MODE    = 0x00010000, // TITLE Not in Mythic+ Mode (Challenge Mode)
    SPELL_ATTR11_UNK17                           = 0x00020000, // TITLE Unknown attribute 17@Attr11
    SPELL_ATTR11_IGNORE_CASTER_ABSORB_MODIFIERS                     = 0x00040000, // TITLE Ignore Caster Absorb Modifiers
    SPELL_ATTR11_IGNORE_TARGET_ABSORB_MODIFIERS                     = 0x00080000, // TITLE Ignore Target Absorb Modifiers
    SPELL_ATTR11_UNK20                           = 0x00100000, // TITLE Unknown attribute 20@Attr11
    SPELL_ATTR11_UNK21                           = 0x00200000, // TITLE Unknown attribute 21@Attr11
    SPELL_ATTR11_UNK22                           = 0x00400000, // TITLE Unknown attribute 22@Attr11
    SPELL_ATTR11_UNK23                           = 0x00800000, // TITLE Unknown attribute 23@Attr11
    SPELL_ATTR11_UNK24                           = 0x01000000, // TITLE Unknown attribute 24@Attr11
    SPELL_ATTR11_UNK25                           = 0x02000000, // TITLE Unknown attribute 25@Attr11
    SPELL_ATTR11_UNK26                           = 0x04000000, // TITLE Unknown attribute 26@Attr11
    SPELL_ATTR11_UNK27                           = 0x08000000, // TITLE Unknown attribute 27@Attr11
    SPELL_ATTR11_UNK28                           = 0x10000000, // TITLE Unknown attribute 28@Attr11
    SPELL_ATTR11_UNK29                           = 0x20000000, // TITLE Unknown attribute 29@Attr11
    SPELL_ATTR11_UNK30                           = 0x40000000, // TITLE Unknown attribute 30@Attr11
    SPELL_ATTR11_UNK31                           = 0x80000000  // TITLE Unknown attribute 31@Attr11
}