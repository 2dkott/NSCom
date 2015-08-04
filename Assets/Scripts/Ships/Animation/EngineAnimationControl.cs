using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EngineAnimationControl : MonoBehaviour, IModelComponent
{
    private EngineModelComponent engine;
    private List<ISpaceObjectAnimation> exhaustPositiveAniamtions;
    private List<ISpaceObjectAnimation> exhaustNegativeAniamtions;
    private AnimationByControl power;

    void Awake()
    {
        power = new AnimationByControl(PlayerControls.Instance.Power);
    }
    // Use this as Start() for initializations related to FinsModelComponent object
    public void defineModelComponent(List<ModelComponent> ShipModelComponents)
    {
        foreach (ModelComponent component in ShipModelComponents)
        {
            if (component.GetType().Name == typeof(EngineModelComponent).Name)
            {
                this.engine = component as EngineModelComponent;
            }
        }
        if (this.engine == null) Debug.LogError(this.name + " was not initialized");

        exhaustPositiveAniamtions = collectAnimations(engine.ExhaustPositive);
        exhaustNegativeAniamtions = collectAnimations(engine.ExhaustNegative);
    }
    
    List<ISpaceObjectAnimation> collectAnimations(List<Transform> componentList)
    {
        List<ISpaceObjectAnimation> aniamtionsList = new List<ISpaceObjectAnimation>();
        foreach (Transform component in componentList)
        {
            foreach (ISpaceObjectAnimation componentAnimation in GameObjectExtensions.GetInterfaces<ISpaceObjectAnimation>(component.gameObject))
            {
                aniamtionsList.Add(componentAnimation);
            }
        }
        return aniamtionsList;
    }
	
	// Update is called once per frame
	void Update () {
        power.playAnimationOfPosNegLists(exhaustPositiveAniamtions, exhaustNegativeAniamtions);
	}
}
