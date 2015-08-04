using UnityEngine;
using System.Collections;
using System;

public class SeparateXYRotationMechanism : MonoBehaviour {

    public Transform yRoatationObject;
    public Transform xRoatationObject;
    public TraceState state;
    public enum TraceState { TRACE, BACKTOANIM, READYTOTRACE };
    public float minAngleLimite;
    public float maxAngleLimite;
    Quaternion initX;
    Quaternion localInitX;
    Quaternion initY;
    Quaternion localInitY;
    Quaternion lookRotByX;
    Quaternion lookRotByY;
    float timeStepToReadyTrace = 0f;
    float timeStepToReadyAnim = 0f;
    float limitedXAngle;
    
    // Use this for initialization
	void Start () {
        ReadyToAnimation = true;
        ReadyToTrace = false;
        Target = Vector3.zero;
	}

    public void prepareToAnimation(float timeSpeed)
    {
        timeStepToReadyTrace = 0f;
        if (timeStepToReadyAnim >= 1f)
        {
            ReadyToAnimation = true;
            ReadyToTrace = false;
        }
        else
        {
            timeStepToReadyAnim += Time.deltaTime * timeSpeed;
            xRoatationObject.localRotation = Quaternion.Lerp(lookRotByX, localInitX, timeStepToReadyAnim);
            yRoatationObject.localRotation = Quaternion.Lerp(lookRotByY, localInitY, timeStepToReadyAnim);
        }
    }

    public void prepareToTrace(Vector3 target, float timeSpeed)
    {
        timeStepToReadyAnim = 0f;

        if (timeStepToReadyTrace == 0f)
        {
            initX = xRoatationObject.rotation;
            localInitX = xRoatationObject.localRotation;
            initY = yRoatationObject.rotation;
            localInitY = yRoatationObject.localRotation;
        }

        if (timeStepToReadyTrace >= 1f)
        {
            ReadyToAnimation = false;
            ReadyToTrace = true;
        }
        else
        {
            yRoatationObject.LookAt(target);
            yRoatationObject.localEulerAngles = new Vector3(0f, yRoatationObject.localEulerAngles.y, 0f);

            xRoatationObject.LookAt(target);
            xRoatationObject.localEulerAngles = new Vector3(xRoatationObject.localEulerAngles.x, 0f, 0f);

            timeStepToReadyTrace += Time.deltaTime * timeSpeed;
            xRoatationObject.rotation = Quaternion.Lerp(initX, xRoatationObject.rotation, timeStepToReadyTrace);
            yRoatationObject.rotation = Quaternion.Lerp(initY, yRoatationObject.rotation, timeStepToReadyTrace);
        }
    }

    void traceTarget(Vector3 target)
    {
        if (target != Vector3.zero)
        {
            yRoatationObject.LookAt(Target);
            yRoatationObject.localEulerAngles = new Vector3(0f, yRoatationObject.localEulerAngles.y, 0f);
            lookRotByY = yRoatationObject.rotation;

            xRoatationObject.LookAt(Target);
            limitedXAngle = ClampAngle(xRoatationObject.localEulerAngles.x, maxAngleLimite, minAngleLimite);
            
            xRoatationObject.localEulerAngles = new Vector3(limitedXAngle, 0f, 0f);
            lookRotByX = xRoatationObject.rotation;
        }
    }

    float ClampAngle(float angle, float min, float max){
 
     if (angle<90f || angle>270f){       // if angle in the critic region...
         if (angle>180f) angle -= 360f;  // convert all angles to -180..+180
         if (max>180f) max -= 360f;
         if (min>180f) min -= 360f;
     }    
     angle = Mathf.Clamp(angle, min, max);
     if (angle<0f) angle += 360f;  // if angle negative, convert to 0..360
     return angle;
    }

    // Update is called once per frame
	void LateUpdate () {
        switch(state)
        {
            case TraceState.BACKTOANIM:
                prepareToAnimation(5f);
                break;
            case TraceState.TRACE:
                traceTarget(Target);
                break;
            case TraceState.READYTOTRACE:
                prepareToTrace(Target,5f);
                break;
        }
	}

    public Vector3 Target { get; set; }
    public bool ReadyToAnimation { get; private set;}
    public bool ReadyToTrace { get; private set;}
    public bool IsLimited
    {
        get
        {
            if (limitedXAngle == maxAngleLimite | limitedXAngle == minAngleLimite) return true;
            else return false;
        }
    }
}