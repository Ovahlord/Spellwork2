using System;

namespace Spellwork2.Enums;

[Flags]
public enum SpellAttr13 : uint
{
    SPELL_ATTR13_ALLOW_CLASS_ABILITY_PROCS       = 0x00000001, // TITLE Allow Class Ability Procs
    SPELL_ATTR13_UNK1                            = 0x00000002, // TITLE Unknown attribute 0@Attr13
    SPELL_ATTR13_PASSIVE_IS_UPGRADE              = 0x00000004, // TITLE Is Upgrade DESCRIPTION Displays "Upgrade" in spell tooltip instead of "Passive"
    SPELL_ATTR13_UNK3                            = 0x00000008, // TITLE Unknown attribute 3@Attr13
    SPELL_ATTR13_UNK4                            = 0x00000010, // TITLE Unknown attribute 4@Attr13
    SPELL_ATTR13_UNK5                            = 0x00000020, // TITLE Unknown attribute 5@Attr13
    SPELL_ATTR13_UNK6                            = 0x00000040, // TITLE Unknown attribute 6@Attr13
    SPELL_ATTR13_UNK7                            = 0x00000080, // TITLE Unknown attribute 7@Attr13
    SPELL_ATTR13_UNK8                            = 0x00000100, // TITLE Unknown attribute 8@Attr13
    SPELL_ATTR13_UNK9                            = 0x00000200, // TITLE Unknown attribute 9@Attr13
    SPELL_ATTR13_UNK10                           = 0x00000400, // TITLE Unknown attribute 10@Attr13
    SPELL_ATTR13_UNK11                           = 0x00000800, // TITLE Unknown attribute 11@Attr13
    SPELL_ATTR13_UNK12                           = 0x00001000, // TITLE Unknown attribute 12@Attr13
    SPELL_ATTR13_UNK13                           = 0x00002000, // TITLE Unknown attribute 13@Attr13
    SPELL_ATTR13_UNK14                           = 0x00004000, // TITLE Unknown attribute 14@Attr13
    SPELL_ATTR13_DO_NOT_FAIL_IF_NO_TARGET                           = 0x00008000, // TITLE Do Not Fail if No Target
    SPELL_ATTR13_UNK16                           = 0x00010000, // TITLE Unknown attribute 16@Attr13
    SPELL_ATTR13_UNK17                           = 0x00020000, // TITLE Unknown attribute 17@Attr13
    SPELL_ATTR13_ACTIVATES_REQUIRED_SHAPESHIFT   = 0x00040000, // TITLE Do Not Enforce Shapeshift Requirements
    SPELL_ATTR13_UNK19                           = 0x00080000, // TITLE Unknown attribute 19@Attr13
    SPELL_ATTR13_PERIODIC_REFRESH_EXTENDS_DURATION = 0x00100000, // TITLE Periodic Refresh Extends Duration
    SPELL_ATTR13_UNK21                           = 0x00200000, // TITLE Unknown attribute 21@Attr13
    SPELL_ATTR13_UNK22                           = 0x00400000, // TITLE Unknown attribute 22@Attr13
    SPELL_ATTR13_UNK23                           = 0x00800000, // TITLE Unknown attribute 23@Attr13
    SPELL_ATTR13_UNK24                           = 0x01000000, // TITLE Unknown attribute 24@Attr13
    SPELL_ATTR13_UNK25                           = 0x02000000, // TITLE Unknown attribute 25@Attr13
    SPELL_ATTR13_ALWAYS_ALLOW_NEGATIVE_HEALING_PERCENT_MODIFIERS    = 0x04000000, // TITLE Always Allow Negative Healing Percent Modifiers
    SPELL_ATTR13_DO_NOT_ALLOW_DISABLE_MOVEMENT_INTERRUPT            = 0x08000000, // TITLE Do Not Allow "Disable Movement Interrupt"
    SPELL_ATTR13_UNK28                           = 0x10000000, // TITLE Unknown attribute 28@Attr13
    SPELL_ATTR13_UNK29                           = 0x20000000, // TITLE Unknown attribute 29@Attr13
    SPELL_ATTR13_UNK30                           = 0x40000000, // TITLE Unknown attribute 30@Attr13
    SPELL_ATTR13_UNK31                           = 0x80000000  // TITLE Unknown attribute 31@Attr13
}
