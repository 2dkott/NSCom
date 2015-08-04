using UnityEngine;
using System.Collections;

public class WaitingFor {

    VisualSensor visSensor;

    public WaitingFor(Transform hostTransform)
    {
        this.HostTransform = hostTransform;
        foreach(Transform child in hostTransform){
            if (child.GetComponent<VisualSensor>()) visSensor = child.GetComponent<VisualSensor>();
        }
    }

    public bool waiteForVisualContact(Transform target)
    {
        if (visSensor.LatestDetectedObject != null)
        {
            if (visSensor.LatestDetectedObject.GetInstanceID() == target.GetInstanceID()) return true;
            else return false;
        }
        else return false;
    }

    public Transform HostTransform { get; private set; }
}
