using UnityEngine;
using System.Collections.Generic;

//public enum WeaponStates { Hidden, ReadyToShoot, Idle}

public class WeaponSettings : MonoBehaviour
{
    public float damage;
    Transform [] weaponChildren;
    DamageData damageData;

    void OnEnable()
    {
        ShipTransform = transform.root;
        ShipSettings = ShipTransform.GetComponent<ShipSettings>();
        ShipControlDispatcher = ShipTransform.GetComponent<ControlDispatcher>();
        weaponChildren = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in weaponChildren){
            if (child.name.Contains(Constants.BarrelPointSuffix))
            {
                BarrelPoint = child;
            }
        }
    }

    void Start()
    {
        State = WeaponStates.Hidden;
        if (damage == 0f) { Debug.LogError("Weapon: " + transform.name + " has 0 damage!"); }
        damageData = new DamageData(damage);
    }

    public WeaponStates State { get; set; }
    public Transform ShipTransform { get; private set; }
    public ShipSettings ShipSettings { get; private set; }
    public ControlDispatcher ShipControlDispatcher { get; private set; }
    public Transform BarrelPoint { get; private set; }


}
