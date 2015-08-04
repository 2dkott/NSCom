using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class DecalGenerator : MonoBehaviour
{
    public Material material;
    public Sprite sprite;

    public float maxAngle = 90.0f;
    public float pushDistance = 0.009f;
    public LayerMask affectedLayers = -1;
    
    DecalBuilder builder = new DecalBuilder();
    List<GameObject> decalList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        addDecal();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void addDecal()
    {
        GameObject decal = new GameObject();
        decal.AddComponent<MeshFilter>();
        MeshFilter filter = decal.GetComponent<MeshFilter>();
        decal.AddComponent<MeshRenderer>();
        decalList.Add(decal);
        DecalBuilder.Push(pushDistance);
        DecalBuilder.BuildDecalForObject(this, decal.transform, transform);
        Mesh mesh = DecalBuilder.CreateMesh();
        if (mesh != null)
        {
            mesh.name = "DecalMeshNew";
            filter.mesh = mesh;
        }
    }

}
