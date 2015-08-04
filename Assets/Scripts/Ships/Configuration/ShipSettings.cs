using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public class ShipSettings : MonoBehaviour {

    void Awake()
    {
        this.SmallGun = new ShipWeaponSet(WeaponTypes.SMALLGUN, ResourcesConstants.PathToGuns + "u_gun_small_Rail_B0");
        this.SmallGun.addAmmo(ResourcesConstants.PathToAmmo + "shell_01", 100000);
        this.SmallGun.addAmmo(ResourcesConstants.PathToAmmo + "shell_02", 10);
    }
    // Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

    //public ShipWeapon SmallGun { get; set; }
    public ShipWeaponSet SmallGun { get; private set; }
    public int SmallGunAmmo { get; set; }
}