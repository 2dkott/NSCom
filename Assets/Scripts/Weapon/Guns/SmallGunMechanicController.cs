using UnityEngine;
using System.Collections;

public class SmallGunMechanicController : MonoBehaviour
{

    HideUnhideAnimControl hideAnimControl;
    SeparateXYRotationMechanism xYRotationMechanism;
    GunneryManager GunneryManager;
    float step;

    // Use this for initialization
    void Start () {
        GunneryManager = GetComponent<GunneryManager>();
        hideAnimControl = GetComponent<HideUnhideAnimControl>();
        xYRotationMechanism = GetComponent<SeparateXYRotationMechanism>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        GunneryManager.State = WeaponStates.Hidden;

        if (GunneryManager.ShipControlDispatcher.CombatState)
        {
            hideAnimControl.Hide = false;
            if (!hideAnimControl.HideUnhideAnimIsPlaying)
            {
                xYRotationMechanism.Target = GunneryManager.ShipControlDispatcher.CursorPoint.HittedVector; 

                if (xYRotationMechanism.ReadyToTrace)
                {
                    if (xYRotationMechanism.IsLimited) GunneryManager.State = WeaponStates.Idle;
                    else GunneryManager.State = WeaponStates.ReadyToShoot;

                    xYRotationMechanism.state = SeparateXYRotationMechanism.TraceState.TRACE;
                }
                else
                {
                    xYRotationMechanism.state = SeparateXYRotationMechanism.TraceState.READYTOTRACE;
                }
            }
        }
        else
        {
            if (xYRotationMechanism.ReadyToAnimation) hideAnimControl.Hide = true;
            else xYRotationMechanism.state = SeparateXYRotationMechanism.TraceState.BACKTOANIM;
        }
    }
}
