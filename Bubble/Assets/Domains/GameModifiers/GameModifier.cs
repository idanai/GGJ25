using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameModifier
{
    public GameModifierType Type;
    public Sprite Icon;
    public GameObject Prefab;
}

public enum GameModifierType
{
    FireExtinguisher,
    Goggles,
    Hat,
    Jump,
    JetPack,
    Pistol,
    RubberFloat,
    Sword,
    BreakablePlatforms,
    ShortPlatforms,
    Enemy,
    Shield,
    Random
}
