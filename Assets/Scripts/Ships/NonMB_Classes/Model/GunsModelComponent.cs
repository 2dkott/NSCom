using System;
using System.Collections.Generic;
using UnityEngine;

public class GunsModelComponent : ModelComponent
{
    public GunsModelComponent()
        :base()
    {
        SmallGunPositions = new List<Transform>();
    }

    ShipSettings shipSettings;
    GameObject smallGunInstance;

    public override void collect(Transform modelComponent)
    {
        if (modelComponent.name.Contains("_small_")) {
            SmallGunPositions.Add(modelComponent); 
        }
    }
    public List<Transform> SmallGunPositions {get; private set;}
}

