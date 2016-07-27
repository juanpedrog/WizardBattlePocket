using UnityEngine;
using System.Collections;

public class VersusMode : MonoBehaviour {
    Animator anim;
    Controller controller;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        controller = GameObject.FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        anim.SetBool("Pressed",true);
        controller.versusMode = true;
        Invoke("pressed", 0.5f);
    }
    void pressed()
    {
        Application.LoadLevel("SelectionScene");
    }
}
