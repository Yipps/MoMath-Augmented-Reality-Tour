using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWall : MonoBehaviour {

    public GameObject prefab;
    public float spacingMult = 1;
    public float padding = 0;
    private List<GameObject> wall;
    private List<Vector3> targets;
    private bool isLooping = false;

	// Use this for initialization
	void Start () {
        wall = new List<GameObject>();
        targets = new List<Vector3>();
        for(int i = 0; i < 128; i++)
        {
            GameObject slab = Instantiate(prefab, transform);
            wall.Add(slab);
            
            slab.transform.position = new Vector3(i * spacingMult + padding, 3, 0);
            targets.Add(slab.transform.position);
        }

       

    }

    private void Update()
    {
        StartCoroutine(Sinwave());
        for (int i = 0; i < 128; i++)
        {
            wall[i].transform.position = Vector3.MoveTowards(wall[i].transform.position, targets[i], Time.deltaTime * 0.4f);

        }
    }

    // Update is called once per frame
    IEnumerator Sinwave() {
        if (!isLooping)
        {
            isLooping = true;
            for (int i = 0; i < 128; i++)
            {
                float value = Mathf.Sin(Time.time * 2);
                targets[i] = new Vector3(wall[i].transform.position.x, wall[i].transform.position.y, value);
                yield return new WaitForSeconds(0.05f);
            }
            isLooping = false;
            //yield return new WaitForSeconds(128 * 0.025f);
        }
    }

    //IEnumerator SinControl()
    //{
    //    while (true)
    //    {
    //        StartCoroutine(Sinwave());
    //        yield return new WaitForSeconds(3f);
    //    }
    //}
}
