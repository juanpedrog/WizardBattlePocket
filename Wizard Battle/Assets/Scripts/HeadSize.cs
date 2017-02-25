using UnityEngine;
using System.Collections;

public class HeadSize : MonoBehaviour {

    // Use this for initialization
    void Start() {
        GameObject confirm = GameObject.Find("Selection");
        if (confirm != null)
        {
            if (GetComponent<Transform>().position.x < 0)
            {
                GetComponent<Transform>().localScale = new Vector3(0.815516f, 0.815516f, 0.815516f);
            }
            else
            {
                GetComponent<Transform>().localScale = new Vector3(-0.815516f, 0.815516f, 0.815516f);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
