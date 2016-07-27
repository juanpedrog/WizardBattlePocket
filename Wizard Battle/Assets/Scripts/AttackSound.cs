using UnityEngine;
using System.Collections;

public class AttackSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name.Equals("AttackSound"))
        {
            NotificationCenter.DefaultCenter().AddObserver(this, "attackSound");
        }
        else
        {
            NotificationCenter.DefaultCenter().AddObserver(this, "attackSoundEnemy");
        }
    }
    void attackSound(Notification notification)
    {
        GetComponent<AudioSource>().Play();
    }
    void attackSoundEnemy(Notification notification)
    {
        GetComponent<AudioSource>().Play();
    }
}
