using UnityEngine;
using System.Collections.Generic;

public enum WeaponTypes { SMALLGUN, MEDGUN, BIGGUN }

public class ShipWeaponSet
{
    public ShipWeaponSet(WeaponTypes type, string name)
    {
        Type = type;
        ResourcesName = name;
        Ammo = new List<KeyValuePair<string, int>>();
    }

    public bool chargeAmmo()
    {
        if (Ammo[0].Value != 0)
        {
            Ammo[0] = new KeyValuePair<string, int>(Ammo[0].Key, Ammo[0].Value - 1);
            return true;
        }
        else if (Ammo[0].Value == 0 & loadNewAmmo())
        {
            Ammo[0] = new KeyValuePair<string, int>(Ammo[0].Key, Ammo[0].Value - 1);
            return true;
        }
        return false;
    }

    bool loadNewAmmo()
    {
        if (Ammo.Count > 1)
        {
            Ammo.RemoveAt(0);
            return true;
        }
        else return false;
    }

    public void addAmmo(string ammoPath, int ammoAmount)
    {
        Ammo.Add(new KeyValuePair<string, int>(ammoPath, ammoAmount));
    }

    public WeaponTypes Type { get; private set; }
    public string ResourcesName { get; private set; }
    public KeyValuePair<string, int> CurrentAmmo { get { return Ammo[0]; } }
    public bool AmmoIsEmpty { get { if (Ammo.Count > 0) return false; else return true; } }
    List<KeyValuePair<string, int>> Ammo { get; set; }
}
