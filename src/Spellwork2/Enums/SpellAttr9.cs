using System;

namespace Spellwork2.Enums;

[Flags]
public enum SpellAttr9 : uint
{
    SPELL_ATTR9_FORCE_DEST_LOCATION                                 = 0x00000001, // TITLE Force Dest Location DESCRIPTION Ignores collision with terrain (unsure if it also ignores terrain height and can go under map)
    SPELL_ATTR9_MOD_INVIS_INCLUDES_PARTY                            = 0x00000002, // TITLE Mod Invis Includes Party 1@Attr9 DESCRIPTION Causes invisibility auras to ignore "can always see party member invis" rule
    SPELL_ATTR9_ONLY_WHEN_ILLEGALLY_MOUNTED                         = 0x00000004, // TITLE Only When Illegally Mounted
    SPELL_ATTR9_DO_NOT_LOG_AURA_REFRESH                             = 0x00000008, // TITLE Do Not Log Aura Refresh (client only)
    SPELL_ATTR9_MISSILE_SPEED_IS_DELAY_IN_SEC                       = 0x00000010, // TITLE Missile Speed is Delay (in sec)
    SPELL_ATTR9_IGNORE_TOTEM_REQUIREMENTS_FOR_CASTING               = 0x00000020, // TITLE Ignore Totem Requirements for Casting
    SPELL_ATTR9_ITEM_CAST_GRANTS_SKILL_GAIN                         = 0x00000040, // TITLE Item Cast Grants Skill Gain
    SPELL_ATTR9_DO_NOT_ADD_TO_UNLEARN_LIST                          = 0x00000080, /* NYI - unlearn list not maintained SMSG_SEND_UNLEARN_SPELLS always empty */ // TITLE Do Not Add to Unlearn List
    SPELL_ATTR9_COOLDOWN_IGNORES_RANGED_WEAPON                      = 0x00000100, // TITLE Cooldown Ignores Ranged Weapon
    SPELL_ATTR9_NOT_IN_ARENA                                        = 0x00000200, // TITLE Not In Arena
    SPELL_ATTR9_TARGET_MUST_BE_GROUNDED                             = 0x00000400, // TITLE Target Must Be Grounded
    SPELL_ATTR9_ALLOW_WHILE_BANISHED_AURA_STATE                     = 0x00000800, // TITLE Allow While Banished Aura State DESCRIPTION Doesn't seem to be doing anything, banish behaves like a regular stun now - tested on patch 10.2.7 with spell 17767 (doesn't have this attribute, only SPELL_ATTR5_ALLOW_WHILE_STUNNED and was castable while banished)
    SPELL_ATTR9_FACE_UNIT_TARGET_UPON_COMPLETION_OF_JUMP_CHARGE     = 0x00001000, // TITLE Face unit target upon completion of jump charge
    SPELL_ATTR9_HASTE_AFFECTS_MELEE_ABILITY_CASTTIME                = 0x00002000, // TITLE Haste Affects Melee Ability Casttime
    SPELL_ATTR9_IGNORE_DEFAULT_RATED_BATTLEGROUND_RESTRICTIONS      = 0x00004000, // TITLE Ignore Default Rated Battleground Restrictions
    SPELL_ATTR9_DO_NOT_DISPLAY_POWER_COST                           = 0x00008000, // TITLE Do Not Display Power Cost (client only)
    SPELL_ATTR9_NEXT_MODAL_SPELL_REQUIRES_SAME_UNIT_TARGET          = 0x00010000, // TITLE Next modal spell requires same unit target DESCRIPTION Prevents automatically casting the spell from SpellClassOptions::ModalNextSpell after current spell if target was changed (client only)
    SPELL_ATTR9_AUTOCAST_OFF_BY_DEFAULT                             = 0x00020000, // TITLE AutoCast Off By Default
    SPELL_ATTR9_IGNORE_SCHOOL_LOCKOUT                               = 0x00040000, // TITLE Ignore School Lockout
    SPELL_ATTR9_ALLOW_DARK_SIMULACRUM                               = 0x00080000, // TITLE Allow Dark Simulacrum
    SPELL_ATTR9_ALLOW_CAST_WHILE_CHANNELING                         = 0x00100000, // TITLE Allow Cast While Channeling
    SPELL_ATTR9_SUPPRESS_VISUAL_KIT_ERRORS                          = 0x00200000, // TITLE Suppress Visual Kit Errors (client only)
    SPELL_ATTR9_SPELLCAST_OVERRIDE_IN_SPELLBOOK                     = 0x00400000, // TITLE Spellcast Override In Spellbook (client only)
    SPELL_ATTR9_JUMPCHARGE__NO_FACING_CONTROL                       = 0x00800000, // TITLE JumpCharge - no facing control
    SPELL_ATTR9_IGNORE_CASTER_HEALING_MODIFIERS                     = 0x01000000, // TITLE Ignore Caster Healing Modifiers
    SPELL_ATTR9_DONT_CONSUME_CHARGE_IF_ITEM_DELETED                 = 0x02000000, /*NYI - some sort of bugfix attribute to prevent double item deletion?*/ // TITLE (Programmer Only) Don't consume charge if item deleted
    SPELL_ATTR9_ITEM_PASSIVE_ON_CLIENT                              = 0x04000000, // TITLE Item Passive On Client
    SPELL_ATTR9_FORCE_CORPSE_TARGET                                 = 0x08000000, // TITLE Force Corpse Target DESCRIPTION Causes the spell to continue executing effects on the target even if one of them kills it
    SPELL_ATTR9_CANNOT_KILL_TARGET                                  = 0x10000000, // TITLE Cannot Kill Target
    SPELL_ATTR9_LOG_PASSIVE                                         = 0x20000000, // TITLE Log Passive (client only) DESCRIPTION Allows passive auras to trigger aura applied/refreshed/removed combat log events
    SPELL_ATTR9_NO_MOVEMENT_RADIUS_BONUS                            = 0x40000000, // TITLE No Movement Radius Bonus
    SPELL_ATTR9_CHANNEL_PERSISTS_ON_PET_FOLLOW                      = 0x80000000  // TITLE Channel Persists on Pet Follow
}
