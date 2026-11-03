using UnityEngine;
using UnityEngine.UIElements;


[RequireComponent(typeof(MeshFilter))]
public class MeshRenderer : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    Mesh mesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }


    void CreateShape()
    {
        vertices = new Vector3[(xSize+1)*(zSize+1)];
        int i = 0;
        for (int z = 0; z <= zSize; z++)
        {
            for(int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;

            }
        }

        triangles = new int[xSize * zSize * 6];
        int Vert = 0;
        int tris = 0;
        for (int x = 0; x < xSize; x++)
        {
            
            triangles[tris + 0] = Vert + 0;
            triangles[tris + 1] = Vert + xSize + 1;
            triangles[tris + 2] = Vert + 1;
            triangles[tris + 3] = Vert + 1;
            triangles[tris + 4] = Vert + xSize + 1;
            triangles[tris + 5] = Vert + xSize + 2;
            Vert++;
            tris += 6;
        }

        
        //vertices = new Vector3[]
        //{
        //    new Vector3(0,0, 0),
        //    new Vector3(0,0, 1),
        //    new Vector3(1,0, 0),
        //    new Vector3(1,0, 1)
        //};

        //triangles = new int[]
        //{
        //    0,1,2,
        //    1,3,2
        //};
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null) return;
        for(int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }


}
