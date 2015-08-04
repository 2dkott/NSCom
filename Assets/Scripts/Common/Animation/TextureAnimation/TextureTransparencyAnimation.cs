using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextureTransparencyAnimation : MonoBehaviour, ISpaceObjectAnimation
{

    private MaterialModification matModofication;
    private bool startAnimation;
	
    void Start () {
        matModofication = new MaterialModification();
        gameObject.GetComponent<Renderer>().material.color = matModofication.ChangeMaterialAplha(gameObject.GetComponent<Renderer>().material.color, 0f);
        this.startAnimation = false;
	}

    public void play(bool start)
    {
        
        this.startAnimation = start;

        if (this.startAnimation)
        {
           animateMaterialTransparent(gameObject.GetComponent<Renderer>().material);
        }
        else
        {
            stopMaterialTransparent(gameObject.GetComponent<Renderer>().material);
        }
    }
    
    void stopMaterialTransparent(Material sorceMaterial)
    {
        if (sorceMaterial.color.a != 0f)
        {
            sorceMaterial.color = matModofication.ChangeMaterialAplha(sorceMaterial.color, 0f);
        }
    }

    void animateMaterialTransparent(Material sorceMaterial)
    {
        if (sorceMaterial.color.a != 1f)
        {
            sorceMaterial.color = matModofication.ChangeMaterialAplha(sorceMaterial.color, 1f);
        }
        this.startAnimation = false;
    }
}
