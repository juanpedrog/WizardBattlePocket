using UnityEngine;
using System.Collections;

public class SmartAttack : MonoBehaviour {
    public float timeIn, timeFin;
    public GameObject item;
    private Controller controller;
    public GameObject superPowerParticle;
    AudioSource attackSound;
    public string nameSoundAttack;
    // Use this for initialization
    void Start() {
        controller = GameObject.FindObjectOfType<Controller>();
        attackSound = GameObject.Find(nameSoundAttack).GetComponent<AudioSource>();
        if (GetComponent<Transform>().parent.GetComponent<Transform>().parent.GetComponent<Transform>().name.Equals("Boss1Enemy(Clone)")
         || GetComponent<Transform>().parent.GetComponent<Transform>().parent.GetComponent<Transform>().name.Equals("Boss2Enemy(Clone)")
         || GetComponent<Transform>().parent.GetComponent<Transform>().parent.GetComponent<Transform>().name.Equals("Boss3Enemy(Clone)")
         || GetComponent<Transform>().parent.GetComponent<Transform>().parent.GetComponent<Transform>().name.Equals("Monster(Clone)"))
        {
            timeIn = controller.minBoss();
            timeFin = controller.maxBoss();
        }
        else
        {
            timeIn = controller.min();
            timeFin = controller.max();
        }
        //Invoke("attack", Random.Range((timeIn + 5f), timeFin));
    }

    // Update is called once per frame
    void Update() {
        if (controller.isAliveAgain)
        {
            //Invoke("attack", Random.Range((timeIn + 4), timeFin));
            controller.isAliveAgain = false;
        }
        NotificationCenter.DefaultCenter().AddObserver(this,"beginAttack");
    }
    public void attack()
    {
        if (controller.isAlive)
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "attackSoundEnemy");
            GetComponentInParent<Animator>().SetBool("Attack", true);
            Invoke("arrive", 0.5f);
            Invoke("animDisable", 1f);
            Invoke("attack", Random.Range(timeIn, timeFin));
        }
        else
        {
            return;
        }
    }
    void beginAttack(Notification notification)
    {
        Invoke("attack", Random.Range(timeIn, timeFin));
    }
    void superAttackEnemy(Notification notification)
    {
        Invoke("superAttackPart", 0.5f);
    }
    void superAttackPart()
    {
        Instantiate(superPowerParticle, GetComponent<Transform>().position, Quaternion.identity);
        attackSound.Play();
    }
    public void arrive()
    {
        Instantiate(item, GetComponent<Transform>().position, Quaternion.identity);
        attackSound.Play();
    }
    public void animDisable()
    {
        GetComponentInParent<Animator>().SetBool("Attack", false);
    }
}
