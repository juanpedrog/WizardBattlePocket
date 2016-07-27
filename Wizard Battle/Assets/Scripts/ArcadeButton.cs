using UnityEngine;
using System.Collections;

public class ArcadeButton : MonoBehaviour {
    Animator anim;
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        controller.survivalMode = false;
        controller.versusMode = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        anim.SetBool("Pressed",true);
        Invoke("pressed",0.5f);
    }
    void pressed()
    {
        Application.LoadLevel("OpeningScene");
    }
}
