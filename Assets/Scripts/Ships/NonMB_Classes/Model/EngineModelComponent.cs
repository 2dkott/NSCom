using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EngineModelComponent : ModelComponent
{
    public EngineModelComponent()
        : base()
    {
        ExhaustPositive = new List<Transform>();
        ExhaustNegative = new List<Transform>();
    }

    public List<Transform> ExhaustPositive { get; private set; }
    public List<Transform> ExhaustNegative { get; private set; }

    public override void collect(Transform modelComponent)
    {
        if (modelComponent.name.Contains("+")) { ExhaustPositive.Add(modelComponent); return; }
        if (modelComponent.name.Contains("-")) { ExhaustNegative.Add(modelComponent); return; }
    }
}