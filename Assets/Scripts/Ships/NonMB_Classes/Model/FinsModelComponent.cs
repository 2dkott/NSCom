using System;
using System.Collections.Generic;
using UnityEngine;

public class FinsModelComponent : ModelComponent
{

    public FinsModelComponent()
        : base()
    {
        PitchPositive = new List<Transform>();
        PitchNegative = new List<Transform>();
        YawPositive = new List<Transform>();
        YawNegative = new List<Transform>();
        StrafeVPositive = new List<Transform>();
        StrafeVNegative = new List<Transform>();
        StrafeHPositive = new List<Transform>();
        StrafeHNegative = new List<Transform>();
    }

    public override void collect(Transform modelComponent)
    {
        if (modelComponent.name.Contains("pitch+")) { PitchPositive.Add(modelComponent); }
        if (modelComponent.name.Contains("pitch-")) { PitchNegative.Add(modelComponent); }
        if (modelComponent.name.Contains("yaw+")) { YawPositive.Add(modelComponent); }
        if (modelComponent.name.Contains("yaw-")) { YawNegative.Add(modelComponent); }
        if (modelComponent.name.Contains("strafev+")) { StrafeVPositive.Add(modelComponent); }
        if (modelComponent.name.Contains("strafev-")) { StrafeVNegative.Add(modelComponent); }
        if (modelComponent.name.Contains("strafeh+")) { StrafeHPositive.Add(modelComponent); }
        if (modelComponent.name.Contains("strafeh-")) { StrafeHNegative.Add(modelComponent); }
    }

    public List<Transform> PitchPositive { get; private set; }
    public List<Transform> PitchNegative { get; private set; }
    public List<Transform> YawPositive { get; private set; }
    public List<Transform> YawNegative { get; private set; }
    public List<Transform> StrafeVPositive { get; private set; }
    public List<Transform> StrafeVNegative { get; private set; }
    public List<Transform> StrafeHPositive { get; private set; }
    public List<Transform> StrafeHNegative { get; private set; }
}