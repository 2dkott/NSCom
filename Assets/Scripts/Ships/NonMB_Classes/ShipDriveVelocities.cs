using System;
using System.Collections;

/// <summary>
/// Container for set of ship velocity limits. It defines how fast ship should move in XYZ axis
/// </summary>
public class ShipDriveVelocities
{
    private SpaceObjectAxisVelocity shipForward;
    /// <summary>
    /// Velocities for Z direction
    /// </summary>
    public ShipDriveVelocities(float backVelocity, float forthVelocity)
    {
        this.BackForthVelocities = new SpaceObjectAxisVelocity(backVelocity, forthVelocity);
    }

    public ShipDriveVelocities(
                                SpaceObjectAxisVelocity backForthVelocities
                                , SpaceObjectAxisVelocity horizStrafeVelocities
                                , SpaceObjectAxisVelocity verticStrafeVelocities
                                , SpaceObjectAxisVelocity horizTorqueVelocities
                                , SpaceObjectAxisVelocity verticTorqueVelocities
                                , SpaceObjectAxisVelocity rollTorqueVelocities
                                )
    {
        this.BackForthVelocities = backForthVelocities;
        this.HorizStrafeVelocities = horizStrafeVelocities;
        this.VerticStrafeVelocities = verticStrafeVelocities;
        this.HorizTorqueVelocities = horizTorqueVelocities;
        this.VerticTorqueVelocities = verticTorqueVelocities;
        this.RollTorqueVelocities = rollTorqueVelocities;
    }

    public ShipDriveVelocities addAccelarationTime(float accelarationTime)
    {
        this.AccelarationSpeed = accelarationTime;
        return this;
    }

    public float AccelarationSpeed { private set; get; }
    public SpaceObjectAxisVelocity BackForthVelocities { private set; get; }
    public SpaceObjectAxisVelocity HorizStrafeVelocities { private set; get; }
    public SpaceObjectAxisVelocity VerticStrafeVelocities { private set; get; }
    public SpaceObjectAxisVelocity HorizTorqueVelocities { private set; get; }
    public SpaceObjectAxisVelocity VerticTorqueVelocities { private set; get; }
    public SpaceObjectAxisVelocity RollTorqueVelocities { private set; get; }
}

public struct SpaceObjectAxisVelocity
{
    
	float negative;
	float positive;
	public SpaceObjectAxisVelocity(float negative, float positive)
    {
        this.negative = negative;
        this.positive = positive;
    }
	public float Positive { get{return positive;} }
	public float Negative { get {return negative;} }
}