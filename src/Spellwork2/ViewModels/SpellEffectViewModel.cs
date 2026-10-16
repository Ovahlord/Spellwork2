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

    public int[] EffectMiscValues { get; set; } = [];
    public int[] ImplicitTargets { get; set; } = [];
    
    public SpellEffects EffectName => (SpellEffects)Effect;
    public SpellAuras EffectAuraName => (SpellAuras)EffectAura;
    public string EffectIndexName => $"[EFFECT_{EffectIndex}]";

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

        if (dbcRow["EffectMiscValue"] is int[] miscValues)
            EffectMiscValues = miscValues;

        if (dbcRow["ImplicitTarget"] is int[] targets)
            ImplicitTargets = targets;
        
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
