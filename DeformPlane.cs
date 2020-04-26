using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformPlane : MonoBehaviour
{
    MeshFilter meshFilter;

    Mesh PlaneMesh;

    Vector3[] verts;

    [SerializeField]
    float Radius;

    [SerializeField]
    float Power;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        PlaneMesh = meshFilter.mesh;

        verts = PlaneMesh.vertices;
    }

    public void DeformThisPlane(Vector3 PositionToDeform)
    {
        PositionToDeform = transform.InverseTransformPoint( PositionToDeform );

        for (int i = 0; i < verts.Length; i++)
        {
            float dist = (verts[i] - PositionToDeform).sqrMagnitude;

            if(dist < Radius)
            {
                verts[i] -= Vector3.up * Power;  
            }
        }

        PlaneMesh.vertices = verts;
    }
}
