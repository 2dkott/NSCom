using UnityEngine;
using System.Collections;

public class GunShot
{
    Transform gunSource;
    Vector3 gunSourceDirection;
    Transform ownShip;
    RaycastHit hit = new RaycastHit();

    public GunShot(Transform gunSource)
    {
        this.gunSource = gunSource;
    }

    public GunShot(Transform gunSource, Transform ownShip)
    {
        this.gunSource = gunSource;
        this.ownShip = ownShip;
    }

    public void shootWithRayStraight(DamageData damage)
    {
        gunSourceDirection = gunSource.TransformDirection(Vector3.forward);
        if (Physics.Raycast(gunSource.position, gunSourceDirection, out hit, 10000f))
        {
            if (hit.transform != null)
            {
                //this.HittedTransform = hit.transform;
                //this.HittedVector = hit.point;
            }
            else
            {

            }
        }
    }

}
