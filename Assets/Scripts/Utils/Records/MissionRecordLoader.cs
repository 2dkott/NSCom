using UnityEngine;
using System.Collections;

public class MissionRecordLoader : XMLHandler<MissionRecord> {

    public MissionRecordLoader(string filePath)
        : base(filePath)
    {
        this.MissionRecords = readFromResources();
    }

    public MissionRecord MissionRecords { get; private set; }
}
