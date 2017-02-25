using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {
    public bool po = true;
    public GameObject damageParticle;
    public GameObject powerParticle;
    AudioSource damageSound;
    public string nameSoundDamage;
    // Use this for initialization
    void Start () {
        po = true;
        damageSound = GameObject.Find(nameSoundDamage).GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Instantiate(damageParticle,
                    new Vector3(collider.GetComponent<Transform>().position.x, collider.GetComponent<Transform>().position.y, -1f),collider.GetComponent<Transform>().rotation);
            Destroy(collider.gameObject);
            damageSound.Play();
            NotificationCenter.DefaultCenter().PostNotification(this, "punch");
            NotificationCenter.DefaultCenter().PostNotification(this, "attackPlayer");
            NotificationCenter.DefaultCenter().PostNotification(this,"changeColor");
        }
        if (collider.gameObject.tag == "PowerPlayer"&& po)
        {
            Instantiate(powerParticle, new Vector3(GetComponent<Transform>().position.x,GetComponent<Transform>().position.y, -1f), GetComponent<Transform>().rotation);
            damageSound.Play();
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
