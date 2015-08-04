using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    public float TimeToDestroy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if ((TimeToDestroy -= Time.deltaTime) <= 0)
        {
            Destroy(this.gameObject);
        };
	
	}
}
