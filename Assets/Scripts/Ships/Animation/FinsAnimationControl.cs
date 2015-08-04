using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FinsAnimationControl : MonoBehaviour, IModelComponent
{

    private FinsModelComponent fins;
    private List<ISpaceObjectAnimation> pitchPositiveAniamtions;
    private List<ISpaceObjectAnimation> pitchNegativeAniamtions;
    private List<ISpaceObjectAnimation> yawPositiveAniamtions;
    private List<ISpaceObjectAnimation> yawNegativeAniamtions;
    private List<ISpaceObjectAnimation> strafeVPositiveAniamtions;
    private List<ISpaceObjectAnimation> strafeVNegativeAniamtions;
    private List<ISpaceObjectAnimation> strafeHPositiveAniamtions;
    private List<ISpaceObjectAnimation> strafeHNegativeAniamtions;
    private AnimationByControl pitch;
    private AnimationByControl yaw;
    private AnimationByControl strafeV;
    private AnimationByControl strafeH;

    void Awake()
    {
        pitch = new AnimationByControl(PlayerControls.Instance.Vertical);
        yaw = new AnimationByControl(PlayerControls.Instance.Horizontal);
        strafeV = new AnimationByControl(PlayerControls.Instance.VerticStrafe);
        strafeH = new AnimationByControl(PlayerControls.Instance.HorizStrafe);
    }

    void Start()
    {
    }

    // Use this as Start() for initializations related to FinsModelComponent object
    public void defineModelComponent(List<ModelComponent> ShipModelComponents)
    {
        foreach (ModelComponent component in ShipModelComponents)
        {
            if (component.GetType().Name == typeof(FinsModelComponent).Name)
            {
                this.fins = component as FinsModelComponent;
            }
        }
        if (this.fins == null) Debug.LogError(this.name + " was not initialized");

        pitchPositiveAniamtions = collectAnimations(fins.PitchPositive);
        pitchNegativeAniamtions = collectAnimations(fins.PitchNegative);
        yawPositiveAniamtions = collectAnimations(fins.YawPositive);
        yawNegativeAniamtions = collectAnimations(fins.YawNegative);
        strafeVPositiveAniamtions = collectAnimations(fins.StrafeVPositive);
        strafeVNegativeAniamtions = collectAnimations(fins.StrafeVNegative);
        strafeHPositiveAniamtions = collectAnimations(fins.StrafeHPositive);
        strafeHNegativeAniamtions = collectAnimations(fins.StrafeHNegative);    
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

    void Update()
    {
        pitch.playAnimationOfPosNegLists(pitchPositiveAniamtions, pitchNegativeAniamtions);
        yaw.playAnimationOfPosNegLists(yawPositiveAniamtions, yawNegativeAniamtions);
        strafeV.playAnimationOfPosNegLists(strafeVPositiveAniamtions, strafeVNegativeAniamtions);
        strafeH.playAnimationOfPosNegLists(strafeHPositiveAniamtions, strafeHNegativeAniamtions);
    }
}

public class AnimationByControl
{
    private ShipControl control;
    private float previouseControlValue;

    public AnimationByControl(ShipControl control)
    {
        this.control = control;
    }

    public void playAnimationOfPosNegLists(List<ISpaceObjectAnimation> positibeAnimations, List<ISpaceObjectAnimation> negativeAnimations)
    {
        //End previouse animations
        if (previouseControlValue != control.AxisValue)
        {
            if (previouseControlValue > 0) foreach (ISpaceObjectAnimation animation in positibeAnimations) { animation.play(false); }
            if (previouseControlValue < 0) foreach (ISpaceObjectAnimation animation in negativeAnimations) { animation.play(false); }
        }

        //Start required animations
        if (control.AxisValue > 0)
        {
            foreach (ISpaceObjectAnimation animation in positibeAnimations) { animation.play(true); }
        }
        if (control.AxisValue < 0)
        {
            foreach (ISpaceObjectAnimation animation in negativeAnimations) { animation.play(true); }
        }

        previouseControlValue = control.AxisValue;
    }
}