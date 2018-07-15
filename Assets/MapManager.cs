using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {


    public GameObject[] Marks;
    public TextMesh text;



	// Use this for initialization
	void Start () {
        StartCoroutine(StartAnimations());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator StartAnimations()
    {
        yield return new WaitForSeconds(2f);
        text.GetComponent<Animator>().SetTrigger("spawn");
        yield return new WaitForSeconds(2f);
        Marks[0].GetComponent<Animator>().SetTrigger("spawn");
        yield return new WaitForSeconds(1f);
        Marks[1].GetComponent<Animator>().SetTrigger("spawn");
        yield return new WaitForSeconds(1f);
        Marks[2].GetComponent<Animator>().SetTrigger("spawn");
        yield return new WaitForSeconds(0.5f);

    }
}
