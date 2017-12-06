using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),
    typeof(MeshRenderer), typeof(MeshCollider))]
public class ChunkGenerator : MonoBehaviour
{

    public bool dummyVar;
    public bool showVertices;

    public Datas datas;
    private Mesh mesh;

    private Vector3 pos;

    private void Start() { }

    public void Generate(
        object o = null, 
        EventArgs args = null)
    {
        GetReferences();
        pos = transform.position;
        mesh = TerrainGenerator.Generate(ref datas, pos);
    }

    private void GetReferences()
    {
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void OnDrawGizmos()
    {
        if (mesh && showVertices)
        {
            foreach (Vector3 v in mesh.vertices)
                Gizmos.DrawSphere(v, 0.1f);
        }
    }
    
    private void OnValidate()
    {
        if (datas)
        {
            datas.DiscardEventReferences();
            datas.updateEvent += Generate;
        }
    }
}
