using System;

namespace Spellwork2.Enums;

[Flags]
public enum SpellAttr12 : uint
{
    SPELL_ATTR12_ENABLE_PROCS_FROM_SUPPRESSED_CASTER_PROCS          = 0x00000001, // TITLE Enable Procs from Suppressed Caster Procs
    SPELL_ATTR12_CAN_PROC_FROM_SUPPRESSED_CASTER_PROCS              = 0x00000002, // TITLE Can Proc from Suppressed Caster Procs
    SPELL_ATTR12_UNK2                            = 0x00000004, // TITLE Unknown attribute 2@Attr12
    SPELL_ATTR12_UNK3                            = 0x00000008, // TITLE Unknown attribute 3@Attr12
    SPELL_ATTR12_UNK4                            = 0x00000010, // TITLE Unknown attribute 4@Attr12
    SPELL_ATTR12_UNK5                            = 0x00000020, // TITLE Unknown attribute 5@Attr12
    SPELL_ATTR12_UNK6                            = 0x00000040, // TITLE Unknown attribute 6@Attr12
    SPELL_ATTR12_UNK7                            = 0x00000080, // TITLE Unknown attribute 7@Attr12
    SPELL_ATTR12_UNK8                            = 0x00000100, // TITLE Unknown attribute 8@Attr12
    SPELL_ATTR12_IGNORE_CASTING_DISABLED         = 0x00000200, // TITLE Active Passive DESCRIPTION Ignores aura 263 SPELL_AURA_DISABLE_CASTING_EXCEPT_ABILITIES
    SPELL_ATTR12_UNK10                           = 0x00000400, // TITLE Unknown attribute 10@Attr12
    SPELL_ATTR12_UNK11                           = 0x00000800, // TITLE Unknown attribute 11@Attr12
    SPELL_ATTR12_UNK12                           = 0x00001000, // TITLE Unknown attribute 12@Attr12
    SPELL_ATTR12_UNK13                           = 0x00002000, // TITLE Unknown attribute 13@Attr12
    SPELL_ATTR12_UNK14                           = 0x00004000, // TITLE Unknown attribute 14@Attr12
    SPELL_ATTR12_UNK15                           = 0x00008000, // TITLE Unknown attribute 15@Attr12
    SPELL_ATTR12_UNK16                           = 0x00010000, // TITLE Unknown attribute 16@Attr12
    SPELL_ATTR12_UNK17                           = 0x00020000, // TITLE Unknown attribute 17@Attr12
    SPELL_ATTR12_UNK18                           = 0x00040000, // TITLE Unknown attribute 18@Attr12
    SPELL_ATTR12_UNK19                           = 0x00080000, // TITLE Unknown attribute 19@Attr12
    SPELL_ATTR12_UNK20                           = 0x00100000, // TITLE Unknown attribute 20@Attr12
    SPELL_ATTR12_USE_FLOAT_VALUES_FOR_SCALING_AMOUNTS               = 0x00200000, // TITLE Use float values for scaling amounts
    SPELL_ATTR12_UNK22                           = 0x00400000, // TITLE Unknown attribute 22@Attr12
    SPELL_ATTR12_START_COOLDOWN_ON_CAST_START    = 0x00800000, // TITLE Trigger Cooldown On Spell Start
    SPELL_ATTR12_IS_GARRISON_BUFF                = 0x01000000, // TITLE Never Learn
    SPELL_ATTR12_UNK25                           = 0x02000000, // TITLE Unknown attribute 25@Attr12
    SPELL_ATTR12_UNK26                           = 0x04000000, // TITLE Unknown attribute 26@Attr12
    SPELL_ATTR12_IS_READINESS_SPELL              = 0x08000000, // TITLE Recompute Aura on Mercenary Mode
    SPELL_ATTR12_UNK28                           = 0x10000000, // TITLE Unknown attribute 28@Attr12
    SPELL_ATTR12_UNK29                           = 0x20000000, // TITLE Unknown attribute 29@Attr12
    SPELL_ATTR12_UNK30                           = 0x40000000, // TITLE Unknown attribute 30@Attr12
    SPELL_ATTR12_ONLY_PROC_FROM_CLASS_ABILITIES                     = 0x80000000  // TITLE Only Proc From Class Abilities
}