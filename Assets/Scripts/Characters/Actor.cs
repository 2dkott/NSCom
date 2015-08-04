using UnityEngine;
using System.Collections;

public class Actor{

    public Actor(Transform actorTransform)
    {
        this.ActorTransform = actorTransform;
        this.Action_WaiteForAnotherActor = new WaitingFor(actorTransform);
    }

    

    public Transform ActorTransform { get; private set; }
    public WaitingFor Action_WaiteForAnotherActor { get; private set; }
}
