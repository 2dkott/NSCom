using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

    public Transform target;
    float rotationDamping = 4f;
    
    void FixedUpdate()
    {
        // Early out if we don't have a target
        if (!target) return;
        Quaternion currentRotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * rotationDamping);
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward;
        transform.rotation = currentRotation;
    }
}
