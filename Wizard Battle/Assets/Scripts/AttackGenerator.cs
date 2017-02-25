using UnityEngine;
using System.Collections;

public class AttackGenerator : MonoBehaviour {
    public GameObject AttackObject,superPowerParticle;
    AudioSource attack;
    public string nameSoundAttack;
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        attack = GameObject.Find(nameSoundAttack).GetComponent<AudioSource>();
        controller.powerUp = 0;
	}
    public void makeAttack(Notification notification)
    {
        if (GetComponent<Transform>().position.x < 0)
        {
            Invoke("generator",0.5f);
        }
    }
    public void generator()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "attackSound");
        Instantiate(AttackObject,GetComponent<Transform>().position, Quaternion.identity);
        attack.Play();
        controller.powerUp += 1;
        if (controller.powerUp == 20)
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "activate");
            controller.isPower = true;
            controller.powerUp = 0;
        }
        NotificationCenter.DefaultCenter().PostNotification(this,"score10");
    }
    void resetPower(Notification notification)
    {

    }
	// Update is called once per frame
	void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this, "makeAttack");
        NotificationCenter.DefaultCenter().AddObserver(this, "resetPower");
        NotificationCenter.DefaultCenter().AddObserver(this, "superAttack");
    }
    void superAttack(Notification notification)
    {
        Invoke("superAttackPart", 0.5f);
    }
    void superAttackPart()
    {
        Instantiate(superPowerParticle, GetComponent<Transform>().position, Quaternion.identity);
    }
}
