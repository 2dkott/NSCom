using UnityEngine;
using System.Collections;

public class CameraClippingSettings : MonoBehaviour {

	// Use this for initialization
    public int defaultClippingDistance;
    public int BigObjectClippingDistance;

	void Start () {

        float[] distances = new float[32];

        for (int i = 0; i<32; i++)
        {
            if (LayerMask.LayerToName(i) != "UnclippingObjects")
            {
                distances[i] = defaultClippingDistance;
            }
            else
            {
                distances[i] = BigObjectClippingDistance;
            }
            GetComponent<Camera>().layerCullDistances = distances;
        }
	}
}
