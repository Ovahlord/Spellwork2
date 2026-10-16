using System;

namespace Spellwork2.Enums;

[Flags]
public enum SpellAttr14 : uint
{
    SPELL_ATTR14_UNK0                            = 0x00000001, // TITLE Unknown attribute 0@Attr14
    SPELL_ATTR14_REAGENT_COST_CONSUMES_CHARGES   = 0x00000002, // TITLE Reagent Consume Charges DESCRIPTION Consumes item charges for reagent costs instead of whole items
    SPELL_ATTR14_UNK2                            = 0x00000004, // TITLE Unknown attribute 2@Attr14
    SPELL_ATTR14_HIDE_PASSIVE_FROM_TOOLTIP       = 0x00000008, // TITLE Don't show "Passive" or "Upgrade" in tooltip
    SPELL_ATTR14_UNK4                            = 0x00000010, // TITLE Unknown attribute 4@Attr14
    SPELL_ATTR14_UNK5                            = 0x00000020, // TITLE Unknown attribute 5@Attr14
    SPELL_ATTR14_UNK6                            = 0x00000040, // TITLE Unknown attribute 6@Attr14
    SPELL_ATTR14_UNK7                            = 0x00000080, // TITLE Unknown attribute 7@Attr14
    SPELL_ATTR14_UNK8                            = 0x00000100, // TITLE Unknown attribute 8@Attr14
    SPELL_ATTR14_UNK9                            = 0x00000200, // TITLE Unknown attribute 9@Attr14
    SPELL_ATTR14_UNK10                           = 0x00000400, // TITLE Unknown attribute 10@Attr14
    SPELL_ATTR14_UNK11                           = 0x00000800, // TITLE Unknown attribute 11@Attr14
    SPELL_ATTR14_UNK12                           = 0x00001000, // TITLE Unknown attribute 12@Attr14
    SPELL_ATTR14_UNK13                           = 0x00002000, // TITLE Unknown attribute 13@Attr14
    SPELL_ATTR14_UNK14                           = 0x00004000, // TITLE Unknown attribute 14@Attr14
    SPELL_ATTR14_UNK15                           = 0x00008000, // TITLE Unknown attribute 15@Attr14
    SPELL_ATTR14_UNK16                           = 0x00010000, // TITLE Unknown attribute 16@Attr14
    SPELL_ATTR14_UNK17                           = 0x00020000, // TITLE Unknown attribute 17@Attr14
    SPELL_ATTR14_UNK18                           = 0x00040000, // TITLE Unknown attribute 18@Attr14
    SPELL_ATTR14_UNK19                           = 0x00080000, // TITLE Unknown attribute 19@Attr14
    SPELL_ATTR14_AURA_IS_PRIVATE                                        = 0x00100000, // TITLE Aura is private DESCRIPTION Clientside attribue that prevents the aura from being accessed by addons (but is still visible in UI)
    SPELL_ATTR14_UNK21                           = 0x00200000, // TITLE Unknown attribute 21@Attr14
    SPELL_ATTR14_UNK22                           = 0x00400000, // TITLE Unknown attribute 22@Attr14
    SPELL_ATTR14_UNK23                           = 0x00800000, // TITLE Unknown attribute 23@Attr14
    SPELL_ATTR14_UNK24                           = 0x01000000, // TITLE Unknown attribute 24@Attr14
    SPELL_ATTR14_UNK25                           = 0x02000000, // TITLE Unknown attribute 25@Attr14
    SPELL_ATTR14_UNK26                           = 0x04000000, // TITLE Unknown attribute 26@Attr14
    SPELL_ATTR14_UNK27                           = 0x08000000, // TITLE Unknown attribute 27@Attr14
    SPELL_ATTR14_UNK28                           = 0x10000000, // TITLE Unknown attribute 28@Attr14
    SPELL_ATTR14_UNK29                           = 0x20000000, // TITLE Unknown attribute 29@Attr14
    SPELL_ATTR14_UNK30                           = 0x40000000, // TITLE Unknown attribute 30@Attr14
    SPELL_ATTR14_UNK31                           = 0x80000000  // TITLE Unknown attribute 31@Attr14
}