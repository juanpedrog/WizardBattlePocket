﻿using UnityEngine;
using System.Collections;

public class SurvivalButton : MonoBehaviour {
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
        AdManager.Instance.exitBanner();
        GetComponent<AudioSource>().Play();
        anim.SetBool("Pressed",true);
        controller.survivalMode = true;
        controller.fillWizard();
        Invoke("loadLevel",0.5f);
    }
    void loadLevel()
    {
        Application.LoadLevel("SelectionScene");
    }
}
