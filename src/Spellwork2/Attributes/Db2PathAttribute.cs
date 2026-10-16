using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Spellwork2.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class Db2DirectoryAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null || 
            !(value is string path) || 
            string.IsNullOrWhiteSpace(path) ||
            !Directory.Exists(path))
            return false;

        return Directory.EnumerateFiles(path).Any(f => 
            f.EndsWith(".db2", StringComparison.OrdinalIgnoreCase) ||
            f.EndsWith(".dbc", StringComparison.OrdinalIgnoreCase));
    }
}