using System;

namespace Spellwork2.Enums;

[Flags]
public enum SpellAttr3 : uint
{
    SPELL_ATTR3_PVP_ENABLING                                        = 0x00000001, // TITLE PvP Enabling
    SPELL_ATTR3_NO_PROC_EQUIP_REQUIREMENT                           = 0x00000002, // TITLE No Proc Equip Requirement DESCRIPTION Ignores subclass mask check when checking proc
    SPELL_ATTR3_NO_CASTING_BAR_TEXT                                 = 0x00000004, // TITLE No Casting Bar Text
    SPELL_ATTR3_COMPLETELY_BLOCKED                                  = 0x00000008, // TITLE Completely Blocked
    SPELL_ATTR3_NO_RES_TIMER                                        = 0x00000010, // TITLE No Res Timer
    SPELL_ATTR3_NO_DURABILITY_LOSS                                  = 0x00000020, // TITLE No Durability Loss
    SPELL_ATTR3_NO_AVOIDANCE                                        = 0x00000040, // TITLE No Avoidance
    SPELL_ATTR3_DOT_STACKING_RULE                                   = 0x00000080, // TITLE DoT Stacking Rule DESCRIPTION Stack separately for each caster
    SPELL_ATTR3_ONLY_ON_PLAYER                                      = 0x00000100, // TITLE Only On Player
    SPELL_ATTR3_NOT_A_PROC                                          = 0x00000200, // TITLE Not a Proc DESCRIPTION Without this attribute, any triggered spell will be unable to trigger other auras' procs
    SPELL_ATTR3_REQUIRES_MAIN_HAND_WEAPON                           = 0x00000400, // TITLE Requires Main-Hand Weapon
    SPELL_ATTR3_ONLY_BATTLEGROUNDS                                  = 0x00000800, // TITLE Only Battlegrounds
    SPELL_ATTR3_ONLY_ON_GHOSTS                                      = 0x00001000, // TITLE Only On Ghosts
    SPELL_ATTR3_HIDE_CHANNEL_BAR                                    = 0x00002000, // TITLE Hide Channel Bar (client only)
    SPELL_ATTR3_HIDE_IN_RAID_FILTER                                 = 0x00004000, // TITLE Hide In Raid Filter (client only)
    SPELL_ATTR3_NORMAL_RANGED_ATTACK                                = 0x00008000, // TITLE Normal Ranged Attack DESCRIPTION Auto Shoot, Shoot, Throw - ranged normal attack attribute?
    SPELL_ATTR3_SUPPRESS_CASTER_PROCS                               = 0x00010000, // TITLE Suppress Caster Procs
    SPELL_ATTR3_SUPPRESS_TARGET_PROCS                               = 0x00020000, // TITLE Suppress Target Procs
    SPELL_ATTR3_ALWAYS_HIT                                          = 0x00040000, // TITLE Always Hit DESCRIPTION Spell cannot miss, or be dodged/parried/blocked
    SPELL_ATTR3_INSTANT_TARGET_PROCS                                = 0x00080000, // TITLE Instant Target Procs DESCRIPTION Proc events are triggered before spell batching processes the spell hit on target
    SPELL_ATTR3_ALLOW_AURA_WHILE_DEAD                               = 0x00100000, // TITLE Allow Aura While Dead
    SPELL_ATTR3_ONLY_PROC_OUTDOORS                                  = 0x00200000, // TITLE Only Proc Outdoors
    SPELL_ATTR3_DO_NOT_TRIGGER_TARGET_STAND                         = 0x00400000, // TITLE Do Not Trigger Target Stand
    SPELL_ATTR3_NO_DAMAGE_HISTORY                                   = 0x00800000, /*NYI, no damage history implementation*/ // TITLE No Damage History
    SPELL_ATTR3_REQUIRES_OFF_HAND_WEAPON                            = 0x01000000, // TITLE Requires Off-Hand Weapon
    SPELL_ATTR3_TREAT_AS_PERIODIC                                   = 0x02000000, // TITLE Treat As Periodic
    SPELL_ATTR3_CAN_PROC_FROM_PROCS                                 = 0x04000000, // TITLE Can Proc From Procs
    SPELL_ATTR3_ONLY_PROC_ON_CASTER                                 = 0x08000000, // TITLE Only Proc on Caster
    SPELL_ATTR3_IGNORE_CASTER_AND_TARGET_RESTRICTIONS               = 0x10000000, /*NYI*/ // TITLE Ignore Caster & Target Restrictions
    SPELL_ATTR3_IGNORE_CASTER_MODIFIERS                             = 0x20000000, // TITLE Ignore Caster Modifiers
    SPELL_ATTR3_DO_NOT_DISPLAY_RANGE                                = 0x40000000, // TITLE Do Not Display Range (client only)
    SPELL_ATTR3_NOT_ON_AOE_IMMUNE                                   = 0x80000000  // TITLE Not On AOE Immune
}