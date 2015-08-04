using UnityEngine;
using System.Collections;

public class ControlDispatcher : MonoBehaviour
{
    RayCasting raycasting;
    bool currentCombatState;
    float currentFrameCount;

    void Awake()
    {
        currentCombatState = false;
        raycasting = new RayCasting();
    }

    public bool FirstShoot
    {
        get
        {
            if (Input.GetButton("Fire1")) return true;
            else return false;
        }
    }

    public bool SecondShoot
    {
        get
        {
            if (Input.GetButton("Fire2")) return true;
            else return false;
        }
    }

    public RayCasting CursorPoint
    {
        get
        {
            return raycasting.castFromMainCamera();
        }
    }

    public bool CombatState
    {
        get
        {
            if (currentFrameCount != Time.frameCount)
            {
                if (PlayerControls.Instance.Combat.Pressed)
                {
                    if (currentCombatState) currentCombatState = false;
                    else currentCombatState = true;
                }
                currentFrameCount = Time.frameCount;
            }
            return currentCombatState;
        }
    }
}