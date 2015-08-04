using UnityEngine;
using System.Collections;

public class CloneObjectPositionEsitorSrc : MonoBehaviour
{
    public Transform Source;
    public Transform Destination;
	// Use this for initialization
    public void clonePostion()
    {
        Source.position = Destination.position;
    }
}
