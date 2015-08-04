using UnityEngine;
using System.Collections;
using System;


public class ImpactGun : MonoBehaviour, IGunType {

    public int shotAmountPerSecond;
    public float damage;
    public Transform burrelPoint;
    Transform hittedGameobject;
    RayCasting rcasting;
    DamageData damageData;
    ParticleSystem gunflame;

	// Use this for initialization
	void Start () {
        rcasting = new RayCasting();
        damageData = new DamageData(damage);

        if (burrelPoint == null)
        {
            Debug.LogError("Gun Burrel Point is not recognized");
            burrelPoint = this.gameObject.transform;
        }

        gunflame = burrelPoint.GetComponent<ParticleSystem>();
	}

    public void shoot()
    {
        try
        {
            rcasting.custForwardWithDistance(burrelPoint, 10000f);
            if (rcasting.HittedTransformID != this.HostShip.GetInstanceID())
            {
                if (rcasting.HittedTransform != null)
                {
                    damageData.transmitDamage(rcasting.HittedTransform, damageData
                                                                        .setHittedPoint(rcasting.HittedVector)
                                                                        .setNormal(rcasting.HittedNormal)
                                                                        .setRayDiractionRotation(rcasting.DirectionRotation));
                }
                gunflame.Play();
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public float Rate { get { return 1f / shotAmountPerSecond; } }
    public Transform HostShip { set; get; }
}
