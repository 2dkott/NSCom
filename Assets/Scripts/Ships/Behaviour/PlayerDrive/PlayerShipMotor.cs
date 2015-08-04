using UnityEngine;
using System.Collections;

public class PlayerShipMotor : MonoBehaviour {

    PlayerDriveShipMovement movement;
    ShipDriveVelocities shipVelocities;
    
    void Awake()
    {
        shipVelocities = new ShipDriveVelocities(
                               new SpaceObjectAxisVelocity(10f, 15f) //
                               , new SpaceObjectAxisVelocity(5f, 5f)
                               , new SpaceObjectAxisVelocity(5f, 5f)
                               , new SpaceObjectAxisVelocity(3f, 3f)
                               , new SpaceObjectAxisVelocity(3f, 3f)
                               , new SpaceObjectAxisVelocity(3f, 3f)
                               );
    }
	// Use this for initialization
	void Start () {

        movement = new PlayerDriveShipMovement(shipVelocities, gameObject.GetComponent<Rigidbody>());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        //Debug.Log(this.rigidbody.velocity.magnitude);
        movement.move(null);
    }
}
