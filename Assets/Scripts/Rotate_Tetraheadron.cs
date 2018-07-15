using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Tetraheadron : MonoBehaviour {

    public Transform tetra;
    public Transform intersect;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // GET TOUCH 0
            Touch touch0 = Input.GetTouch(0);

            // APPLY ROTATION
            if (touch0.phase == TouchPhase.Moved)
            {
                tetra.transform.Rotate(touch0.deltaPosition.x * 0.5f, touch0.deltaPosition.y * 0.5f, 0f,Space.World);
                //tetra.position = new Vector3(tetra.position.x, 0.2f, tetra.position.z);
            }

        } else if(Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(1);
            intersect.transform.Translate(0, touch1.deltaPosition.y * .005f, 0);
        }
    }
}
