using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipWeaponMounting : MonoBehaviour, IModelComponent
{
    //public Transform Gun;
    private GunsModelComponent guns;
    private List<GameObject> smallGunsList;
    private ShipSettings shipSettings;

    // Use this for initialization
    void Awake()
    {
        shipSettings = gameObject.GetComponent<ShipSettings>();
    }

    void Start () {
	}

    public void defineModelComponent(List<ModelComponent> ShipModelComponents)
    {
        foreach (ModelComponent component in ShipModelComponents)
        {
            if (component.GetType().Name == typeof(GunsModelComponent).Name)
            {
                this.guns = component as GunsModelComponent;
            }
        }
        if (this.guns == null) Debug.LogError(this.name + " was not initialized");
        
        //Define Small Gun Model is set on Ship Settings
        GameObject smallGun = Resources.Load(shipSettings.SmallGun.ResourcesName) as GameObject;
        
        //List of Small Guns Gameobjects placed on ship body based on predefined small gun positions
        smallGunsList = placeGunsOnPosition(smallGun, guns.SmallGunPositions);
    }

    List<GameObject> placeGunsOnPosition(GameObject gunSource, List<Transform> positionList)
    {
        List<GameObject> guns = new List<GameObject>();
        GameObject gun;
        //gunSource.GetComponent<WeaponSettings>().setShipTransform(transform);
        StopAllComponents(gunSource);
        foreach (Transform position in positionList)
        {
            gun = Instantiate(gunSource, position.position, position.rotation) as GameObject;
            gun.name = position.name + "_" + gun.name;
            gun.transform.parent = position;
            guns.Add(gun);
            StartAllComponents(gun);
        }
        return guns;
    }

    void StopAllComponents(GameObject gameobject)
    {
        MonoBehaviour[] scriptList = gameobject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scriptList)
        {
                script.enabled = false;
        }
    }

    void StartAllComponents(GameObject gameobject)
    {
        MonoBehaviour[] scriptList = gameobject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scriptList)
        {
                script.enabled = true;
        }
    }
	// Update is called once per frame
	void Update ()
    {
	}
}