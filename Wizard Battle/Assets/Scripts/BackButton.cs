using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "soundBack");
        controller.survivalMode = false;
        controller.versusMode = false;
        Application.LoadLevel("MainMenuScene");
    }
}
