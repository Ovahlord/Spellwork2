using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DBCD;
using DBCD.Providers;
using Spellwork2.Configuration;

namespace Spellwork2.DBC;

public static class DbcMgr
{
    public static IDBCDStorage? SpellStore { get; private set; }
    public static IDBCDStorage? SpellMiscStore { get; private set; }
    public static IDBCDStorage? SpellNameStore { get; private set; }
    public static IDBCDStorage? SpellEffectStore { get; private set; }
    public static IDBCDStorage? SpellCastTimesStore { get; private set; }
    public static IDBCDStorage? SpellClassOptionsStore { get; private set; }
    public static IDBCDStorage? SpellCooldownsStore { get; private set; }
    public static IDBCDStorage? SpellDurationStore { get; private set; }
    public static IDBCDStorage? SpellRadiusStore { get; private set; }
    public static IDBCDStorage? SpellTargetRestrictionsStore { get; private set; }
    public static IDBCDStorage? SpellRangeStore { get; private set; }
    public static IDBCDStorage? SpellPowerStore { get; private set; }
    public static IDBCDStorage? SpellCategoriesStore { get; private set; }
    public static IDBCDStorage? SpellScalingStore { get; private set; }
    public static IDBCDStorage? DifficultyStore { get; private set; }
    public static IDBCDStorage? ItemSparseStore { get; private set; }
    public static IDBCDStorage? SummonPropertiesStore { get; private set; }
    public static IDBCDStorage? SpellDescriptionVariablesStore { get; private set; }
    public static IDBCDStorage? SpellXDescriptionVariablesStore { get; private set; }
    
