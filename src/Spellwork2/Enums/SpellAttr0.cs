using System;

namespace Spellwork2.Enums;

[Flags]
public enum SpellAttr0 : uint
{
    SPELL_ATTR0_PROC_FAILURE_BURNS_CHARGE                           = 0x00000001, // TITLE Proc Failure Burns Charge
    SPELL_ATTR0_USES_RANGED_SLOT                                    = 0x00000002, // TITLE Uses Ranged Slot DESCRIPTION Use ammo, ranged attack range modifiers, ranged haste, etc.
    SPELL_ATTR0_ON_NEXT_SWING_NO_DAMAGE                             = 0x00000004, // TITLE On Next Swing (No Damage) DESCRIPTION Both "on next swing" attributes have identical handling in server & client
    SPELL_ATTR0_DO_NOT_LOG_IMMUNE_MISSES                            = 0x00000008, // TITLE Do Not Log Immune Misses (client only)
    SPELL_ATTR0_IS_ABILITY                                          = 0x00000010, // TITLE Is Ability DESCRIPTION Cannot be reflected, not affected by cast speed modifiers, etc.
    SPELL_ATTR0_IS_TRADESKILL                                       = 0x00000020, // TITLE Is Tradeskill DESCRIPTION Displayed in recipe list, not affected by cast speed modifiers
    SPELL_ATTR0_PASSIVE                                             = 0x00000040, // TITLE Passive DESCRIPTION Spell is automatically cast on self by core
    SPELL_ATTR0_DO_NOT_DISPLAY_SPELLBOOK_AURA_ICON_COMBAT_LOG       = 0x00000080, // TITLE Do Not Display (Spellbook, Aura Icon, Combat Log) (client only) DESCRIPTION Not visible in spellbook or aura bar
    SPELL_ATTR0_DO_NOT_LOG                                          = 0x00000100, // TITLE Do Not Log (client only) DESCRIPTION Spell will not appear in combat logs
    SPELL_ATTR0_HELD_ITEM_ONLY                                      = 0x00000200, // TITLE Held Item Only (client only) DESCRIPTION Client will automatically select main-hand item as cast target
    SPELL_ATTR0_ON_NEXT_SWING                                       = 0x00000400, // TITLE On Next Swing DESCRIPTION Both "on next swing" attributes have identical handling in server & client
    SPELL_ATTR0_WEARER_CASTS_PROC_TRIGGER                           = 0x00000800, // TITLE Wearer Casts Proc Trigger DESCRIPTION Just a marker attribute to show auras that trigger another spell (either directly or with a script)
    SPELL_ATTR0_SERVER_ONLY                                         = 0x00001000, // TITLE Server Only
    SPELL_ATTR0_ALLOW_ITEM_SPELL_IN_PVP                             = 0x00002000, // TITLE Allow Item Spell In PvP
    SPELL_ATTR0_ONLY_INDOORS                                        = 0x00004000, // TITLE Only Indoors
    SPELL_ATTR0_ONLY_OUTDOORS                                       = 0x00008000, // TITLE Only Outdoors
    SPELL_ATTR0_NOT_SHAPESHIFTED                                    = 0x00010000, // TITLE Not Shapeshifted
    SPELL_ATTR0_ONLY_STEALTHED                                      = 0x00020000, // TITLE Only Stealthed
    SPELL_ATTR0_DO_NOT_SHEATH                                       = 0x00040000, // TITLE Do Not Sheath (client only)
    SPELL_ATTR0_SCALES_WITH_CREATURE_LEVEL                          = 0x00080000, // TITLE Scales w/ Creature Level DESCRIPTION For non-player casts, scale impact and power cost with caster's level
    SPELL_ATTR0_CANCELS_AUTO_ATTACK_COMBAT                          = 0x00100000, // TITLE Cancels Auto Attack Combat DESCRIPTION After casting this, the current auto-attack will be interrupted
    SPELL_ATTR0_NO_ACTIVE_DEFENSE                                   = 0x00200000, // TITLE No Active Defense DESCRIPTION Spell cannot be dodged, parried or blocked
    SPELL_ATTR0_TRACK_TARGET_IN_CAST_PLAYER_ONLY                    = 0x00400000, // TITLE Track Target in Cast (Player Only) (client only)
    SPELL_ATTR0_ALLOW_CAST_WHILE_DEAD                               = 0x00800000, // TITLE Allow Cast While Dead DESCRIPTION Spells without this flag cannot be cast by dead units in non-triggered contexts
    SPELL_ATTR0_ALLOW_WHILE_MOUNTED                                 = 0x01000000, // TITLE Allow While Mounted
    SPELL_ATTR0_COOLDOWN_ON_EVENT                                   = 0x02000000, // TITLE Cooldown On Event DESCRIPTION Spell is unusable while already active, and cooldown does not begin until the effects have worn off
    SPELL_ATTR0_AURA_IS_DEBUFF                                      = 0x04000000, // TITLE Aura Is Debuff DESCRIPTION Forces the spell to be treated as a negative spell
    SPELL_ATTR0_ALLOW_WHILE_SITTING                                 = 0x08000000, // TITLE Allow While Sitting
    SPELL_ATTR0_NOT_IN_COMBAT_ONLY_PEACEFUL                         = 0x10000000, // TITLE Not In Combat (Only Peaceful)
    SPELL_ATTR0_NO_IMMUNITIES                                       = 0x20000000, // TITLE No Immunities DESCRIPTION Allows spell to pierce invulnerability, unless the invulnerability spell also has this attribute
    SPELL_ATTR0_HEARTBEAT_RESIST                                    = 0x40000000, // TITLE Heartbeat Resist DESCRIPTION Periodically re-rolls against resistance to potentially expire aura early
    SPELL_ATTR0_NO_AURA_CANCEL                                      = 0x80000000  // TITLE No Aura Cancel DESCRIPTION Prevents the player from voluntarily canceling a positive aura
}
