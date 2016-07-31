using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour {
    private Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        controller.isAlive = true;
        Invoke("destroy", 3.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void destroy()
    {
        NotificationCenter.DefaultCenter().PostNotification(this, "temporizer");
        Destroy(this.gameObject);
    }
}
