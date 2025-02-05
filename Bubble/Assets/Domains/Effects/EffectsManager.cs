using Domains.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager
{
    private static Dictionary<GameModifierType,List<IEffectable>> _effectables = new();

    public static void Subscribe(GameModifierType key, IEffectable effectable)
    {
        if(!_effectables.ContainsKey(key))
            _effectables.Add(key, new());
        _effectables[key].Add(effectable);
    }
    
    public static void Unsubscribe(GameModifierType key, IEffectable effectable)
    {
        if(!_effectables.TryGetValue(key, out var effectables))
            return;
        effectables.Remove(effectable);
        _effectables[key] = effectables;
    }

    public void PlayEffect(GameModifierType modifierType)
    {
        if (!_effectables.TryGetValue(modifierType, out var effectables))
        {
            Debug.LogError($"Tried to play effect {modifierType} but it doesn't exist");
            return;
        }

        foreach (var effectable in effectables)
            effectable.ApplyEffect(modifierType);
    }
    
    public void DisableEffect(GameModifierType effectType)
    {
        if (!_effectables.TryGetValue(effectType, out var effectables))
        {
            Debug.LogError($"Tried to disable effect {effectType} but it doesn't exist");
            return;
        }
        
        foreach (var effectable in effectables)
            effectable.ApplyEffect(effectType);
    }
}
