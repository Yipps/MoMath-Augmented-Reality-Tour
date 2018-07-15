using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour {

    public bool _bIsSelected = true;

    void OnDrawGizmos()
    {
        if (_bIsSelected)
            OnDrawGizmosSelected();
    }


    void OnDrawGizmosSelected()
    {
        //Bounds bounds = CalculateRendererBounds(gameObject);
        Bounds bounds = CalculateRendererBounds(gameObject);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(bounds.center, 0.1f);  //center sphere
        if (transform.GetComponent<Renderer>() != null)
            Gizmos.DrawWireCube(bounds.center, bounds.size);
    }

    public static Bounds CalculateRendererBounds(GameObject aObj)
    {
        if (aObj == null)
        {
            Debug.LogError("CalculateBoundingBox: object is null");
            return new Bounds(Vector3.zero, Vector3.one);
        }
        Transform myTransform = aObj.transform;
        Mesh mesh = null;
        MeshFilter mF = aObj.GetComponent<MeshFilter>();
        if (mF != null)
            mesh = mF.sharedMesh;
        else
        {
            SkinnedMeshRenderer sMR = aObj.GetComponent<SkinnedMeshRenderer>();
            if (sMR != null)
                mesh = sMR.sharedMesh;
        }
        if (mesh == null)
        {
            Debug.LogError("CalculateBoundingBox: no mesh found on the given object");
            return new Bounds(aObj.transform.position, Vector3.one);
        }
        Vector3[] vertices = mesh.vertices;
        if (vertices.Length <= 0)
        {
            Debug.LogError("CalculateBoundingBox: mesh doesn't have vertices");
            return new Bounds(aObj.transform.position, Vector3.one);
        }
        Vector3 min, max;
        min = max = myTransform.TransformPoint(vertices[0]);
        for (int i = 1; i < vertices.Length; i++)
        {
            Vector3 V = myTransform.TransformPoint(vertices[i]);
            for (int n = 0; n < 3; n++)
            {
                if (V[n] > max[n])
                    max[n] = V[n];
                if (V[n] < min[n])
                    min[n] = V[n];
            }
        }
        Bounds B = new Bounds();
        B.SetMinMax(min, max);
        return B;
    }
}