    public static ConcurrentDictionary<int, List<DBCDRow>> SpellEffectsBySpellId { get; } = [];
    public static ConcurrentDictionary<int, List<DBCDRow>> SpellMiscBySpellId { get; } = [];
    public static ConcurrentDictionary<int, DBCDRow> SpellClassOptionsBySpellId { get; } = [];
    public static ConcurrentDictionary<int, DBCDRow> SpellScalingBySpellId { get; } = [];
    public static ConcurrentDictionary<int, List<DBCDRow>> SpellTargetRestrictionsBySpellId { get; } = [];
    public static ConcurrentDictionary<int, string> ItemNamesByItemId { get; } = [];
    public static ConcurrentDictionary<int, string> SpellDescriptionVariablesBySpellId { get; } = [];
    
    
    public static async Task LoadStoragesAsync()
    {
        FilesystemDBCProvider db2Provider = new(ConfigurationMgr.Db2FolderPath);
        using FileStream fs = File.OpenRead(ConfigurationMgr.DbDefsPath);
        DBCD.DBCD dbcd = new(db2Provider, fs);
        
        // ===== Loading storages ====== /
        List<Task> runningTasks = [];
        
        runningTasks.Add(Task.Run(() => SpellStore = dbcd.Load("Spell", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => { SpellNameStore = dbcd.Load("SpellName", ConfigurationMgr.SelectedBuild); }));
        
        runningTasks.Add(Task.Run(() =>
        {
             SpellMiscStore = dbcd.Load("SpellMisc", ConfigurationMgr.SelectedBuild);
             Parallel.ForEach(SpellMiscStore.Values, row =>
             {
                 int spellId = (int)row["SpellID"];
                 if (SpellMiscBySpellId.TryGetValue(spellId, out List<DBCDRow>? rows))
                     rows.Add(row);
                 else
                     SpellMiscBySpellId.TryAdd(spellId, [row]);
             });
        }));
        
        runningTasks.Add(Task.Run(() =>
        {
            SpellEffectStore = dbcd.Load("SpellEffect", ConfigurationMgr.SelectedBuild);
            Parallel.ForEach(SpellEffectStore.Values, row =>
            {
                int spellId = row.FieldAs<int>("SpellID");
                if (SpellEffectsBySpellId.TryGetValue(spellId, out List<DBCDRow>? rows))
                    rows.Add(row);
                else
                    SpellEffectsBySpellId.TryAdd(spellId, [row]);
            });
        }));
        
        runningTasks.Add(Task.Run(() =>
        {
            SpellClassOptionsStore = dbcd.Load("SpellClassOptions", ConfigurationMgr.SelectedBuild);
            Parallel.ForEach(SpellClassOptionsStore.Values, row =>
            {
                int spellId = row.FieldAs<int>("SpellID");
                SpellClassOptionsBySpellId.TryAdd(spellId, row);
            });
        }));
        
        
        runningTasks.Add(Task.Run(() =>
        {
            SpellScalingStore = dbcd.Load("SpellScaling", ConfigurationMgr.SelectedBuild);
            Parallel.ForEach(SpellScalingStore.Values, row =>
            {
                int spellId = row.FieldAs<int>("SpellID");
                SpellScalingBySpellId.TryAdd(spellId, row);
            });
        }));
        
        runningTasks.Add(Task.Run(() =>
        {
            SpellTargetRestrictionsStore = dbcd.Load("SpellTargetRestrictions", ConfigurationMgr.SelectedBuild);
            Parallel.ForEach(SpellTargetRestrictionsStore.Values, row =>
            {
                int spellId = row.FieldAs<int>("SpellID");
                if (SpellTargetRestrictionsBySpellId.TryGetValue(spellId, out List<DBCDRow>? rows))
                    rows.Add(row);
                else
                    SpellTargetRestrictionsBySpellId.TryAdd(spellId, [row]);
            });
        }));
        
        runningTasks.Add(Task.Run(() => SpellCastTimesStore = dbcd.Load("SpellCastTimes", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => SpellCooldownsStore = dbcd.Load("SpellCooldowns", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => SpellDurationStore = dbcd.Load("SpellDuration", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => SpellRadiusStore = dbcd.Load("SpellRadius", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => SpellRangeStore = dbcd.Load("SpellRange", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => SpellPowerStore = dbcd.Load("SpellPower", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => SpellCategoriesStore = dbcd.Load("SpellCategories", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => DifficultyStore = dbcd.Load("Difficulty", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => SummonPropertiesStore = dbcd.Load("SummonProperties", ConfigurationMgr.SelectedBuild)));
        runningTasks.Add(Task.Run(() => SpellDescriptionVariablesStore = dbcd.Load("SpellDescriptionVariables", ConfigurationMgr.SelectedBuild)).ContinueWith((_) =>
        {
            SpellXDescriptionVariablesStore = dbcd.Load("SpellXDescriptionVariables", ConfigurationMgr.SelectedBuild);
            Parallel.ForEach(SpellXDescriptionVariablesStore.Values, row =>
            {
                int spellId = row.FieldAs<int>("SpellID");
                int recordId = row.FieldAs<int>("SpellDescriptionVariablesID");
                if (SpellDescriptionVariablesStore != null && SpellDescriptionVariablesStore.TryGetValue(recordId, out DBCDRow? variableEntry))
                    SpellDescriptionVariablesBySpellId.TryAdd(spellId, variableEntry.FieldAs<string>("Variables"));
            });
            
        }));
        
        runningTasks.Add(Task.Run(() =>
        {
            ItemSparseStore = dbcd.Load("ItemSparse", ConfigurationMgr.SelectedBuild);
            Parallel.ForEach(ItemSparseStore.Values, row =>
            {
                ItemNamesByItemId.TryAdd(row.ID, row.FieldAs<string>("Display_lang"));
            });
        }));
        
        await Task.WhenAll(runningTasks);
    }

    public static void ClearStorages()
    {
        SpellStore = null;
        SpellMiscStore = null;
        SpellCooldownsStore = null;
        SpellEffectStore = null;
        SpellNameStore = null;
        SpellCastTimesStore = null;
        SpellRadiusStore = null;
        SpellDurationStore = null;
        SpellTargetRestrictionsStore = null;
        SpellRangeStore = null;
        SpellCategoriesStore = null;
        SpellPowerStore = null;
        DifficultyStore = null;
        ItemSparseStore = null;
        
        GC.Collect();
    }
}