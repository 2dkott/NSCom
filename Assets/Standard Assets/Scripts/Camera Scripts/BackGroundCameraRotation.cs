﻿using UnityEngine;
using System.Collections;

public class BackGroundCameraRotation : MonoBehaviour {

    public Camera MainCamera;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.rotation = MainCamera.transform.rotation;
	}
}
