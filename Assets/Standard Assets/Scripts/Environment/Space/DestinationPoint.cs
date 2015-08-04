using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Destination
{
    Transform point;
    List<Transform> points;
    Transform thisGameobject;
    float distanceToPoint;
    float minDistanceToPoint;

    public Destination(Transform thisGameobject)
    {
        this.thisGameobject = thisGameobject;
    }

    public void addPoint(Transform point)
    {
        this.point = point;
    }

    public void addPointList(List<Transform> points)
    {
        this.points = points;
    }

    public Transform selectPoint()
    {
        return null;
        //distanceToPoint = (obj1.position - obj2.position).sqrMagnitude;

    }

    public Transform DestinationPoint { get { return this.point; } }
    public List<Transform> DestinationPointsList { get { return this.points; } }


}

