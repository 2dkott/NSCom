using UnityEngine;
using System.Collections;

public class VisualSensor : MonoBehaviour {

    public int radius;
    SphereCollider sphereCollider;

	// Use this for initialization
	void Start () {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        sphereCollider.radius = radius;
	}

    void OnTrigger(Collider detectedObject)
    {
        this.LatestDetectedObject = detectedObject.transform;
    }

    public Transform LatestDetectedObject { get; private set; }
}
