using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectVerts : MonoBehaviour
{

    [SerializeField]
    GameObject marker = null;
    bool enable = false;
    ContactPoint[] verts;
    List<Vector3> colPoints = new List<Vector3>();
    public List<GameObject> vertPoints = new List<GameObject>();
    
    private void Update()
    {
        if (enable)
        {
            DrawRays(verts);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "box")
        {
            print("collision");
            colPoints.Clear();
            print(collision.gameObject.name);
            verts = collision.contacts;
            Mesh mesh = collision.gameObject.GetComponent<MeshFilter>().mesh;
            MeshRenderer m_Renderer = collision.gameObject.GetComponent<MeshRenderer>();
            Vector3[] colVerts = mesh.vertices;
            print(mesh.vertices);
            for (int i = 0; i < colVerts.Length; i++)
            {
                colPoints.Add(colVerts[i]);
            }
            foreach (ContactPoint point in verts)
            {
                colPoints.Add(point.point);
            }
            foreach (Vector3 point in colPoints)
            {
                vertPoints.Add(Instantiate(marker, point, transform.rotation));
            }
            print(colPoints.Count);
            mesh.vertices = colPoints.ToArray();
            //mesh.RecalculateBounds();
            //mesh.RecalculateNormals();
            //mesh.RecalculateTangents();
            enable = true;
        }
    }
    void DrawRays(ContactPoint[] verts)
    {
        foreach(ContactPoint point in verts)
        {
            Debug.DrawRay(point.point, point.normal, Color.blue);
        }
    }

}
