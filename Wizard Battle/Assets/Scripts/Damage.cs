using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
    public GameObject wizard;
    public Controller controller;
    public bool po = true;
    public GameObject damageParticle,powerParticle;
    AudioSource attack;
    public string nameSoundDamage;
	// Use this for initialization
	void Start () {
        po = true;
        controller = GameObject.FindObjectOfType<Controller>();
        attack = GameObject.Find(nameSoundDamage).GetComponent<AudioSource>();
        if (wizard == null)
        {
            Invoke("findWizard", 0.3f);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Attack")
        {
            Instantiate(damageParticle,
                    new Vector3(collider.GetComponent<Transform>().position.x, collider.GetComponent<Transform>().position.y, -1f), collider.GetComponent<Transform>().rotation);
            Destroy(collider.gameObject);
            attack.Play();
            if (wizard.name == gameObject.name)
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "attackPlayer");
            }
            else
            {
                NotificationCenter.DefaultCenter().PostNotification(this,"punchEnemy");
                NotificationCenter.DefaultCenter().PostNotification(this, "attack");
                NotificationCenter.DefaultCenter().PostNotification(this, "changeColorEnemy");
                controller.powerDamage+=1;
                if (controller.powerDamage == 3)
                {
                    NotificationCenter.DefaultCenter().PostNotification(this, "activate");
                    controller.isPower = true;
                    controller.powerStill = true;
                }
            }
            
        }
        if (collider.gameObject.tag == "Power" && po)
        {
            Instantiate(powerParticle, new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, -1f), GetComponent<Transform>().rotation);
            NotificationCenter.DefaultCenter().PostNotification(this, "punchEnemy");
            NotificationCenter.DefaultCenter().PostNotification(this, "attack");
            NotificationCenter.DefaultCenter().PostNotification(this, "attack");
            NotificationCenter.DefaultCenter().PostNotification(this, "changeColorEnemy");
            po = false;
            Invoke("poT", 1f);
        }
    }
    public void findWizard()
    {
        wizard = GameObject.Find(controller.playerName + "(Clone)");
    }
    public void poT()
    {
        po = true;
    }
}
