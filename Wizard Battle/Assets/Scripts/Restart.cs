using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
    public GameObject healthBar,healthbarenemy,counter;
    Controller controller;
	// Use this for initialization
	void Start () {
        healthBar = GameObject.Find("HealthBar");
        healthbarenemy = GameObject.Find("HealthBarInverse");
        controller = GameObject.FindObjectOfType<Controller>();
        controller.player = GameObject.Find(controller.playerName+"(Clone)");
        controller.numHits = 0;
        if (controller.survivalMode)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<TextMesh>().color = Color.gray;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        AdManager.Instance.exitBanner();
        controller.powerDamage = 0;
        GetComponent<AudioSource>().Play();
        controller.unblockAttack();
        NotificationCenter.DefaultCenter().PostNotification(this,"reset");
        NotificationCenter.DefaultCenter().PostNotification(this,"reactive");
        Instantiate(counter,new Vector3(-1.987074f, 0.622557f, -4.9f),Quaternion.identity);
        healthBar.GetComponent<Transform>().localScale = new Vector3(1,1,1) ;
        healthbarenemy.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        controller.player.GetComponent<Animator>().SetBool("Die",false);
        GameObject.FindObjectOfType<Damage>().GetComponent<Animator>().SetBool("Die",false);
        controller.isAliveAgain = true;
        controller.power = true;
        controller.just1player = true;
        controller.noDamage = true;
        controller.just1 = true;
        Destroy(GameObject.Find("DuelFinishPlayer(Clone)"));
    }
}
