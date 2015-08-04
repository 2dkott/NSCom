using UnityEngine;
using System.Collections;

public enum WeaponStates { Hidden, ReadyToShoot, Idle }

public class GunneryManager : MonoBehaviour
{

    public Transform barrelPoint;
    public int fireRate;
    float rate;
    GameObject shell;
    //WeaponSettings weaponSettings;
    string currentShellPath;
    RaycastHit hit;
    Vector3 barrelPointDirection;
    public float damage;
    Transform[] weaponChildren;
    DamageData damageData;
    IGunType gun;
    
	// Use this for initialization
	void Start () {
        //weaponSettings = GetComponent<WeaponSettings>();
        

        rate = gun.Rate;
        State = WeaponStates.Hidden;
        if (damage == 0f) { Debug.LogError("Weapon: " + transform.name + " has 0 damage!"); }
        damageData = new DamageData(damage);

        //Load current ammo in the start scene
        if (!this.ShipSettings.SmallGun.AmmoIsEmpty)
        {
            loadShell(this.ShipSettings.SmallGun.CurrentAmmo.Key);
        }
        
        InvokeRepeating("fire", 0f, rate);
	}

    void loadShell(string pathToPrefab)
    {
        shell = Resources.Load(pathToPrefab) as GameObject;
        currentShellPath = pathToPrefab;
    }

    void OnEnable()
    {
        gun = GameObjectExtensions.GetInterface<IGunType>(this.gameObject);
        gun.HostShip = transform.root;
        ShipSettings = transform.root.GetComponent<ShipSettings>();
        ShipControlDispatcher = transform.root.GetComponent<ControlDispatcher>();
        weaponChildren = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in weaponChildren)
        {
            if (child.name.Contains(Constants.BarrelPointSuffix))
            {
                BarrelPoint = child;
            }
        }
    }

    void fire()
    {
        if (!ShipControlDispatcher.FirstShoot) return;
        if (State != WeaponStates.ReadyToShoot) return;

        if (ShipSettings.SmallGun.chargeAmmo())
        {
            //Load new Ammo if exist
            if (ShipSettings.SmallGun.CurrentAmmo.Key != currentShellPath)
            {
                loadShell(ShipSettings.SmallGun.CurrentAmmo.Key);
                return;
            }

            gun.shoot();
            //Instantiate(shell, barrelPoint.position,barrelPoint.rotation);
        }
    }

    public WeaponStates State { get; set; }
    public ShipSettings ShipSettings { get; private set; }
    public ControlDispatcher ShipControlDispatcher { get; private set; }
    public Transform BarrelPoint { get; private set; }

}
