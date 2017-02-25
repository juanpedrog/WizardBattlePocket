using UnityEngine;
using System.Collections;

public class HeadSelection : MonoBehaviour {
    Controller controller;
    public GameObject[] heads;
    public bool player;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();

	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            NotificationCenter.DefaultCenter().AddObserver(this,"invokerPlayer");
        }
        else
        {
            NotificationCenter.DefaultCenter().AddObserver(this,"invokerEnemy");
        }
	}
    void invokerPlayer(Notification notification)
    {
        Instantiate(heads[controller.posPlayer], GetComponent<Transform>().position, Quaternion.identity);
    }
    void invokerEnemy(Notification notification)
    {
        Instantiate(heads[controller.posEnemy], GetComponent<Transform>().position, Quaternion.identity);
    }
}
