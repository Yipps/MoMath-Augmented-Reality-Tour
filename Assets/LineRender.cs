using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRender : MonoBehaviour {

	public LineRenderer line;
    public int maxX;
    private int currX;
    public float height { set; get; }
    public float speed { set; get; }
    public float angle { set; get; }

    public TextMesh t_height;
    public TextMesh t_speed;
    public TextMesh t_angle;

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>();
        InitRender();

        height = 0;
        speed = 30;
        angle = 45;
	}
	
	// Update is called once per frame
	void Update () {
        InitRender();
        AnimatePath();
        UpdateText();
	}

    void InitRender()
    {
        line.positionCount = currX;
        Vector3[] verts = new Vector3[maxX];

        for(int i = 0; i < currX; i++)
        {
            verts[i].x = i;
            verts[i].y = ComputeTrajectory(height, angle, speed, i);
            
        }

        line.SetPositions(verts);
    }


    float ComputeTrajectory(float height, float angle, float speed, int x)
    {
        return (float)(height - 4.9 * Mathf.Pow(x / (speed * Mathf.Cos(angle * (Mathf.PI / 180))), 2) + Mathf.Tan(angle * (Mathf.PI/180)) * x);
    }

    void AnimatePath()
    {
        currX = (int)Mathf.Repeat(Time.time * 40, maxX);
    }

    void UpdateText()
    {
        t_angle.text = "Angle: " + angle;
        t_height.text = "Height: " + height;
        t_speed.text = "Speed: " + speed;
    }
}
