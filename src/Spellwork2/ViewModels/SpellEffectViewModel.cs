using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using DBCD;
using Spellwork2.DBC;
using Spellwork2.Enums;

namespace Spellwork2.ViewModels;

public partial class SpellEffectViewModel : ViewModelBase
{
    // Record accessors
    public int EffectIndex =>_spellEffectEntry?.FieldAs<int>("EffectIndex") ?? 0;
    public int Effect => _spellEffectEntry?.FieldAs<int>("Effect") ?? 0;
    public int EffectAura => _spellEffectEntry?.FieldAs<int>("EffectAura") ?? 0;
    public int Period => _spellEffectEntry?.FieldAs<int>("EffectAuraPeriod") ?? 0;
    public int TriggerSpell => _spellEffectEntry?.FieldAs<int>("EffectTriggerSpell") ?? 0;
    public float Variance => _spellEffectEntry?.FieldAs<float>("Variance") ?? 0f;
    public int EffectItemType => _spellEffectEntry?.FieldAs<int>("EffectItemType") ?? 0;
    
    // Convenience properties
    public SpellEffects EffectName => (SpellEffects)Effect;
    public SpellAuras EffectAuraName => (SpellAuras)EffectAura;
    public bool HasAura => EffectAuraName != SpellAuras.SPELL_AURA_NONE;
    public bool HasTriggerSpell => TriggerSpell > 0;
    public bool CreatesItem => EffectItemType > 0 && EffectName == SpellEffects.SPELL_EFFECT_CREATE_ITEM;
    public string ItemTypeName => DbcMgr.ItemNamesByItemId.GetValueOrDefault(EffectItemType, string.Empty);
    
    // Post-processing data
    public float BasePoints { get; init; }
    public int DieSides { get; init; }
    public int[] EffectMiscValues { get; init; } = [0, 0];
    public string RadiusA { get; init; } = string.Empty;
    public string RadiusB { get; init; } = string.Empty;
    public string TriggerSpellName { get; init; } = string.Empty;
    public ImplicitTargets ImplicitTargetA { get; init; }
    public ImplicitTargets ImplicitTargetB { get; init; }
    public string MiscValueAInfo { get; private set; } = string.Empty;
    public string MiscValueBInfo { get; private set; } = string.Empty;
    
    private readonly DBCDRow? _spellEffectEntry;
    public SpellInfoViewModel SpellInfoViewModel { get; init; }
    
    public SpellEffectViewModel()
    {
        SpellInfoViewModel = new SpellInfoViewModel();
    }
    
    public SpellEffectViewModel(DBCDRow spellEffectEntry, SpellInfoViewModel parent)
    {
        _spellEffectEntry = spellEffectEntry;
        SpellInfoViewModel = parent;
        
        if (TriggerSpell > 0 && DbcMgr.SpellNameStore != null)
        {
            if (DbcMgr.SpellNameStore.TryGetValue(TriggerSpell, out DBCDRow? spellNameEntry))
                TriggerSpellName = (string)spellNameEntry["Name_lang"];
            else
                TriggerSpellName = "Unknown Spell (removed or serverside)";
        }

        // Initialize misc values
        if (_spellEffectEntry["EffectMiscValue"] is int[] miscValues)
            EffectMiscValues = miscValues;

        // Initialize effect targets
        if (_spellEffectEntry["ImplicitTarget"] is short[] targets)
        {
            ImplicitTargetA = (ImplicitTargets)targets[0];
            ImplicitTargetB = (ImplicitTargets)targets[1];
        }

        // Initialize effect radius
        if (DbcMgr.SpellRadiusStore != null)
        {
            if (_spellEffectEntry["EffectRadiusIndex"] is uint[] radiusIndexes)
            {
                if (radiusIndexes[0] > 0 && ImplicitTargetA != ImplicitTargets.NONE)
                    if (DbcMgr.SpellRadiusStore.TryGetValue((int)radiusIndexes[0], out DBCDRow? radius))
                        RadiusA = $" (MinRadius: {(float)radius["RadiusMin"]} - MaxRadius: {(float)radius["RadiusMax"]})";
                
                if (radiusIndexes[1] > 0 && ImplicitTargetB != ImplicitTargets.NONE)
                    if (DbcMgr.SpellRadiusStore.TryGetValue((int)radiusIndexes[1], out DBCDRow? radius))
                        RadiusB = $" (MinRadius: {(float)radius["RadiusMin"]} - MaxRadius {(float)radius["RadiusMax"]})";
            }
        }

        try
        {
            BasePoints = Convert.ToSingle(_spellEffectEntry["EffectBasePoints"]);
        }
        catch (Exception) // Newer client versions store BasePoints as float instead of int
        {
            BasePoints = Convert.ToSingle(_spellEffectEntry["EffectBasePointsF"]);
        }
        
        try
        {
            // DieSides exist only in classic varians
            DieSides = Convert.ToInt32(_spellEffectEntry["EffectDieSides"]);
        }
        catch (Exception)
        {
        }

        GenerateMiscValueDescriptions();
    }

    // Provides additional information for the misc values provided by the spell effect based on what effect is used
    private void GenerateMiscValueDescriptions()
    {
        if (HasAura)
        {
            switch (EffectAuraName)
            {
                case SpellAuras.SPELL_AURA_MOD_RESISTANCE:
                case SpellAuras.SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE:
                case SpellAuras.SPELL_AURA_MOD_TARGET_RESISTANCE:
                case SpellAuras.SPELL_AURA_MOD_BASE_RESISTANCE:
                case SpellAuras.SPELL_AURA_MOD_BASE_RESISTANCE_PCT:
                case SpellAuras.SPELL_AURA_MOD_RESISTANCE_PCT:
                    MiscValueAInfo = $"(Target resistance(s): {(SpellSchoolMasks)EffectMiscValues[0]})";
                    break;
                case SpellAuras.SPELL_AURA_MOD_RESISTANCE_OF_STAT_PERCENT:
                    MiscValueAInfo = $"(Target resistance(s): {(SpellSchoolMasks)EffectMiscValues[0]})";
                    MiscValueBInfo = $"(Source stat: {(Stats)EffectMiscValues[1]})";
                    break;
                case SpellAuras.SPELL_AURA_SCHOOL_ABSORB:
                    MiscValueAInfo = $"(Absorb SpellSchool(s): {(SpellSchoolMasks)EffectMiscValues[0]})";
                    break;
                default:
                    break;
            }

            return;
        }
        
        switch (EffectName)
        {
            case SpellEffects.SPELL_EFFECT_SUMMON:
                MiscValueAInfo = "(Creature Id)";
                MiscValueBInfo = "(SummonProperties Id)";
                break;
            case SpellEffects.SPELL_EFFECT_TRIGGER_SPELL:
                MiscValueAInfo = "(Delay in ms)";
                break;
            case SpellEffects.SPELL_EFFECT_ENERGIZE:
            case SpellEffects.SPELL_EFFECT_ENERGIZE_PCT:
                MiscValueAInfo = $"(PowerType: {(Powers)EffectMiscValues[0]})";
                break;
            default:
                break;
        }
    }

    [RelayCommand]
    public void SelectSpellFromList(int spellId)
    {
        SpellInfoViewModel? selectedSpellInfoViewModel = SpellInfoViewModel.MainViewModel.SpellInfoSource.Items
            .FirstOrDefault(s => s.SpellId == spellId);

        if (selectedSpellInfoViewModel != null)
            SpellInfoViewModel.MainViewModel.SelectedSpellInfo = selectedSpellInfoViewModel;
    }
}
