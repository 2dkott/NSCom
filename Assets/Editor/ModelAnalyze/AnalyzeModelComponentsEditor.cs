using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(AnalyzeModelComponentsEditorSrc))]
public class AnalyzeModelComponentsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AnalyzeModelComponentsEditorSrc myScript = (AnalyzeModelComponentsEditorSrc)target;
        if (GUILayout.Button("Update Model"))
        {
            myScript.UpdateModel();
        }
        
        if(GUILayout.Button("Analyze Compomemts"))
        {
            myScript.collectComponents();
        }
    }
}