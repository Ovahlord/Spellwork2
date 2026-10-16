using System;

namespace Spellwork2.Enums;

[Flags]
public enum SpellAttr1 : uint
{
    SPELL_ATTR1_DISMISS_PET_FIRST                                   = 0x00000001, // TITLE Dismiss Pet First DESCRIPTION Without this attribute, summoning spells will fail if caster already has a pet
    SPELL_ATTR1_USE_ALL_MANA                                        = 0x00000002, // TITLE Use All Mana DESCRIPTION Ignores listed power cost and drains entire pool instead
    SPELL_ATTR1_IS_CHANNELLED                                       = 0x00000004, // TITLE Is Channelled DESCRIPTION Both "channeled" attributes have identical handling in server & client
    SPELL_ATTR1_NO_REDIRECTION                                      = 0x00000008, // TITLE No Redirection DESCRIPTION Spell will not be attracted by SPELL_MAGNET auras (Grounding Totem)
    SPELL_ATTR1_NO_SKILL_INCREASE                                   = 0x00000010, // TITLE No Skill Increase
    SPELL_ATTR1_ALLOW_WHILE_STEALTHED                               = 0x00000020, // TITLE Allow While Stealthed
    SPELL_ATTR1_IS_SELF_CHANNELLED                                  = 0x00000040, // TITLE Is Self Channelled DESCRIPTION Both "channeled" attributes have identical handling in server & client
    SPELL_ATTR1_NO_REFLECTION                                       = 0x00000080, // TITLE No Reflection DESCRIPTION Spell will pierce through Spell Reflection and similar
    SPELL_ATTR1_ONLY_PEACEFUL_TARGETS                               = 0x00000100, // TITLE Only Peaceful Targets DESCRIPTION Target cannot be in combat
    SPELL_ATTR1_INITIATES_COMBAT_ENABLES_AUTO_ATTACK                = 0x00000200, // TITLE Initiates Combat (Enables Auto-Attack) (client only) DESCRIPTION Caster will begin auto-attacking the target on cast
    SPELL_ATTR1_NO_THREAT                                           = 0x00000400, // TITLE No Threat DESCRIPTION Also does not cause target to engage
    SPELL_ATTR1_AURA_UNIQUE                                         = 0x00000800, // TITLE Aura Unique DESCRIPTION Aura will not refresh its duration when recast
    SPELL_ATTR1_FAILURE_BREAKS_STEALTH                              = 0x00001000, // TITLE Failure Breaks Stealth
    SPELL_ATTR1_TOGGLE_FAR_SIGHT                                    = 0x00002000, // TITLE Toggle Far Sight (client only)
    SPELL_ATTR1_TRACK_TARGET_IN_CHANNEL                             = 0x00004000, // TITLE Track Target in Channel DESCRIPTION While channeling, adjust facing to face target
    SPELL_ATTR1_IMMUNITY_PURGES_EFFECT                              = 0x00008000, // TITLE Immunity Purges Effect DESCRIPTION For immunity spells, cancel all auras that this spell would make you immune to when the spell is applied
    SPELL_ATTR1_IMMUNITY_TO_HOSTILE_AND_FRIENDLY_EFFECTS            = 0x00010000, // TITLE Immunity to Hostile & Friendly Effects DESCRIPTION Immunity applied by this aura will also be checked for friendly spells (school immunity only) - used by Cyclone for example to cause friendly spells and healing over time to be immuned
    SPELL_ATTR1_NO_AUTOCAST_AI                                      = 0x00020000, // TITLE No AutoCast (AI)
    SPELL_ATTR1_PREVENTS_ANIM                                       = 0x00040000, /*NYI*/ // TITLE Prevents Anim DESCRIPTION Auras apply UNIT_FLAG_PREVENT_EMOTES_FROM_CHAT_TEXT
    SPELL_ATTR1_EXCLUDE_CASTER                                      = 0x00080000, // TITLE Exclude Caster
    SPELL_ATTR1_FINISHING_MOVE_DAMAGE                               = 0x00100000, // TITLE Finishing Move - Damage
    SPELL_ATTR1_THREAT_ONLY_ON_MISS                                 = 0x00200000, /*NYI*/ // TITLE Threat only on Miss
    SPELL_ATTR1_FINISHING_MOVE_DURATION                             = 0x00400000, // TITLE Finishing Move - Duration
    SPELL_ATTR1_IGNORE_OWNERS_DEATH                                 = 0x00800000, /*NYI*/ // TITLE Ignore Owner's Death
    SPELL_ATTR1_SPECIAL_SKILLUP                                     = 0x01000000, // TITLE Special Skillup
    SPELL_ATTR1_AURA_STAYS_AFTER_COMBAT                             = 0x02000000, // TITLE Aura Stays After Combat
    SPELL_ATTR1_REQUIRE_ALL_TARGETS                                 = 0x04000000, // TITLE Require All Targets
    SPELL_ATTR1_DISCOUNT_POWER_ON_MISS                              = 0x08000000, // TITLE Discount Power On Miss
    SPELL_ATTR1_NO_AURA_ICON                                        = 0x10000000, // TITLE No Aura Icon (client only)
    SPELL_ATTR1_NAME_IN_CHANNEL_BAR                                 = 0x20000000, // TITLE Name in Channel Bar (client only)
    SPELL_ATTR1_DISPEL_ALL_STACKS                                   = 0x40000000, // TITLE Dispel All Stacks
    SPELL_ATTR1_CAST_WHEN_LEARNED                                   = 0x80000000  // TITLE Cast When Learned
}
