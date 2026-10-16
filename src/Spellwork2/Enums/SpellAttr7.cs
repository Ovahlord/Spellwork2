using System;

namespace Spellwork2.Enums;

[Flags]
public enum SpellAttr7 : uint
{
    SPELL_ATTR7_ALLOW_SPELL_REFLECTION                              = 0x00000001, // TITLE Allow Spell Reflection
    SPELL_ATTR7_NO_TARGET_DURATION_MOD                              = 0x00000002, // TITLE No Target Duration Mod
    SPELL_ATTR7_DISABLE_AURA_WHILE_DEAD                             = 0x00000004, // TITLE Disable Aura While Dead
    SPELL_ATTR7_DEBUG_SPELL                                         = 0x00000008, // TITLE Debug Spell DESCRIPTION Cannot cast if caster doesn't have UnitFlag2 & UNIT_FLAG2_ALLOW_CHEAT_SPELLS
    SPELL_ATTR7_TREAT_AS_RAID_BUFF                                  = 0x00000010, /*NYI*/ // TITLE Treat as Raid Buff
    SPELL_ATTR7_CAN_BE_MULTI_CAST                                   = 0x00000020, // TITLE Can Be Multi Cast
    SPELL_ATTR7_DONT_CAUSE_SPELL_PUSHBACK                           = 0x00000040, // TITLE Don't Cause Spell Pushback DESCRIPTION Damage dealt by this does not cause spell pushback
    SPELL_ATTR7_PREPARE_FOR_VEHICLE_CONTROL_END                     = 0x00000080, /*NYI*/ // TITLE Prepare for Vehicle Control End
    SPELL_ATTR7_HORDE_SPECIFIC_SPELL                                = 0x00000100, /*NYI*/ // TITLE Horde Specific Spell
    SPELL_ATTR7_ALLIANCE_SPECIFIC_SPELL                             = 0x00000200, /*NYI*/ // TITLE Alliance Specific Spell
    SPELL_ATTR7_DISPEL_REMOVES_CHARGES                              = 0x00000400, // TITLE Dispel Removes Charges DESCRIPTION Dispel/Spellsteal remove individual charges
    SPELL_ATTR7_CAN_CAUSE_INTERRUPT                                 = 0x00000800, // TITLE Can Cause Interrupt DESCRIPTION Only interrupt non-player casting
    SPELL_ATTR7_CAN_CAUSE_SILENCE                                   = 0x00001000, /*NYI*/ // TITLE Can Cause Silence
    SPELL_ATTR7_NO_UI_NOT_INTERRUPTIBLE                             = 0x00002000, // TITLE No UI Not Interruptible DESCRIPTION Can always be interrupted, even if caster is immune
    SPELL_ATTR7_RECAST_ON_RESUMMON                                  = 0x00004000, /*NYI - deprecated attribute, there is no SPELL_GO sent anymore on pet resummon*/ // TITLE Recast On Resummon
    SPELL_ATTR7_RESET_SWING_TIMER_AT_SPELL_START                    = 0x00008000, // TITLE Reset Swing Timer at spell start
    SPELL_ATTR7_ONLY_IN_SPELLBOOK_UNTIL_LEARNED                     = 0x00010000, // TITLE Only In Spellbook Until Learned DESCRIPTION After learning these spells become hidden in spellbook (but are visible when not learned for low level characters)
    SPELL_ATTR7_DO_NOT_LOG_PVP_KILL                                 = 0x00020000, /*NYI, only used by 1 spell that is already filtered out in pvp credits because its self targeting*/ // TITLE Do Not Log PvP Kill
    SPELL_ATTR7_ATTACK_ON_CHARGE_TO_UNIT                            = 0x00040000, // TITLE Attack on Charge to Unit
    SPELL_ATTR7_REPORT_SPELL_FAILURE_TO_UNIT_TARGET                 = 0x00080000, // TITLE Report Spell failure to unit target
    SPELL_ATTR7_NO_CLIENT_FAIL_WHILE_STUNNED_FLEEING_CONFUSED       = 0x00100000, // TITLE No Client Fail While Stunned, Fleeing, Confused DESCRIPTION Clientside - skips stunned/fleeing/confused checks
    SPELL_ATTR7_RETAIN_COOLDOWN_THROUGH_LOAD                        = 0x00200000, /*NYI*/ // TITLE Retain Cooldown Through Load
    SPELL_ATTR7_IGNORES_COLD_WEATHER_FLYING_REQUIREMENT             = 0x00400000, /*NYI - deprecated attribute*/ // TITLE Ignores Cold Weather Flying Requirement
    SPELL_ATTR7_NO_ATTACK_DODGE                                     = 0x00800000, // TITLE No Attack Dodge
    SPELL_ATTR7_NO_ATTACK_PARRY                                     = 0x01000000, // TITLE No Attack Parry
    SPELL_ATTR7_NO_ATTACK_MISS                                      = 0x02000000, // TITLE No Attack Miss
    SPELL_ATTR7_TREAT_AS_NPC_AOE                                    = 0x04000000, // TITLE Treat as NPC AoE
    SPELL_ATTR7_BYPASS_NO_RESURRECT_AURA                            = 0x08000000, // TITLE Bypass No Resurrect Aura
    SPELL_ATTR7_DO_NOT_COUNT_FOR_PVP_SCOREBOARD                     = 0x10000000, // TITLE Do Not Count For PvP Scoreboard
    SPELL_ATTR7_REFLECTION_ONLY_DEFENDS                             = 0x20000000, // TITLE Reflection Only Defends
    SPELL_ATTR7_CAN_PROC_FROM_SUPPRESSED_TARGET_PROCS               = 0x40000000, // TITLE Can Proc From Suppressed Target Procs
    SPELL_ATTR7_ALWAYS_CAST_LOG                                     = 0x80000000  // TITLE Always Cast Log
}