using UnityEngine;
using System.Collections;

public class PunchSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name.Equals("PunchSound"))
        {
            NotificationCenter.DefaultCenter().AddObserver(this,"punch");
        }
        else
        {
            NotificationCenter.DefaultCenter().AddObserver(this,"punchEnemy");
        }
	}
    void punch(Notification notification)
    {
        GetComponent<AudioSource>().Play();
    }
    void punchEnemy(Notification notification)
    {
        GetComponent<AudioSource>().Play();
    }
}
