using UnityEngine;
using System.Collections;

public class SmartAttack : MonoBehaviour {
    public float timeIn, timeFin;
    public GameObject item;
    private Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        if (GetComponent<Transform>().parent.GetComponent<Transform>().parent.GetComponent<Transform>().name.Equals("Boss1Enemy(Clone)"))
        {
            timeIn = controller.minBoss();
            timeFin = controller.maxBoss();
        }
        else
        {
            timeIn = controller.min();
            timeFin = controller.max();
        }
        Invoke("attack", Random.Range((timeIn + 4), timeFin));
    }
	
	// Update is called once per frame
	void Update () {
        if (controller.isAliveAgain)
        {
            Invoke("attack", Random.Range((timeIn + 4), timeFin));
            controller.isAliveAgain = false;
        }
	}
    public void attack()
    {
        if (controller.isAlive)
        {
            NotificationCenter.DefaultCenter().PostNotification(this,"attackSoundEnemy");
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
    public void arrive()
    {
        Instantiate(item, GetComponent<Transform>().position, Quaternion.identity);
    }
    public void animDisable()
    {
        GetComponentInParent<Animator>().SetBool("Attack", false);
    }
}
