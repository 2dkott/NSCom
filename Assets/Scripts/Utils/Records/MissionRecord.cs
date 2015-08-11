using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class MissionRecord{

    [System.Xml.Serialization.XmlElement("missionTitle")]
    public string missionTitle;
    [System.Xml.Serialization.XmlElement("id")]
    public string missionId;

}
