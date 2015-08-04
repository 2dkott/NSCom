using UnityEngine;
using System.Collections;

public class DamageData {

    public DamageData(float damageValue)
    {
        this.Value = damageValue;
    }
    
    public DamageData setHittedPoint(Vector3 point)
    {
        this.HittedPoint = point;
        return this;
    }

    public DamageData setNormal(Quaternion normalRotation)
    {
        this.HittedNormal = normalRotation;
        return this;
    }

    public DamageData setRayDiractionRotation(Quaternion directionRotation)
    {
        this.DirectionRotation = directionRotation;
        return this;
    }

    public void transmitDamage(Transform damageTarget, DamageData damage)
    {
        if (damageTarget.GetComponent<DamageReceiver>())
        {
            damageTarget.GetComponent<DamageReceiver>().getDamage(damage);
        }
        else
        {
            GameObject delay = Resources.Load("Prefabs/Objects/Effects/CommonImpactExplosion") as GameObject;
            Object.Instantiate(delay, this.HittedPoint, this.DirectionRotation * Quaternion.Euler(-180, 0, 0));
        }
    }

    public float Value { get; private set;}
    public Vector3 HittedPoint {get; private set;}
    public Quaternion HittedNormal { get; private set; }
    public Quaternion DirectionRotation { get; private set; }
}
