using System;
using System.Collections.Generic;
using UnityEngine;

public interface ISpaceMovement
{
    void move();
    
}

abstract public class SpaceMovement
{
    protected ShipDriveVelocities shipVelocities;

    public SpaceMovement(ShipDriveVelocities shipVelocities)
    {
        this.shipVelocities = shipVelocities;
    }

    public abstract void move(Transform destination);

}

