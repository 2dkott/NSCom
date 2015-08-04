using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CloneObjectPositionEsitorSrc))]
public class CloneObjectPosition : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CloneObjectPositionEsitorSrc myScript = (CloneObjectPositionEsitorSrc)target;
        if (GUILayout.Button("Clone Postion"))
        {
            myScript.clonePostion();
        }
    }
}
