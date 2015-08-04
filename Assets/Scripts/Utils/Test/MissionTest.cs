using UnityEngine;
using System.Collections;

public class MissionTest : MonoBehaviour {

    MissionRecordLoader jsonHandler;
    Actor hostActor;
    public Transform testobject;

	// Use this for initialization
	void Start () {
        MissionRecord missonRecords;
        jsonHandler = new MissionRecordLoader("Missions/FirstMission.xml");
        missonRecords = jsonHandler.MissionRecords;
        hostActor = new Actor(gameObject.transform);
        Debug.Log(jsonHandler.MissionRecords.missionTitle);
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(hostActor.Action_WaiteForAnotherActor.waiteForVisualContact(testobject));
	}
}
