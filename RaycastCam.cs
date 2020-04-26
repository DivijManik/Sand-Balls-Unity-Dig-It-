using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCam : MonoBehaviour
{

    Ray ray;
    RaycastHit Hit;

    Camera cam;

    [SerializeField]
    Transform ringPrefab;

    Vector3 LastPos;

    private void Start()
    {
        cam = transform.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            DeformMesh();
        }
    }

    void DeformMesh()
    {
        if ((LastPos - Input.mousePosition).sqrMagnitude > 2)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out Hit))
            {
                // Deform mesh

                DeformPlane deformPlane = Hit.transform.GetComponent<DeformPlane>();
                if (deformPlane)
                {
                    deformPlane.DeformThisPlane(Hit.point);

                    Instantiate(ringPrefab, new Vector3(Hit.point.x, Hit.point.y, Hit.point.z + 0.11f), Quaternion.Euler(-90, 0, 0));
                }
            }

            LastPos = Input.mousePosition;
        }
    }

}

