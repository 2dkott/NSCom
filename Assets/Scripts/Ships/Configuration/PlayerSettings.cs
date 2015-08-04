using UnityEngine;
using System.Collections;

public class PlayerSettings : MonoBehaviour {

    
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(PlayerSettingsProvider.Instance.Settings.Velocity.z);
	}

    public Vector3 Velocity { get { return GetComponent<Rigidbody>().velocity; } }
}
