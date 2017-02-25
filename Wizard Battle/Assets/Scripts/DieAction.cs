using UnityEngine;
using System.Collections;

public class DieAction : MonoBehaviour {
    public bool isPlayer;
    public GameObject player, enemy;
    private Controller controller;
    public GameObject canvas,DeadParticles;
    public Color dead;
    Inteligencia[] arr;
    AudioSource death;
    public string nameSoundKill;
    private GameObject touchControls;
    GameObject eff;
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
        death = GameObject.Find(nameSoundKill).GetComponent<AudioSource>();
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
        NotificationCenter.DefaultCenter().PostNotification(this, "perfect");//HealthBar
        Instantiate(DeadParticles, new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, -1), GetComponent<Transform>().rotation);
        blockAttack();
        death.Play();
        die();
    }
    public void die()
    {
        Invoke("instersticial",2.5f);
        NotificationCenter.DefaultCenter().PostNotification(this, "stop");
        player.GetComponent<Animator>().SetBool("Die",true);
        if (controller.survivalMode)
        {
            controller.healthBar = 1;
        }
        Invoke("showDuelOverScreen",2.5f);
        NotificationCenter.DefaultCenter().PostNotification(this, "saveScore");
        controller.isAlive = false;
        controller.power = false;
    }
    void showDuelOverScreen()
    {
        Instantiate(controller.GameOverPlayer, new Vector3(0, 0, -5.8f), Quaternion.identity);
        NotificationCenter.DefaultCenter().PostNotification(this, "activateButtons");
    }
    private void DieEnemyNotification(Notification notification)
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "perfect");//HealthBar
        Instantiate(DeadParticles, new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, -1), GetComponent<Transform>().rotation);
        blockAttack();
        death.Play();
        dieEnemy();
    }
    void pasarLogros(int[] h,int[] logros)
    {
        for(int i = 0; i < logros.Length; i++)
        {
            h[i] = logros[i];
        }
    }
    public void dieEnemy()
    {
        if (GetComponent<Transform>().name.Equals("BodyMonster"))
        {
            GameObject foot = GameObject.Find("FootMonster");
            foot.SetActive(false);
        }
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
        if (GetComponent<Transform>().parent.name.Equals("Monster(Clone)"))
        {
            if (!controller.versusMode)
            {
                controller.ending = true;
                Invoke("gameOver",6f);

            }

            if (controller.dataObject.difficulty == 3 && GameObject.Find("Wizard1(Clone)") != null && !controller.checkLogro(1))
            {
                int[] h = new int[controller.logros.Length + 1];
                pasarLogros(h,controller.logros);
                h[h.Length - 1] = 1;
                controller.logros = h;
                controller.guardarLogros();
            }
            if (controller.dataObject.difficulty == 3 && GameObject.Find("Wizard2(Clone)") != null && !controller.checkLogro(2))
            {
                int[] h = new int[controller.logros.Length + 1];
                pasarLogros(h, controller.logros);
                h[h.Length - 1] = 2;
                controller.logros = h;
                controller.guardarLogros();
            }
            if (controller.dataObject.difficulty == 3 && GameObject.Find("Wizard3(Clone)") != null && !controller.checkLogro(3))
            {
                int[] h = new int[controller.logros.Length + 1];
                pasarLogros(h, controller.logros);
                h[h.Length - 1] = 3;
                controller.logros = h;
                controller.guardarLogros();
            }
            if (controller.dataObject.difficulty == 3 && GameObject.Find("Wizard4(Clone)") != null && !controller.checkLogro(4))
            {
                int[] h = new int[controller.logros.Length + 1];
                pasarLogros(h, controller.logros);
                h[h.Length - 1] = 4;
                controller.logros = h;
                controller.guardarLogros();
            }
            if (controller.dataObject.difficulty == 3 && GameObject.Find("Wizard5(Clone)") != null && !controller.checkLogro(5))
            {
                int[] h = new int[controller.logros.Length + 1];
                pasarLogros(h, controller.logros);
                h[h.Length - 1] = 5;
                controller.logros = h;
                controller.guardarLogros();
            }
            if (controller.dataObject.difficulty == 3 && GameObject.Find("Wizard6(Clone)") != null && !controller.checkLogro(6))
            {
                int[] h = new int[controller.logros.Length + 1];
                pasarLogros(h, controller.logros);
                h[h.Length - 1] = 6;
                controller.logros = h;
                controller.guardarLogros();
            }
            if (controller.dataObject.difficulty == 3 && GameObject.Find("Wizard7(Clone)") != null && !controller.checkLogro(7))
            {
                int[] h = new int[controller.logros.Length + 1];
                pasarLogros(h, controller.logros);
                h[h.Length - 1] = 7;
                controller.logros = h;
                controller.guardarLogros();
            }

        }
        if (GetComponent<Transform>().parent.name.Equals("Boss1Enemy(Clone)"))
        {
            if (controller.dataObject.difficulty == 3 && !controller.boss1Block)
            {
                controller.UnblockBoss1();
            }
            eff=GameObject.Find("FireParticleSystem");
            eff.SetActive(false);
            GameObject[] part = GameObject.FindGameObjectsWithTag("Particle");
            for (int i = 0; i < part.Length; i++)
            {
                Destroy(part[i]);
            }
            controller.bossTime = false;
            controller.monsterTime = true;
        }
        if (GetComponent<Transform>().parent.name.Equals("Boss2Enemy(Clone)"))
        {
            if (controller.dataObject.difficulty == 3 && controller.survivalMode && !controller.boss2Block)
            {
                controller.UnblockBoss2();
            }
            eff=GameObject.Find("FireParticleSystem");
            eff.SetActive(false);
            GameObject[] part = GameObject.FindGameObjectsWithTag("Particle");
            for (int i = 0; i < part.Length; i++)
            {
                Destroy(part[i]);
            }
            controller.bossTime = false;
            controller.monsterTime = true;
        }
        if (GetComponent<Transform>().parent.name.Equals("Boss3Enemy(Clone)"))
        {
            if (controller.dataObject.difficulty == 3 && controller.survivalMode && controller.posPlayer < 7 && !controller.boss3Block)
            {
                controller.UnblockBoss3();
            }
            eff=GameObject.Find("FireParticleSystem");
            eff.SetActive(false);
            GameObject[] part=GameObject.FindGameObjectsWithTag("Particle");
            for(int i = 0; i < part.Length; i++)
            {
                Destroy(part[i]);
            }
            controller.bossTime = false;
            controller.monsterTime = true;
        }
        if (!controller.ending)
        {
            Invoke("gameOver", 2f);
        }
    }
    public void gameOver()
    {
        AdManager.Instance.showBanner();
        NotificationCenter.DefaultCenter().PostNotification(this, "activateButtons");
        controller.score =controller.score + (int)(GameObject.Find("HealthBar").GetComponent<Transform>().localScale.x * 100000);
        if (controller.versusMode)
        {
            Instantiate(controller.GameOverPlayer, new Vector3(0, 12f, -7.3f), Quaternion.identity);
        }
        else {
            Instantiate(controller.GameOver, new Vector3(0, 0, -6.4f), Quaternion.identity);
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
        if (!isPlayer)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].gameObject.SetActive(true);
            }
            if (GetComponent<Transform>().parent.name.Equals("Boss3Enemy(Clone)"))
            {
                eff.SetActive(true);
            }
            if (GetComponent<Transform>().parent.name.Equals("Boss2Enemy(Clone)"))
            {
                eff.SetActive(true);
            }
            if (GetComponent<Transform>().parent.name.Equals("Boss1Enemy(Clone)"))
            {
                eff.SetActive(true);
            }
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
    public void instersticial()
    {
        if (!controller.versusMode)
        {
            AdManager.Instance.showIntersticial();
        }
    }
}
