using UnityEngine;
using System.Collections;

public class SelectWizard : MonoBehaviour {
    Controller controller;
    public int posPlayer;
    Animator anim;
	// Use this for initialization
	void Start () {
        controller = (Controller)GameObject.FindObjectOfType<Controller>();
        controller.isAlive = true;
        controller.just1player = true;
        controller.versus = true;
        controller.fillWizard();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if (controller.versusMode)
        {
            if (controller.versus) { 
                controller.posPlayer = posPlayer;
                controller.playerName = controller.wizard[posPlayer].name;
                controller.power = true;
                controller.versus = false;
                anim.SetBool("Attack",true);
                Invoke("unAttack", 0.5f);
                GameObject.Find("Text").GetComponent<TextMesh>().text="SELECT YOUR ENEMY";
            }
            else
            {
                anim.SetBool("Attack", true);
                controller.posEnemy = posPlayer;
                controller.enemyName = controller.wizard[posPlayer].name;
                controller.power = true;
                Invoke("unAttack",0.5f);
                Invoke("exitCharacters", 0.4f);
                Invoke("startFight", 0.8f);
            }
        }
        else
        {
            controller.posPlayer = posPlayer;
            controller.playerName = controller.wizard[posPlayer].name;
            controller.power = true;
            GetComponent<Animator>().SetBool("Attack", true);
            Invoke("unAttack", 0.5f);
            Invoke("exitCharacters",0.4f);
            Invoke("startFight",0.8f);
        }
    }
    void unAttack()
    {
        GetComponent<Animator>().SetBool("Attack",false);
    }
    void startFight()
    {
        NotificationCenter.DefaultCenter().PostNotification(this,"DestroySound");
        Application.LoadLevel("FightScene");
    }
    void exitCharacters()
    {
        GetComponent<Transform>().parent.gameObject.GetComponent<Animator>().SetBool("Exit", true);
    }
}
