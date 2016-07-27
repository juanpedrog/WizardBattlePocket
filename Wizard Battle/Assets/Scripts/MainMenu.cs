using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    Controller controller;
    bool ispaused=true;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnMouseDown()
    {
        if (ispaused)
        {
            GetComponent<AudioSource>().Play();
        }
        if (controller.survivalMode)
        {
            controller.saveScoreSurvival();
            controller.healthBar = 1;
        }
        else
        {
            if (controller.versusMode)
            {
                controller.saveScoreVersus();
            }
            else
            {
                controller.saveScore();
            }
        }
        controller.survivalMode = false;
        controller.versusMode = false;
        controller.score = 0;
        controller.noDamage = true;
        controller.bossTime = false;
        controller.noDamage = true;
        Invoke("loadMenu", 0.5f);
    }
    public void mainMenupause()
    {
        Time.timeScale = 1;
        controller.pause = true;
        ispaused = false;
        OnMouseDown();
    }
    void loadMenu()
    {
        Application.LoadLevel("MainMenuScene");
    }
}
