using UnityEngine;
using System.Collections;

public class DamageReceiver : MonoBehaviour {




	// Use this for initialization
	void Start () {
	
	}

    public void getDamage(DamageData damageData)
    {
        Debug.Log("Hitted: " + damageData.Value);
        //Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject, damageData.HittedPoint, Quaternion.identity);
    }

}
