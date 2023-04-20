﻿using unicfg.Base.Primitives;
using unicfg.Base.SemanticTree;

namespace unicfg.Evaluation.Extensions;

public static class EmitScopeExtensions
{
    public static bool SetPropertyValue(this EmitScope scope, SymbolRef propertyPath, EmitValue value)
    {
        var currentScope = scope;
        var path = propertyPath.Path;

        for (var i = 0; i < path.Length - 1; i++)
        {
            var part = path[i];
            currentScope = currentScope.GetScope(part);

            if (currentScope is null)
                return false;
        }

        var property = currentScope.GetProperty(path[^1]);

        if (property is null)
            return false;

        property.Value = value;
        return true;
    }
}