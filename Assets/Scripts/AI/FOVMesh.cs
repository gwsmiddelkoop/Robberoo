using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVMesh : MonoBehaviour
{
    private FOW fov;
    private Mesh mesh;
    private RaycastHit2D hit;
    [SerializeField] float meshRes = 2;
    [SerializeField] public Vector3[] vertex;
    [SerializeField] public int[] triangles;
    public int stepCount;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        fov = GetComponentInParent<FOW>();
    }

    void LateUpdate()
    {
        MakeMesh();
    }

    void MakeMesh()
    {
        stepCount = Mathf.RoundToInt(fov.viewAngle * meshRes);
        float stepAngle = fov.viewAngle / stepCount;

        List<Vector3> viewVertex = new List<Vector3>();

        hit = new RaycastHit2D();

        for (int i = 0; i < stepCount; i++)
        {
            float angle = fov.transform.eulerAngles.y - fov.viewAngle / 2 + stepAngle * i;
            Vector3 dir = fov.DirFromAngle(angle, false);
            hit = Physics2D.Raycast(fov.transform.position, dir, fov.viewRadius, fov.ObstacleMask);

            if (hit.collider == null)
            {
                viewVertex.Add(transform.position + dir.normalized * fov.viewRadius);
            }
            else
            {
                viewVertex.Add(transform.position + dir.normalized * hit.distance);
            }
        }

        int vertexCount = viewVertex.Count + 1;

        vertex = new Vector3[vertexCount];
        triangles = new int[(vertexCount - 2) * 3];

        vertex[0] = Vector3.zero;

        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertex[i + 1] = transform.InverseTransformPoint(viewVertex[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3 + 2] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3] = i + 2;
            }
        }

        mesh.Clear();

        mesh.vertices = vertex;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
