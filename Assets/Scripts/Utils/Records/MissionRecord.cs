using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class MissionRecord{

    [XmlArray("missionTitle")]
    public TextLang[] missionTitle;
    [System.Xml.Serialization.XmlElement("id")]
    public string missionId;

    public string MissionTitle { get { Debug.Log(missionTitle);  return TextManager.findTextByLang(missionTitle).text; } }

}
