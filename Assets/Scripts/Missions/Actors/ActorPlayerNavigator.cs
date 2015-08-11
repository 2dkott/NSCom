using UnityEngine;
using System.Collections;

public sealed class ActorPlayerNavigator : Actor {

    private static readonly ActorPlayerNavigator instance = new ActorPlayerNavigator();

    private ActorPlayerNavigator() : base()
    {
        base.Name = "Solon";
    }

    public ActorPlayerNavigator Instance { get { return instance; } }
}
