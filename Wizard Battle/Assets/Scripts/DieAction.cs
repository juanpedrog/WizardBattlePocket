using UnityEngine;
using System.Collections;

public class DieAction : MonoBehaviour {
    public bool isPlayer;
    public GameObject player, enemy;
    private Controller controller;
    public GameObject canvas;
    Inteligencia[] arr;
    // Use this for initialization
    void Start () {
        if (isPlayer)
        {
            player = gameObject;
        }
        else
        {
            enemy = gameObject;
        }
        controller = GameObject.FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            NotificationCenter.DefaultCenter().AddObserver(this, "DieNotification");
        }
        if (enemy != null)
        {
            NotificationCenter.DefaultCenter().AddObserver(this, "DieEnemyNotification");
            NotificationCenter.DefaultCenter().AddObserver(this,"reactive");
        }
    }
    private void DieNotification(Notification notification)
    {
        blockAttack();
        die();
    }
    public void die()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "stop");
        player.GetComponent<Animator>().SetBool("Die",true);
        if (controller.survivalMode)
        {
            controller.healthBar = 1;
        }
        Instantiate(controller.GameOverPlayer, new Vector3(0, 0, -5.8f), Quaternion.identity);
        NotificationCenter.DefaultCenter().PostNotification(this, "saveScore");
        controller.isAlive = false;
        controller.power = false;
    }
    private void DieEnemyNotification(Notification notification)
    {
        blockAttack();
        dieEnemy();
    }
    public void dieEnemy()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "saveScore");
        NotificationCenter.DefaultCenter().PostNotification(this, "stop");
        arr=GameObject.FindObjectsOfType<Inteligencia>();
        for (int i=0; i<arr.Length;i++)
        {
            arr[i].gameObject.SetActive(false);
        }
        enemy.GetComponent<Animator>().SetBool("Die", true);
        controller.isAlive = false;
        controller.power = false;
        controller.bossTime = checkEnemys() ? false : true;
        controller.backgroundboss1 = checkEnemys() ? false : true;

        if (GetComponent<Transform>().parent.name.Equals("Boss1Enemy(Clone)"))
        {
            if (controller.dataObject.difficulty == 3 && !controller.boss1Block)
            {
                controller.UnblockBoss1();
            }
            controller.bossTime = false;
            if (!controller.versusMode)
            {
                controller.ending = true;
                Invoke("ending",2f);
            }
        }
        if (GetComponent<Transform>().parent.name.Equals("Boss2Enemy(Clone)"))
        {
            if (controller.dataObject.difficulty == 3 && controller.survivalMode && !controller.boss2Block)
            {
                controller.UnblockBoss2();
            }
            controller.bossTime = false;
            if (!controller.versusMode)
            {
                controller.ending = true;
                Invoke("ending", 2f);
            }
        }
        if (GetComponent<Transform>().parent.name.Equals("Boss3Enemy(Clone)"))
        {
            if (controller.dataObject.difficulty == 3 && controller.survivalMode && controller.posPlayer < 7 && !controller.boss3Block)
            {
                controller.UnblockBoss3();
            }
            controller.bossTime = false;
            if (!controller.versusMode)
            {
                controller.ending = true;
                Invoke("ending", 2f);
            }
        }
        if (!controller.ending)
        {
            Invoke("gameOver", 2f);
        }
    }
    public void gameOver()
    {
        controller.score =controller.score + (int)(GameObject.Find("HealthBar").GetComponent<Transform>().localScale.x * 100000);
        if (controller.versusMode)
        {
            Instantiate(controller.GameOverPlayer, new Vector3(0, 12f, -2.28f), Quaternion.identity);
        }
        else {
            Instantiate(controller.GameOver, new Vector3(0, 0, -5.8f), Quaternion.identity);
        }
    }
    public bool checkEnemys()
    {
        for(int i = 0; i < controller.wizardEnemy.Length; i++)
        {
            if (controller.wizardEnemy[i] != null)
            {
                return true;
            }
        }
        return false;
    }
    public void blockAttack()
    {
        controller.noDamage = false;
    }
    public void reactive(Notification notificatio)
    {
        for(int i=0; i<arr.Length; i++)
        {
            arr[i].gameObject.SetActive(true);
        }
    }
    public void ending()
    {
        GetComponent<Animator>().SetBool("Ending",true);
        Invoke("endingdisable",4f);
    }
    public void endingdisable()
    {
        GetComponent<Animator>().SetBool("Ending",false);
        gameOver();
    }
}
