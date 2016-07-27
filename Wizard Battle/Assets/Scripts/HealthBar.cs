using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    public GameObject wizard;
    public float damage;
    public bool player;
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        controller.just1 = true;
        if (controller.survivalMode && GetComponent<Transform>().position.x<0)
        {
            GetComponent<Transform>().localScale =new Vector3(controller.healthBar,1f,1f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            if (GetComponent<Transform>().localScale.x <= 0)
            {
                if (controller.just1player)
                {
                    NotificationCenter.DefaultCenter().PostNotification(this, "DieNotification");
                    controller.just1player = false;
                }
            }
            else {
                NotificationCenter.DefaultCenter().AddObserver(this, "attackPlayer");
            }
        }
        else
        {
            if (GetComponent<Transform>().localScale.x >= 0)
            {
                if (controller.just1)
                {
                    NotificationCenter.DefaultCenter().PostNotification(this, "DieEnemyNotification");
                    controller.just1 = false;
                }
            }
            else {
                NotificationCenter.DefaultCenter().AddObserver(this, "attack");
            }
        }
    }
    public void damageApply()
    {
        if (controller.noDamage)
        {
            if (GetComponent<Transform>().localScale.x < 0)
            {
                GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x + damage, 1, 1);
                NotificationCenter.DefaultCenter().PostNotification(this, "score100");
            }
        }
    }
    public void damageApplyPlayer()
    {
        if (controller.noDamage)
        {
            if (GetComponent<Transform>().localScale.x > 0)
            {
                GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x - damage, 1, 1);
                if (controller.survivalMode)
                {
                    controller.healthBar = GetComponent<Transform>().localScale.x;
                }
            }
        }
    }
    public void attack(Notification notification)
    {
        damageApply();
    }
    public void attackPlayer(Notification notificacion)
    {
        damageApplyPlayer();
    }
}
