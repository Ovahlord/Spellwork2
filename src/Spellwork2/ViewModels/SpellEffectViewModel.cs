using System;
using System.Collections.Generic;
using DBCD;
using Spellwork2.DBC;
using Spellwork2.Enums;

namespace Spellwork2.ViewModels;

public class SpellEffectViewModel : ViewModelBase
{
    public int EffectIndex { get; init; }
    public int Effect { get; init; }
    public int EffectAura { get; init; }
    public float BasePoints { get; init; }
    public float Variance { get; init; }
    public int DieSides { get; init; }
    public int Period { get; init; }

    public int[] EffectMiscValues { get; set; } = [0, 0];
    
    public SpellEffects EffectName => (SpellEffects)Effect;
    public SpellAuras EffectAuraName => (SpellAuras)EffectAura;
    public ImplicitTargets ImplicitTargetA { get; init; }
    public ImplicitTargets ImplicitTargetB { get; init; }
    public string RadiusA { get; init; } = string.Empty;
    public string RadiusB { get; init; } = string.Empty;
    
    public bool HasAura { get; init; } = true;
    public bool HasDieSides {  get; init; } = true;
    
    public SpellEffectViewModel()
    {
    }
    
    public SpellEffectViewModel(DBCDRow dbcRow)
    {
        EffectIndex = Convert.ToInt32(dbcRow["EffectIndex"]);
        Effect = Convert.ToInt32(dbcRow["Effect"]);
        EffectAura = Convert.ToInt32(dbcRow["EffectAura"]);
        HasAura = EffectAuraName != SpellAuras.SPELL_AURA_NONE;
        Period = Convert.ToInt32(dbcRow["EffectAuraPeriod"]);

        // Initialize misc values
        if (dbcRow["EffectMiscValue"] is int[] miscValues)
            EffectMiscValues = miscValues;

        // Initialize effect targets
        if (dbcRow["ImplicitTarget"] is short[] targets)
        {
            ImplicitTargetA = (ImplicitTargets)targets[0];
            ImplicitTargetB = (ImplicitTargets)targets[1];
        }

        // Initialize effect radius
        if (DbcMgr.SpellRadiusStore != null)
        {
            if (dbcRow["EffectRadiusIndex"] is uint[] radiusIndexes)
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
            BasePoints = Convert.ToSingle(dbcRow["EffectBasePoints"]);
        }
        catch (Exception) // Newer client versions store BasePoints as float instead of int
        {
            BasePoints = Convert.ToSingle(dbcRow["EffectBasePointsF"]);
        }
        
        Variance = Convert.ToSingle(dbcRow["Variance"]);

        try
        {
            // DieSides exist only in classic varians
            DieSides = Convert.ToInt32(dbcRow["EffectDieSides"]);
            HasDieSides = true;
        }
        catch (Exception)
        {
            HasDieSides = false;
        }
    }
}
