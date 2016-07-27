using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {
    int time;
    public GameObject h1, h2;
    float scale1, scale2;
    bool still;
	// Use this for initialization
	void Start () {
        time = int.Parse(GetComponent<TextMesh>().text);
        still = true;
	}
	
	// Update is called once per frame
	void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this,"temporizer");
        NotificationCenter.DefaultCenter().AddObserver(this,"stop");
        NotificationCenter.DefaultCenter().AddObserver(this,"reset");
	}
    void temporizer(Notification notification)
    {
        started();
    }
    void started()
    {
        if (still)
        {
            time--;
        }
        GetComponent<TextMesh>().text = time + "";
        if (time != 0)
        {
            if (still)
            {
                Invoke("started", 2f);
            }
        }
        else
        {
            scale1 = h1.GetComponent<Transform>().localScale.x;
            scale2 = h2.GetComponent<Transform>().localScale.x*(-1);
            if (scale1 > scale2)
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "DieEnemyNotification");
            }
            else
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "DieNotification");
            }
        }
    }
    void stop(Notification notification)
    {
        still = false;
    }
    void reset(Notification notificatio)
    {
        GetComponent<TextMesh>().text = "60";
        time = int.Parse(GetComponent<TextMesh>().text);
        still = true;
    }
}
