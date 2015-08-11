using UnityEngine;
using System.Collections;

public class MissionTest : MonoBehaviour {

    missonNoTimeToExplane ntte;
    public Transform testobject;

	// Use this for initialization
	void Start () {
        ntte = new missonNoTimeToExplane();
        Debug.Log(ntte.Id);
    }
	
	// Update is called once per frame
	void Update () {

	}
}
