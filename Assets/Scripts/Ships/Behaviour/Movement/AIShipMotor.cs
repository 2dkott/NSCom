using UnityEngine;
using System.Collections;

public class AIShipMotor : MonoBehaviour, ISpaceMovement
{
    public Transform target;
    ShipDriveVelocities shipVelocities;

    AIDriveShipMovement movement;

    void Awake()
    {
        shipVelocities = new ShipDriveVelocities(65f, 30f);
                    //.setTorqueVelocities(31f, 31f, 31f);
    }
	// Use this for initialization
	void Start () {

        movement = new AIDriveShipMovement(shipVelocities,gameObject.GetComponent<Rigidbody>());
	
	}



    public void move()
    {
        movement.move(target);
    }

    void FixedUpdate()
    {

        move();

    }

}
