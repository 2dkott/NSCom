using UnityEngine;
using System.Collections;

public class SpaceSettings : MonoBehaviour {

    public bool gravity;

    void Awake()
    {
        if (gravity)
        {
            Physics.gravity = new Vector3(0, 0, 0);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
