﻿using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetBool("Pressed",true);
        switch (GetComponent<Transform>().name)
        {
            case "ButtonScore": Invoke("loadScore",0.5f); break;
            case "ButtonOptions": Invoke("loadOption", 0.5f); break;
            case "ButtonExit": Invoke("loadExit", 0.5f); break;
        }
    }
    void loadScore()
    {
        Application.LoadLevel("ScoreScene");
    }
    void loadOption()
    {
        Application.LoadLevel("OptionScene");
    }
    void loadExit()
    {
        Application.Quit();
    }
}