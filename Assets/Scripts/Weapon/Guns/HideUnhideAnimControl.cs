using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Animator should contain animations with names "hide" and "unhide" 
 */
public class HideUnhideAnimControl : MonoBehaviour {

    public GameObject ObjectWithAnimation;
    Animator animator;
    bool currentState;

    // Use this for initialization
	void Start () {
        Hide = true;
        animator = ObjectWithAnimation.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idleUnhidden")) HideUnhideAnimIsPlaying = false;
        else HideUnhideAnimIsPlaying = true;

        if (!Hide & currentState != Hide)
        {
            currentState = Hide;
            animator.SetBool("hide", false);
        }
        else if (Hide & currentState != Hide)
        {
            currentState = Hide;
            animator.SetBool("hide", true);
        }
	}
    public bool Hide { get; set; }
    public bool HideUnhideAnimIsPlaying { get; private set; }
}
