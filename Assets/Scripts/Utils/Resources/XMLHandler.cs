using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class XMLHandler<T>{

    XmlSerializer xmlSer;
    WWW xmlPath;
    string filePath;

    public XMLHandler()
    {
        xmlSer = new XmlSerializer(typeof(T));
    }

    public XMLHandler(string filePath)
    {
        xmlSer = new XmlSerializer(typeof(T));
        this.filePath = filePath;
        Debug.Log(this.filePath);
    }

    public IEnumerator definePath(string filePath)
    {
        //xmlPath = new WWW(Path.Combine(Application.dataPath, "/Resources/" + filePath));
        Debug.Log(xmlPath.text);
        yield return xmlPath;
    }

    public T readFromResources() {
        //TextAsset textAsset = (TextAsset)Resources.Load(filePath);

        //var serializer = new XmlSerializer(typeof(MonsterContainer));
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            return (T)xmlSer.Deserialize(stream);
        }

        //using (var reader = new StringReader(xmlPath.text))
        //{
        //    return (T)xmlSer.Deserialize(reader);
        //}
    }

    public void writeToResource(string filePath)
    {


    }
}
