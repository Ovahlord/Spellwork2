using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    
    public int SpellId { get; init; }
    public int DifficultyId { get; init; }
    public int SpellRangeId { get; init; }
    public string DifficultyName { get; init; } = "None";

    public ObservableCollection<AttributeInfo> Attributes { get; init; } = [];
    
    public string Name { get; init; } = string.Empty;
    public string NameSubtext { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string AuraDescription { get; init; } = string.Empty;
    public SpellSchoolMasks SchoolMask { get; init; }
    public SpellFamilies SpellFamily { get; init; }
    public int SpellFamilyId => (int)SpellFamily;
    public int SchoolMaskInt => (int)SchoolMask;
    public uint[] SpellClassMasks { get; init; } = [];
    public string SpellRangeName { get; init; } = string.Empty;
    public float[] MinRange { get;  init; } = [0f, 0f];
    public float[] MaxRange { get; init; } = [0f, 0f];

    public List<SpellEffectViewModel> SpellEffects { get; init; } = [];

    public string FullName => $"{Name} {(string.IsNullOrWhiteSpace(NameSubtext) ? string.Empty : $"({NameSubtext})")}";
    public bool HasSpellDescription => !string.IsNullOrWhiteSpace(Description);
    public bool HasAuraDescription => !string.IsNullOrWhiteSpace(AuraDescription);
    public bool HasAttributes => Attributes.Count > 0;
    public bool HasSpellFamily => SpellFamily != SpellFamilies.SPELLFAMILY_GENERIC;
    public bool HasScaling => DbcMgr.SpellScalingSpellId.TryGetValue(SpellId, out _);

    public SpellInfoViewModel()
    {
    }
    
    public SpellInfoViewModel(DBCDRow spellMiscEntry)
    {
        SpellId = Convert.ToInt32(spellMiscEntry["SpellID"]);
        DifficultyId = Convert.ToInt32(spellMiscEntry["DifficultyID"]);
        SpellRangeId = Convert.ToInt32(spellMiscEntry["RangeIndex"]);

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

        SchoolMask = (SpellSchoolMasks)Convert.ToInt32(spellMiscEntry["SchoolMask"]);
        
        if (DifficultyId != 0 && DbcMgr.DifficultyStore != null)
            if (DbcMgr.DifficultyStore.TryGetValue(DifficultyId, out DBCDRow? difficultyEntry))
                DifficultyName = (string)difficultyEntry["Name_lang"];

        if (DbcMgr.SpellStore != null && DbcMgr.SpellStore.TryGetValue(SpellId, out DBCDRow? spellEntry))
        {
            NameSubtext = (string)spellEntry["NameSubtext_lang"];
            Description = (string)spellEntry["Description_lang"];
            AuraDescription = (string)spellEntry["AuraDescription_lang"];
        }

        if (DbcMgr.SpellNameStore != null && DbcMgr.SpellNameStore.TryGetValue(SpellId, out DBCDRow? spellNameEntry))
        {
            Name = (string)spellNameEntry["Name_lang"];
        }

        if (DbcMgr.SpellEffectsBySpellId.TryGetValue(SpellId, out List<DBCDRow>? spellEffectEntries))
        {
            SpellEffects = spellEffectEntries
                .Where(r => Convert.ToInt32(r["DifficultyID"]) == DifficultyId)
                .Select(r => new SpellEffectViewModel(r))
                .ToList();
        }
        
        if (DbcMgr.SpellClassOptionsBySpellId.TryGetValue(SpellId, out DBCDRow? spellClassOptionsEntry))
        {
            SpellFamily = (SpellFamilies)spellClassOptionsEntry["SpellClassSet"];
            if (spellClassOptionsEntry["SpellClassMask"] is uint[] spellClassMask)
                SpellClassMasks = spellClassMask;
            else
                SpellClassMasks = [0, 0, 0, 0];
        }

        if (SpellRangeId > 0)
        {
            if (DbcMgr.SpellRangeStore != null && DbcMgr.SpellRangeStore.TryGetValue(SpellRangeId, out DBCDRow? spellRangeEntry))
            {

                SpellRangeName = (string)spellRangeEntry["DisplayName_lang"];
                if (spellRangeEntry["RangeMin"] is float[] rangeMin)
                {
                    if (spellRangeEntry["RangeMax"] is float[] rangeMax)
                    {
                        MinRange = rangeMin;
                        MaxRange = rangeMax;
                    }
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