using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    public GameObject wizard;
    public float damage;
    public bool player;
    public Color green;
    Controller controller;
    public GameObject perfectMessage;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        controller.just1 = true;
        if (controller.survivalMode && GetComponent<Transform>().position.x<0)
        {
            GetComponent<Transform>().localScale =new Vector3(controller.healthBar,1f,1f);
        }
        controller.powerDamage = 0;
        controller.numHits = 0;
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
            if (GetComponent<Transform>().localScale.x > 0.6f)
            {
                GetComponent<SpriteRenderer>().color = green;
            }
            else
            {
                if (GetComponent<Transform>().localScale.x <= 0.6f && GetComponent<Transform>().localScale.x > 0.3f)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {
                    if (GetComponent<Transform>().localScale.x <= 0.3f)
                    {
                        GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
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
            if (GetComponent<Transform>().localScale.x*-1 > 0.6f)
            {
                GetComponent<SpriteRenderer>().color = green;
            }
            else
            {
                if (GetComponent<Transform>().localScale.x*-1 <= 0.6f && GetComponent<Transform>().localScale.x*-1 > 0.3f)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else
                {
                    if (GetComponent<Transform>().localScale.x*-1 <= 0.3f)
                    {
                        GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }

        }
        NotificationCenter.DefaultCenter().AddObserver(this, "perfect");
    }
    void perfect(Notification notifcation)
    {
        Debug.Log(GetComponent<Transform>().localScale.x+"");
        if (GetComponent<Transform>().localScale.x == 1 || GetComponent<Transform>().localScale.x == -1)
        {
            Instantiate(perfectMessage,new Vector3(0,0,-4.5f),Quaternion.identity);
            GameObject n = GameObject.Find("Perfect(Clone)");
            Destroy(n,3f);
        }
    }
    public void damageApply()
    {
        if (controller.noDamage)
        {
            if (GetComponent<Transform>().localScale.x < 0)
            {
                GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x + damage, 1, 1);
                NotificationCenter.DefaultCenter().PostNotification(this,"change");
                NotificationCenter.DefaultCenter().PostNotification(this,"showHits");
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
