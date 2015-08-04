using UnityEngine;
using System.Collections;

public class MissionRecordLoader : XMLHandler<MissionRecord> {

    public MissionRecordLoader(string filePath)
        : base(Application.dataPath + "/Resources/" + filePath)
    {
        //definePath(filePath);
        this.MissionRecords = readFromResources();
    }

    public MissionRecord MissionRecords { get; private set; }
}
