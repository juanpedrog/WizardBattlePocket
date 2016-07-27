using UnityEngine;
using System.Collections;

public class NextButton : MonoBehaviour {
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        if (controller.ending)
        {
            GetComponent<TextMesh>().text = "FINISH";
            controller.bossTime = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        controller.noDamage = true;
        GetComponent<AudioSource>().Play();
        if (controller.ending)
        {
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
            controller.ending = false;
            Application.LoadLevel("MainMenuScene");
        }
        else {
            controller.power = true;
            if (controller.survivalMode)
            {
                if (controller.healthBar + 0.3f >= 1)
                {
                    controller.healthBar = 1;
                }
                else
                {
                    controller.healthBar += 0.3f;
                }
            }
            Application.LoadLevel("FightScene");
        }
    }
}
