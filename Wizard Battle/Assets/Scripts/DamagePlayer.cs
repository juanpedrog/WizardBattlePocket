using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {
    public bool po = true;
	// Use this for initialization
	void Start () {
        po = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
            NotificationCenter.DefaultCenter().PostNotification(this, "punch");
            NotificationCenter.DefaultCenter().PostNotification(this, "attackPlayer");
            NotificationCenter.DefaultCenter().PostNotification(this,"changeColor");
        }
        if (collider.gameObject.tag == "PowerPlayer"&& po)
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "punch");
            NotificationCenter.DefaultCenter().PostNotification(this, "attackPlayer");
            NotificationCenter.DefaultCenter().PostNotification(this, "attackPlayer");
            NotificationCenter.DefaultCenter().PostNotification(this,"changeColor");
            po = false;
            Invoke("poT",1f);
        }
    }
    public void poT()
    {
        po = true;
    }
}
