using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mission {

    MissionRecord missionRecords;
    List<Act> actList;

    public Mission(string pathToMissionRecord)
    {
        MissionRecordLoader recordLoader = new MissionRecordLoader(pathToMissionRecord);
        missionRecords = recordLoader.MissionRecords;
    }

    public string Title { get { return missionRecords.missionTitle; } }
    public string Id { get { return missionRecords.missionId; } }




}
