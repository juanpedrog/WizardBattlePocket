using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectWizard : MonoBehaviour {
    Controller controller;
    public int posPlayer;
    Animator anim;
    bool allow;
    public GameObject loading;
    public Canvas buttons;
	// Use this for initialization
	void Start () {
        controller = (Controller)GameObject.FindObjectOfType<Controller>();
        controller.isAlive = true;
        controller.just1player = true;
        controller.versus = true;
        controller.fillWizard();
        anim = GetComponent<Animator>();
        allow = true;
        switch (GetComponent<Transform>().name)
        {
            case "Boss1":
                if (controller.boss1Block)
                {
                    allow = true;
                    GetComponent<Transform>().gameObject.SetActive(true);
                    
                }
                else
                {
                    allow = false;
                }
                break;
            case "Boss2":
                if (controller.boss2Block)
                {
                    allow = true;
                    GetComponent<Transform>().gameObject.SetActive(true);
                }
                else
                {
                    allow = false;
                }
                break;
            case "Boss3":
                if (controller.boss3Block)
                {
                    allow = true;
                    GetComponent<Transform>().gameObject.SetActive(true);
                }
                else
                {
                    allow = false;
                }
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnMouseDown()
    {
        if (allow)
        {
            GetComponent<AudioSource>().Play();
            if (controller.versusMode)
            {
                if (controller.versus)
                {
                    controller.posPlayer = posPlayer;
                    controller.playerName = controller.wizard[posPlayer].name;
                    controller.power = true;
                    controller.versus = false;
                    //anim.SetBool("Attack",true);
                    //Invoke("unAttack", 0.5f);
                    GameObject.Find("Text").GetComponent<TextMesh>().text = "SELECT YOUR ENEMY";
                }
                else
                {
                    //anim.SetBool("Attack", true);
                    controller.posEnemy = posPlayer;
                    controller.enemyName = controller.wizard[posPlayer].name;
                    controller.power = true;
                    //Invoke("unAttack",0.5f);
                    //Invoke("exitCharacters", 0.4f);
                    Invoke("startFight", 0.8f);
                    NotificationCenter.DefaultCenter().PostNotification(this, "invokerEnemy");
                }
            }
            else
            {
                controller.posPlayer = posPlayer;
                controller.playerName = controller.wizard[posPlayer].name;
                controller.power = true;
                //GetComponent<Animator>().SetBool("Attack", true);
                //Invoke("unAttack", 0.5f);
                //Invoke("exitCharacters",0.4f);
                Invoke("startFight", 0.8f);
            }
            NotificationCenter.DefaultCenter().PostNotification(this, "invokerPlayer");
        }
        else
        {
            NotificationCenter.DefaultCenter().PostNotification(this,"block");
        }
    }
    void unAttack()
    {
        GetComponent<Animator>().SetBool("Attack",false);
    }
    void startFight()
    {
        NotificationCenter.DefaultCenter().PostNotification(this,"DestroySound");
        controller.scene = "FightScene";
        buttons.enabled = false; 
        loading.SetActive(true);
        Invoke("nextScene",2f);
    }
    void nextScene()
    {
        SceneManager.LoadSceneAsync(controller.scene);
    }
    void exitCharacters()
    {
        GetComponent<Transform>().parent.gameObject.GetComponent<Animator>().SetBool("Exit", true);
    }
}
