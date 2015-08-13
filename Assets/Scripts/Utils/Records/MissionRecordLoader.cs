using UnityEngine;
using System.Collections;

public class MissionRecordLoader : XMLHandler<MissionRecord> {

    public MissionRecordLoader(string filePath)
        : base(filePath)
    {
    }

    public MissionRecord MissionRecords { get { return readFromResources(); }}
}
