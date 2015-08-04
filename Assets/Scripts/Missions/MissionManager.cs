using UnityEngine;
using System.Collections;

public class MissionManager
{
    private static readonly MissionManager instance = new MissionManager();

    private MissionManager() { }

    public static MissionManager Instance
    {
        get
        {
            return instance;
        }
    }
    


}

