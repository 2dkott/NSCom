using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Motor for Player Ship 
/// </summary>
public class PlayerDriveShipMovement : SpaceMovement
{
    float roll;
    float pitch;
    float yaw;
    
    Rigidbody thisGameobject;
    float trueSpeed;

    VelocityManager velocity;
    
    public PlayerDriveShipMovement(ShipDriveVelocities shipVelocities, Rigidbody GameobjectRigBody)
        : base(shipVelocities)
    {
        this.thisGameobject = GameobjectRigBody;
        velocity = new VelocityManager();
    }

    public override void move(Transform target)
    {
        if (target)
        {
        }
        else
        {
            thisGameobject.AddRelativeTorque(Vector3.up * velocity.GetVelocityForAcceleratonByControl(PlayerControls.Instance.Horizontal.AxisValue, shipVelocities.HorizTorqueVelocities, thisGameobject.drag), ForceMode.Acceleration);
            thisGameobject.AddRelativeTorque(Vector3.right * velocity.GetVelocityForAcceleratonByControl(PlayerControls.Instance.Vertical.AxisValue, shipVelocities.VerticTorqueVelocities, thisGameobject.drag), ForceMode.Acceleration);
            thisGameobject.AddRelativeTorque(Vector3.forward * velocity.GetVelocityForAcceleratonByControl(PlayerControls.Instance.Roll.AxisValue, shipVelocities.HorizTorqueVelocities, thisGameobject.drag), ForceMode.Acceleration);
            
            thisGameobject.AddRelativeForce(Vector3.forward * velocity.GetVelocityForAcceleratonByControl(PlayerControls.Instance.Power.AxisValue, shipVelocities.BackForthVelocities, thisGameobject.drag), ForceMode.Acceleration);
            thisGameobject.AddRelativeForce(Vector3.up * velocity.GetVelocityForAcceleratonByControl(PlayerControls.Instance.VerticStrafe.AxisValue, shipVelocities.VerticStrafeVelocities, thisGameobject.drag), ForceMode.Acceleration);
            thisGameobject.AddRelativeForce(Vector3.right * velocity.GetVelocityForAcceleratonByControl(PlayerControls.Instance.HorizStrafe.AxisValue, shipVelocities.HorizStrafeVelocities, thisGameobject.drag), ForceMode.Acceleration);

            if (Input.GetKey("space"))
            {
                thisGameobject.velocity = new Vector3(0f, 0f, 0f);
            }
        }
    }
}

/// <summary>
/// Class contain methods to define XYZ velosities according ship velocities limit
/// </summary>
public class VelocityManager
{    
    /// <summary>
    /// Return value to make rigidebody move with constant speed in case of AddRelative() and ForceMode as VelocityChange
    /// </summary>
    float GetVelocityChange(float velocityLimit, float rigDrag)
    {
        float m = Mathf.Clamp01(rigDrag * Time.fixedDeltaTime);
        return velocityLimit * m / (1 - m);
    }

    /// <summary>
    /// Return value to make rigidebody move with constant speed in case of AddRelative() and ForceMode as Accelaration regarding User Input value(1|0|-1)
    /// </summary>
    public float GetVelocityForAcceleratonByControl(float directionFlag, float velocityLimit, float rigDrag)
    {
        return directionFlag * (GetVelocityChange(velocityLimit, rigDrag) / Time.fixedDeltaTime);
    }
    
    /// <summary>
    /// Return value to make rigidebody move with constant speeds for positive and negative axis movemant in case of AddRelative() and ForceMode as Accelaration regarding User Input value(1|0|-1)
    /// </summary>
    public float GetVelocityForAcceleratonByControl(float directionFlag, SpaceObjectAxisVelocity velocities, float rigDrag)
    {
        float velocity = 0f;
        if (directionFlag > 0) velocity = velocities.Positive;
        if (directionFlag < 0) velocity = velocities.Negative;
        return directionFlag * (GetVelocityChange(velocity, rigDrag) / Time.fixedDeltaTime);
    }
}
