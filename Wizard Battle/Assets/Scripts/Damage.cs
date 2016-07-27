using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
    public GameObject wizard;
    public Controller controller;
    public bool po = true;
	// Use this for initialization
	void Start () {
        po = true;
        controller = GameObject.FindObjectOfType<Controller>();

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
                Destroy(collider.gameObject);
            if (wizard.name == gameObject.name)
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "attackPlayer");
            }
            else
            {
                NotificationCenter.DefaultCenter().PostNotification(this,"punchEnemy");
                NotificationCenter.DefaultCenter().PostNotification(this, "attack");
                NotificationCenter.DefaultCenter().PostNotification(this, "changeColorEnemy");
            }
            
        }
        if (collider.gameObject.tag == "Power" && po)
        {
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
