namespace Spellwork2.ViewModels;

public class SpellInfoFilterViewModel : ViewModelBase
{
    public static string[] FilterOperators { get; } = 
    [
        "==",
        "!=",
        ">",
        "<",
        ">=",
        "<=",
        "x&y != 0",
        "Contains"
    ];

    public static string[] SpellInfoAttributes { get; } =
    [
        "Spell Effect Type",
        "Spell Aura Type",
        "SpellAttr0",
        "SpellAttr1",
        "SpellAttr2",
        "SpellAttr3",
        "SpellAttr4",
        "SpellAttr5",
        "SpellAttr6",
        "SpellAttr7",
        "SpellAttr8",
        "SpellAttr9",
        "SpellAttr10",
        "SpellAttr11",
        "SpellAttr12",
        "SpellAttr13",
        "SpellAttr14",
        "SpellAttr15",
        "SpellInterruptFlags",
        "AuraInterruptFlags0",
        "AuraInterruptFlags1",
    ];
}