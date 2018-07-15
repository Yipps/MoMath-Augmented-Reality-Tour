using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderHeight : MonoBehaviour {

    public LineRenderer line;
    public GameObject tetra;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Bounds bound = BoundingBox.CalculateRendererBounds(tetra);
        float height = bound.size.y;
        line.SetPosition(1, new Vector3(-0.25f, height, 0));
	}
}
