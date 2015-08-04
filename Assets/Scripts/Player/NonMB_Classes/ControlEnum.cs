using UnityEngine;
using System.Collections;

public sealed class ControlTypes
{
    private static readonly ControlTypes instance = new ControlTypes();


    private ControlTypes()
    {

    }


    public static ControlTypes Instance
    {
        get
        {
            return instance;
        }
    }

}
