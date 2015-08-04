using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Class for maintaing player game controls
/// </summary>

public sealed class PlayerControls
{
    private static readonly PlayerControls instance = new PlayerControls();
    
    private ShipControl power;
    private ShipControl horizontal;
    private ShipControl vertical;
    private ShipControl horizStrafe;
    private ShipControl verticStrafe;
    private ShipControl roll;
    private ShipControl combat;

    private PlayerControls()
    {
        power = new ShipControl("Power");
        horizontal = new ShipControl("Horizontal");
        vertical = new ShipControl("Vertical");
        horizStrafe = new ShipControl("HorizStrafe");
        verticStrafe = new ShipControl("VerticStrafe");
        roll = new ShipControl("Roll");
        combat = new ShipControl("Combat");
    }


    public static PlayerControls Instance
    {
        get
        {
            return instance;
        }
    }

    public ShipControl Power { get { return power.getControlInfo(); } }
    public ShipControl Horizontal { get { return horizontal.getControlInfo(); } }
    public ShipControl Vertical { get { return vertical.getControlInfo(); } }
    public ShipControl HorizStrafe { get { return horizStrafe.getControlInfo(); } }
    public ShipControl VerticStrafe { get { return verticStrafe.getControlInfo(); } }
    public ShipControl Roll { get { return roll.getControlInfo(); } }
    public ShipControl Combat { get { return combat.getControlInfo(); } }
}

public class ShipControl
{
    private string value;
    float startTime;
    float endTime;

    public ShipControl(string value)
    {
        this.value = value;
        this.ControlPressDuration = 0f;
    }

    public ShipControl getControlInfo()
    {
        if (Input.GetButtonDown(value)) { startTime = Time.time; }
        if (Input.GetButtonUp(value)) { endTime = Time.time; ControlPressDuration = startTime - endTime; } 

        return this;
    }

    public float AxisValue { get { return Input.GetAxis(value); } }
    public float ControlPressDuration { get; private set; }
    public bool Pressed { get { return Input.GetButtonUp(value); } }

}
