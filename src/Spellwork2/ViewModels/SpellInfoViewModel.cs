using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DBCD;
using Spellwork2.DBC;
using Spellwork2.Enums;

namespace Spellwork2.ViewModels;

public struct AttributeInfo
{
    public string AttributeTitle { get; set; }
    public uint AttributeValue { get; set; }
    public string AttributeNames { get; set; }
}

public class SpellInfoViewModel : ViewModelBase
{
    // Record accessors
    public int SpellId => _spellMiscEntry?.FieldAs<int>("SpellID") ?? 0;
    public int DifficultyId => _spellMiscEntry?.FieldAs<int>("DifficultyID") ?? 0;
    public int SpellRangeId => _spellMiscEntry?.FieldAs<int>("RangeIndex") ?? 0;
    public int SpellDurationId => _spellMiscEntry?.FieldAs<int>("DurationIndex") ?? 0;
    public string DifficultyName => _difficultyEntry?.FieldAs<string>("Name_lang") ?? "None";
    public string Name => _spellNameEntry?.FieldAs<string>("Name_lang") ?? string.Empty;
    public string NameSubtext => _spellEntry?.FieldAs<string>("NameSubtext_lang") ?? string.Empty;
    public string Description => _spellEntry?.FieldAs<string>("Description_lang") ?? string.Empty;
    public string AuraDescription => _spellEntry?.FieldAs<string>("AuraDescription_lang") ?? string.Empty;
    public string SpellRangeName => _spellRangeEntry?.FieldAs<string>("DisplayName_lang") ?? string.Empty;
    public int SpellFamilyId => _spellClassOptionsEntry?.FieldAs<int>("SpellClassSet") ?? 0;
    public int SchoolMaskInt => _spellMiscEntry?.FieldAs<int>("SchoolMask") ?? 0;
    public int Duration => _spellDurationEntry?.FieldAs<int>("Duration") ?? 0;
    public int MaxDuration => _spellDurationEntry?.FieldAs<int>("MaxDuration") ?? 0;
    public int DurationPerLevel => _spellDurationEntry?.FieldAs<int>("DurationPerLevel") ?? 0;
    public int ConeDegrees => _spellTargetRestrictionsEntry?.FieldAs<int>("ConeDegrees") ?? 0;
    public int ConeWidth => _spellTargetRestrictionsEntry?.FieldAs<int>("Width") ?? 0;
    public int MaxTargets => _spellTargetRestrictionsEntry?.FieldAs<int>("MaxTargets") ?? 0;
    public int MaxTargetLevel => _spellTargetRestrictionsEntry?.FieldAs<int>("MaxTargetLevel") ?? 0;
    public string DescriptionVariables => DbcMgr.SpellDescriptionVariablesBySpellId.TryGetValue(SpellId, out string? variables) ? variables : string.Empty;
    
    // Convenience properties
    public SpellSchoolMasks SchoolMask => (SpellSchoolMasks)SchoolMaskInt;
    public SpellFamilies SpellFamily => (SpellFamilies)SpellFamilyId;
    public string FullName => $"{Name} {(string.IsNullOrWhiteSpace(NameSubtext) ? string.Empty : $"({NameSubtext})")}";
    public bool HasSpellDescription => !string.IsNullOrWhiteSpace(Description);
    public bool HasAuraDescription => !string.IsNullOrWhiteSpace(AuraDescription);
    public bool HasAttributes => Attributes.Count > 0;
    public bool HasSpellFamily => SpellFamily != SpellFamilies.SPELLFAMILY_GENERIC;
    public bool HasScaling => _spellScalingEntry != null;
    public bool HasSpellDuration => _spellDurationEntry != null;
    public bool HasConeDegrees => ConeDegrees > 0;
    public bool HasConeWidth => ConeWidth > 0;
    public bool HasMaxTargets => MaxTargets > 0;
    public bool HasMaxTargetLevel => MaxTargetLevel > 0;
    public bool HasDescriptionVariables => !string.IsNullOrWhiteSpace(DescriptionVariables);
    
