using UnityEngine;
using System.Collections;

public class AIDriveShipMovement : SpaceMovement
{

    Rigidbody thisRigidbody;
    Vector3 direction;
    Transform target;

    public AIDriveShipMovement(ShipDriveVelocities velocities, Rigidbody thisRigidbody)
        : base(velocities)
    {
        this.thisRigidbody = thisRigidbody;
    } 

    
    public override void move(Transform target)
    {
        //Debug.Log(target );
        direction = (target.position - thisRigidbody.position).normalized;
        //Debug.Log(shipVelocities.ForwardSpeed);
        //thisRigidbody.MovePosition(thisRigidbody.position + direction * shipVelocities.MaxForwardVelocity * Time.deltaTime);
        //thisRigidbody.AddRelativeForce(0, 0, shipVelocities.ForwardSpeed * Time.deltaTime);
    }
}
