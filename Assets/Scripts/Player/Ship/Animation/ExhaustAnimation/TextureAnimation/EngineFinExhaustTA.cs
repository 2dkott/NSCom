using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EngineFinExhaustTA : MonoBehaviour, IEngineFlameAnimation
{

    public List<Transform> positiveFins;
    public List<Transform> negativeFins;
    private List<Material> posFinMaterials;
    private List<Material> negFinMaterials;
    private MaterialModification matModofication;

	void Start () {
        matModofication = new MaterialModification();
        posFinMaterials = new List<Material>();
        negFinMaterials = new List<Material>();

        foreach (Transform fin in positiveFins)
        {
            fin.GetComponent<Renderer>().material.color = matModofication.ChangeMaterialAplha(fin.GetComponent<Renderer>().material.color, 0f);
            posFinMaterials.Add(fin.GetComponent<Renderer>().material);
        }

        foreach (Transform fin in negativeFins)
        {
            fin.GetComponent<Renderer>().material.color = matModofication.ChangeMaterialAplha(fin.GetComponent<Renderer>().material.color, 0f);
            negFinMaterials.Add(fin.GetComponent<Renderer>().material);
        }
	
	}

    public void play(ShipControl control)
    {
        //Debug.Log(direction);
        if (control.AxisValue > 0)
        {
            foreach (Material finMaterial in posFinMaterials)
            {
                animateMaterialTransparent(finMaterial);
            }
        }
        else
        {
            foreach (Material finMaterial in posFinMaterials)
            {
                stopMaterialTransparent(finMaterial);
            }
        }

        if (control.AxisValue < 0)
        {
            foreach (Material finMaterial in negFinMaterials)
            {
                animateMaterialTransparent(finMaterial);
            }
        }
        else
        {
            foreach (Material finMaterial in negFinMaterials)
            {
                stopMaterialTransparent(finMaterial);
            }
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
            Debug.Log(sorceMaterial.color.a);
            sorceMaterial.color = matModofication.ChangeMaterialAplha(sorceMaterial.color, 1f);
        }
    }
}
