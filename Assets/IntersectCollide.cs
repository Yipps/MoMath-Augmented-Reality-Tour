using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectCollide : MonoBehaviour {

    public Material mat;
	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider tetra)
    {
        mat.SetColor("_Color", new Color(1f, 0.52f, 0.52f,0.4f));
        Debug.Log("Enter");
    }

    void OnTriggerExit(Collider tetra)
    {
        mat.SetColor("_Color", new Color(0.523f, 0.75f, 1f, 0.4f));
        Debug.Log("Exit");
    }
}
