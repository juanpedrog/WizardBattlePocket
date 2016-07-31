using UnityEngine;
using System.Collections;

public class TextInteractive : MonoBehaviour {

	// Use this for initialization
	void Start () {
        enter();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void enter()
    {
        gameObject.SetActive(false);
        Invoke("exit",0.3f);
    }
    void exit()
    {
        gameObject.SetActive(true);
        Invoke("enter",0.3f);
    }
}
