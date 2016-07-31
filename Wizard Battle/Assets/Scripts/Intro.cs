using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("begin", 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void begin()
    {
        Application.LoadLevel("MainMenuScene");
    }
}
