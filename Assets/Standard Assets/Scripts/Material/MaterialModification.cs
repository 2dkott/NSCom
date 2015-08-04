using UnityEngine;
using System.Collections;

public class MaterialModification{

    Color ColorToUpdateAplha;

    public MaterialModification()
    {
        ColorToUpdateAplha = new Color();
    }

    public Color ChangeMaterialAplha(Color colorSorce, float alphaStrength)
    {
        ColorToUpdateAplha = colorSorce;
        ColorToUpdateAplha.a = alphaStrength;
        return ColorToUpdateAplha;
    }
}
