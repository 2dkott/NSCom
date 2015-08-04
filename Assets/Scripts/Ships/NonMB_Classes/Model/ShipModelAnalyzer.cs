using System;
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ShipModelAnalyzer
{
    Transform shipModel;
    private FinsModelComponent fins;
    private Regex regex = new Regex(@"^_[A-Za-z]+_");
    private Match match;

    public ShipModelAnalyzer(Transform shipModelSceneObject)
    {
        this.shipModel = shipModelSceneObject;
        this.ModelComponents = new List<ModelComponent>();
    }

    public void findAllComponents()
    {
        foreach (Transform child in shipModel)
        {
            match = regex.Match(child.name);
            //Adding appropriate class for Model Component
            if (match.Success)
            {
                try
                {
                    getComponent(ModelComponents, match.Value.TrimEnd('_').TrimStart('_') + "ModelComponent").collect(child);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }

    private ModelComponent getComponent(List<ModelComponent> ModelComponents, string componentName)
    {
        foreach (ModelComponent component in ModelComponents)
        {
            if (component.GetType().Name == componentName)
            {
                return component;
            }
        }
        Type ComponentType = Type.GetType(componentName);
        object instance = Activator.CreateInstance(ComponentType);
        ModelComponents.Add(instance as ModelComponent);
        return instance as ModelComponent;
    }

    public List<ModelComponent> ModelComponents { get; private set; }
}




