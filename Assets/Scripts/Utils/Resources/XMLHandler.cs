using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class XMLHandler<T>{

    XmlSerializer xmlSer;
    string filePath;

    public XMLHandler(string filePath)
    {
        xmlSer = new XmlSerializer(typeof(T));
        this.filePath = filePath;
    }

    public T readFromResources() {
        TextAsset textAsset = (TextAsset)Resources.Load(filePath);
        using (var reader = new StringReader(textAsset.text))
        {
            return (T)xmlSer.Deserialize(reader);
        }
    }
}
