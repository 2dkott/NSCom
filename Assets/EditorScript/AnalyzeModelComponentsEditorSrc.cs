using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class AnalyzeModelComponentsEditorSrc : MonoBehaviour
{
    public GameObject Model;
    public GameObject ModelSceneObject;
    public GameObject ModelRefrence;
    public bool ReplaceAll;
    private List<Transform> listOfModelComponents;
    private Regex regex = new Regex(@"^_[A-Za-z]+_");
    private Match match;
 
    public void collectComponents()
    {
         listOfModelComponents = new List<Transform>();
        foreach (Transform child in Model.transform)
        {
            listOfModelComponents.Add(child);
        }

        for (int i = 0; i < listOfModelComponents.Count; i++)
        {
            match = regex.Match(listOfModelComponents[i].name);
            if (match.Success)
            {
                if (ModelSceneObject.transform.FindChild(listOfModelComponents[i].name))
                {
                    if (ReplaceAll)
                    {
                        listOfModelComponents[i].parent = ModelSceneObject.transform;
                        ModelSceneObject.transform.FindChild(listOfModelComponents[i].name).position = listOfModelComponents[i].transform.position;
                        ModelSceneObject.transform.FindChild(listOfModelComponents[i].name).rotation = listOfModelComponents[i].transform.rotation;
                        try
                        {
                            ModelSceneObject.transform.FindChild(listOfModelComponents[i].name).gameObject.GetComponent<MeshFilter>().sharedMesh = listOfModelComponents[i].gameObject.GetComponent<MeshFilter>().sharedMesh;
                        }
                        catch (Exception e)
                        {
                            Debug.LogError(e);
                        }
                        DestroyImmediate(listOfModelComponents[i].gameObject);
                    }
                    else
                    {
                        DestroyImmediate(listOfModelComponents[i].gameObject);
                    }
                }
                else
                {
                    if (listOfModelComponents[i].gameObject.GetComponent<MeshFilter>() == null)
                    {
                        GameObject temp = new GameObject();
                        temp.name = listOfModelComponents[i].name;
                        temp.transform.position = listOfModelComponents[i].position;
                        temp.transform.rotation = listOfModelComponents[i].rotation;
                        temp.transform.parent = ModelSceneObject.transform;
                        DestroyImmediate(listOfModelComponents[i].gameObject);
                    }
                    else listOfModelComponents[i].parent = ModelSceneObject.transform;
                }
                listOfModelComponents.RemoveAt(i);
                i--;
            }
        }
    }

    public void UpdateModel()
    {
        DestroyImmediate(this.Model);
        this.Model = Instantiate(ModelRefrence, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        this.Model.transform.parent = this.ModelSceneObject.transform;
    }
}