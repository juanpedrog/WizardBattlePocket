using UnityEngine;
using System.Collections;

public class DamageColor : MonoBehaviour {
    Color color;
    bool player;

	// Use this for initialization
	void Start () {
        color = GetComponent<SpriteRenderer>().color;
        if (GetComponent<Transform>().position.x < 0)
        {
            player = true;
        }
        else
        {
            player = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            NotificationCenter.DefaultCenter().AddObserver(this, "changeColor");
        }
        else
        {
            NotificationCenter.DefaultCenter().AddObserver(this, "changeColorEnemy");
        }
	}
    void changeColor(Notification notification)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("beforeColor", 0.2f);
    }
    void changeColorEnemy(Notification notification)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("beforeColor", 0.2f);
    }
    void beforeColor()
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
