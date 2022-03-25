using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAxeVerts : MonoBehaviour
{
    [SerializeField] GameObject marker = null;              //Prefab obj
    List<GameObject> markers = new List<GameObject>();      //List of instantiated markers


    /*Get all vertices in model, remove if z position > -0.35
     * and return total output as array to caller*/
    public Vector3[] getVerts(Mesh mesh)
    {
        List<Vector3> vertices = new List<Vector3>();
        foreach(Vector3 point in mesh.vertices)
        {
            if(point.z < -0.35f)
            {
                vertices.Add(point);
            }
        }
        return vertices.ToArray();
    }

    public int[] getTris(Mesh mesh)
    {
        int[] tris = mesh.GetTriangles(0);
        foreach(int num in tris)
        {
            print(num);
        }
        return tris;
    }


    //create a new marker and add to list at each vertex received
    private void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] verts = getVerts(mesh);
        int[] value = getTris(mesh);
        for (int i = 0; i < verts.Length; i++)
        {
            markers.Add(Instantiate(marker, verts[i], transform.rotation, gameObject.transform));
        }

    }
            
}
