using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Spellwork2.Enums;

namespace Spellwork2.ViewModels;

public partial class SpellInfoFilterViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial int SelectedSpellInfoAttribute { get; set; } = -1;
    
    [ObservableProperty]
    public partial int SelectedFilterOperator { get; set; } = -1;

    [ObservableProperty]
    public partial string? SelectedFilterValue { get; set; }

    [ObservableProperty] 
    public partial string[] FilterValues { get; set; } = [];
    
    public static string[] FilterOperators { get; } = 
    [
        //"==",
        //"!=",
        //">",
        //"<",
        //">=",
        //"<=",
        //"x&y != 0",
        "Contains"
    ];

    public static string[] SpellInfoAttributes { get; } =
    [
        "SpellEffect",
        "SpellAura",
        //"SpellAttr0",
        //"SpellAttr1",
        //"SpellAttr2",
        //"SpellAttr3",
        //"SpellAttr4",
        //"SpellAttr5",
        //"SpellAttr6",
        //"SpellAttr7",
        //"SpellAttr8",
        //"SpellAttr9",
        //"SpellAttr10",
        //"SpellAttr11",
        //"SpellAttr12",
        //"SpellAttr13",
        //"SpellAttr14",
        //"SpellAttr15",
        //"SpellInterruptFlags",
        //"AuraInterruptFlags0",
        //"AuraInterruptFlags1",
    ];

    private readonly MainViewModel _mainViewModel;

    public SpellInfoFilterViewModel()
    {
        _mainViewModel = new MainViewModel();
    }

    public SpellInfoFilterViewModel(MainViewModel parent)
    {
        _mainViewModel = parent;
    }

    partial void OnSelectedSpellInfoAttributeChanged(int value)
    {
        SelectedFilterValue = null;
        _mainViewModel.SpellInfoSource.RefreshFilter();

        if (value == -1)
        {
            FilterValues = [];
            return;
        }

        switch (SpellInfoAttributes[value])
        {
            case "SpellEffect":
                FilterValues = Enum.GetNames<SpellEffects>();
                break;
            case "SpellAura":
                FilterValues = Enum.GetNames<SpellAuras>();
                break;
            default:
                break;
        }
    }
    
    partial void OnSelectedFilterOperatorChanged(int value)
    {
        _mainViewModel.SpellInfoSource.RefreshFilter();
    }
    
    partial void OnSelectedFilterValueChanged(string? value)
    {
        _mainViewModel.SpellInfoSource.RefreshFilter();
    }

    
    public bool MatchesCriteria(SpellInfoViewModel spellInfo)
    {
        // Nothing has been selected yet or the selection is not complete yet
        if (SelectedFilterOperator == -1 || SelectedSpellInfoAttribute == -1 || string.IsNullOrWhiteSpace(SelectedFilterValue))
            return true;
        
        switch (SpellInfoAttributes[SelectedSpellInfoAttribute])
        {
            case "SpellEffect":
                switch (FilterOperators[SelectedFilterOperator])
                {
                    case "Contains":
                        return spellInfo.SpellEffects
                            .Any(effect => effect.EffectName.ToString().Equals(SelectedFilterValue));
                    default:
                        return false;
                }
            case "SpellAura":
                switch (FilterOperators[SelectedFilterOperator])
                {
                    case "Contains":
                        return spellInfo.SpellEffects
                            .Any(effect => effect.EffectAuraName.ToString().Equals(SelectedFilterValue));
                    default:
                        return false;
                }
            default:
                break;
        }
        
        return true;
    }
}