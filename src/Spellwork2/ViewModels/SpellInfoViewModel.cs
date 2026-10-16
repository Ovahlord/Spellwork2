using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBCD;
using Spellwork2.DBC;
using Spellwork2.Enums;

namespace Spellwork2.ViewModels;

public class SpellInfoViewModel : ViewModelBase
{
    public int SpellId { get; init; }
    public int DifficultyId { get; init; }
    public string DifficultyName { get; init; } = "None";
    public uint[] Attributes { get; init; } = [];
    
    public string Name { get; init; } = string.Empty;
    public string NameSubtext { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string AuraDescription { get; init; } = string.Empty;
    public SpellSchoolMasks SchoolMask { get; init; }
    public SpellFamilies SpellFamily { get; init; }
    public uint[] SpellClassMasks { get; init; } = [];
    public string AttributesString { get; init; } = string.Empty;

    public List<SpellEffectViewModel> SpellEffects { get; init; } = [];

    public string FullName => $"{Name} {(string.IsNullOrWhiteSpace(NameSubtext) ? string.Empty : $"({NameSubtext})")}";
    public bool HasSpellDescription => !string.IsNullOrWhiteSpace(Description);
    public bool HasAuraDescription => !string.IsNullOrWhiteSpace(AuraDescription);
    public bool HasAttributes => !string.IsNullOrWhiteSpace(AttributesString);
    public bool HasSpellFamily => SpellFamily != SpellFamilies.SPELLFAMILY_GENERIC;

    public SpellInfoViewModel()
    {
    }
    
    public SpellInfoViewModel(DBCDRow spellMiscEntry)
    {
        SpellId = Convert.ToInt32(spellMiscEntry["SpellID"]);
        DifficultyId = Convert.ToInt32(spellMiscEntry["DifficultyID"]);

        if (spellMiscEntry["Attributes"] is uint[] attributes)
        {
            Attributes = attributes;
            AttributesString = BuildSpellAttributesString();
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
    }
    
    private string BuildSpellAttributesString()
    {
        StringBuilder builder = new();

        int range = Math.Min(SpellAttributes.AttributeEnums.Length, Attributes.Length);
        
        for (int i = 0; i < range; ++i)
        {
            if (Attributes[i] == 0)
                continue;
            
            builder.AppendLine($"[SpellAttr{i}]: \t{Enum.ToObject(SpellAttributes.AttributeEnums[i], Attributes[i])}");
        }

        return builder.ToString();
    }
}