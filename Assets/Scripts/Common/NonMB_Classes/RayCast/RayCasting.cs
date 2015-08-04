using System;
using System.Collections.Generic;
using UnityEngine;


public class RayCasting
{
    RaycastHit hit = new RaycastHit();
    Ray castingRay;
    float currentFrameCount;
    Vector3 direction;

    //Method is called once per frame only
    public RayCasting castFromMainCamera()
    {
        if (currentFrameCount != Time.frameCount)
        {
            castingRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(castingRay, out hit, 100000f))
            {
                if (hit.transform != null)
                {
                    this.HittedTransform = hit.transform;
                    this.HittedVector = hit.point;
                }
                else this.HittedTransform = null;
            }
            else { this.HittedVector = castingRay.GetPoint(100000f); }
            currentFrameCount = Time.frameCount;
        }
        return this;

    }

    public void custForwardWithDistance(Transform source, float distance)
    {
        direction = source.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(source.position, direction, out hit, distance))
        {
            if (hit.transform != null)
            {
                this.HittedTransform = hit.transform;
                this.HittedVector = hit.point;
                this.HittedNormal = Quaternion.FromToRotation(Vector3.up, hit.normal);
                this.DirectionRotation = Quaternion.LookRotation(direction);
            }
         }
        else this.HittedTransform = null;
    }

    public Transform HittedTransform { get; private set; }
    public int HittedTransformID { get
        {
            if (this.HittedTransform != null) return this.HittedTransform.GetInstanceID();
            else return 0;
        }
    }
    public Vector3 HittedVector { get; private set; }
    public Quaternion HittedNormal { get; private set; }
    public Quaternion DirectionRotation { get; private set; }

}

