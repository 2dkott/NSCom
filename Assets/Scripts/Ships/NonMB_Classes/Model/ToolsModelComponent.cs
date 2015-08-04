using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToolsModelComponent : ModelComponent
{

    public ToolsModelComponent()
        : base()
    {
        PitchPositive = new List<Transform>();
        PitchNegative = new List<Transform>();
    }

    public override void collect(Transform modelComponent)
    {
        if (modelComponent.name.Contains(ShipComponentNameConstants.Fins + "pitch+")) { PitchPositive.Add(modelComponent); return; }
        if (modelComponent.name.Contains(ShipComponentNameConstants.Fins + "pitch-")) { PitchNegative.Add(modelComponent); return; }
    }

    public List<Transform> PitchPositive { get; private set; }
    public List<Transform> PitchNegative { get; private set; }

    public override string ToString()
    {
        return base.ToString() + ": " + ": PitchPositive:" + PitchPositive.Count;
    }
}