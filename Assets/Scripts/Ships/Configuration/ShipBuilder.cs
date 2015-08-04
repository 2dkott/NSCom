using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ShipBuilder : MonoBehaviour {

    public Transform shipModel;
    private ShipModelAnalyzer shipModelAnalyzer;
    IModelComponent[] ModelComponentsList;

    void Awake()
    {
        shipModelAnalyzer = new ShipModelAnalyzer(shipModel);
    }

	// Use this for initialization
	void Start () {
        shipModelAnalyzer.findAllComponents();
        ShipModelComponents = shipModelAnalyzer.ModelComponents;
        ModelComponentsList = GameObjectExtensions.GetInterfaces<IModelComponent>(gameObject);
        initModelComponetsInScripts(ModelComponentsList,shipModelAnalyzer.ModelComponents);
	}

    public ModelComponent findComponent(Type type)
    {
        foreach(ModelComponent component in this.ShipModelComponents)
        {
            Debug.Log(component);
            if (component.GetType().Name == type.Name) return component;
        }
        return null;
    }

    void initModelComponetsInScripts(IModelComponent[] ModelComponentsList, List<ModelComponent> ShipModelComponents)
    {
        foreach (IModelComponent mc in ModelComponentsList)
        {
            mc.defineModelComponent(ShipModelComponents);
        }

    }

    public List<ModelComponent> ShipModelComponents { get; private set; } 
}
