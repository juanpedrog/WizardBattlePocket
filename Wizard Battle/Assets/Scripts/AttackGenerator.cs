using UnityEngine;
using System.Collections;

public class AttackGenerator : MonoBehaviour {
    public GameObject AttackObject;
    Controller controller;
    public int power;
	// Use this for initialization
	void Start () {
        power = 0;
        controller = GameObject.FindObjectOfType<Controller>();
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
        NotificationCenter.DefaultCenter().PostNotification(this,"attackSound");
        power++;
        if (power == 20)
        {
            NotificationCenter.DefaultCenter().PostNotification(this,"activate");
        }
        Instantiate(AttackObject,GetComponent<Transform>().position, Quaternion.identity);
        NotificationCenter.DefaultCenter().PostNotification(this,"score10");
    }
    void resetPower(Notification notification)
    {
        power = 0;
    }
	// Update is called once per frame
	void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this, "makeAttack");
        NotificationCenter.DefaultCenter().AddObserver(this, "resetPower");
    }
}
