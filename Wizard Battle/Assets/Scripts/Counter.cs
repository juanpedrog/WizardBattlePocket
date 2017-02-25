using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {
    private Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        controller.isAlive = true;
        controller.power = false;
        Invoke("destroy", 3.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void destroy()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "temporizer");
        NotificationCenter.DefaultCenter().PostNotification(this,"activateButtons");
        NotificationCenter.DefaultCenter().PostNotification(this, "beginAttack");
        controller.power = true;
        Destroy(this.gameObject);
    }
}