    // Post-processing data
    public ObservableCollection<AttributeInfo> Attributes { get; init; } = [];
    public uint[] SpellClassMasks { get; init; } = [];
    public float[] MinRange { get;  init; } = [0f, 0f];
    public float[] MaxRange { get; init; } = [0f, 0f];

    public List<SpellEffectViewModel> SpellEffects { get; init; } = [];

    // Records
    private readonly DBCDRow? _spellMiscEntry;
    private readonly DBCDRow? _spellEntry;
    private readonly DBCDRow? _spellNameEntry;
    private readonly DBCDRow? _spellClassOptionsEntry;
    private readonly DBCDRow? _difficultyEntry;
    private readonly DBCDRow? _spellRangeEntry;
    private readonly DBCDRow? _spellDurationEntry;
    private readonly DBCDRow? _spellScalingEntry;
    private readonly DBCDRow? _spellTargetRestrictionsEntry;
    
    public MainViewModel MainViewModel { get; init; }
    
    public SpellInfoViewModel()
    {
        MainViewModel = new MainViewModel();
    }
    
    public SpellInfoViewModel(DBCDRow spellMiscEntry, MainViewModel parent)
    {
        _spellMiscEntry = spellMiscEntry;
        MainViewModel = parent;
        
        DbcMgr.DifficultyStore?.TryGetValue(DifficultyId, out _difficultyEntry);
        DbcMgr.SpellStore?.TryGetValue(SpellId, out _spellEntry);
        DbcMgr.SpellNameStore?.TryGetValue(SpellId, out _spellNameEntry);
        DbcMgr.SpellRangeStore?.TryGetValue(SpellRangeId, out _spellRangeEntry);
        DbcMgr.SpellDurationStore?.TryGetValue(SpellDurationId, out _spellDurationEntry);
        DbcMgr.SpellClassOptionsBySpellId.TryGetValue(SpellId, out _spellClassOptionsEntry);
        DbcMgr.SpellScalingBySpellId.TryGetValue(SpellId, out _spellScalingEntry);

        if (spellMiscEntry["Attributes"] is uint[] attributes)
        {
            for (int i = 0; i < attributes.Length; ++i)
            {
                if (attributes[i] == 0)
                    continue;
                
                Attributes.Add(new AttributeInfo()
                {
                    AttributeTitle = $"Attributes{i}",
                    AttributeValue = attributes[i],
                    AttributeNames = BuildSpellAttributesString(attributes[i], i)
                });
            }
        }
        
        if (DbcMgr.SpellEffectsBySpellId.TryGetValue(SpellId, out List<DBCDRow>? spellEffectEntries))
        {
            SpellEffects = spellEffectEntries
                .Where(r => r.FieldAs<int>("DifficultyID") == DifficultyId)
                .Select(r => new SpellEffectViewModel(r, this))
                .ToList();
        }
        
        if (DbcMgr.SpellTargetRestrictionsBySpellId.TryGetValue(SpellId, out List<DBCDRow>? spellTargetRestrictionsEntries))
            _spellTargetRestrictionsEntry = spellTargetRestrictionsEntries.FirstOrDefault(r => r.FieldAs<int>("DifficultyID") == DifficultyId);
        
        if (_spellClassOptionsEntry != null)
        {
            if (_spellClassOptionsEntry["SpellClassMask"] is uint[] spellClassMask)
                SpellClassMasks = spellClassMask;
            else
                SpellClassMasks = [0, 0, 0, 0];
        }

        if (_spellRangeEntry != null)
        {
            if (_spellRangeEntry["RangeMin"] is float[] rangeMin)
            {
                if (_spellRangeEntry["RangeMax"] is float[] rangeMax)
                {
                    MinRange = rangeMin;
                    MaxRange = rangeMax;
                }
            }
        }
    }

    private static string BuildSpellAttributesString(uint attributesValue, int attributesIndex)
    {
        object enumValue = Enum.ToObject(SpellAttributes.AttributeEnums[attributesIndex], attributesValue);
        string? attributeNames = enumValue.ToString();
        if (attributeNames == null)
            return string.Empty;
        
        return attributeNames.Replace(",", "\n").Replace(" ", "");
    }
}