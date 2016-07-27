using UnityEngine;
using System.Collections;

public class Inteligencia : MonoBehaviour {
    public float vel, vela;
    public GameObject wizard;
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        controller.floor = true;
        vela=vel;
        Invoke("findWizard",0.3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Attack")
        {
            wizard.GetComponent<Rigidbody2D>().velocity = new Vector2(wizard.GetComponent<Rigidbody2D>().velocity.x,vel);
            if (controller.floor)
            {
                controller.floor = false;
                vel = 0;
                Invoke("inFloor",0.5f);
            }
        }
    }
    void inFloor()
    {
        controller.floor = true;
        vel = vela;
    }
    public void findWizard()
    {
        wizard = GameObject.Find(GetComponent<Transform>().parent.gameObject.GetComponent<Transform>().parent.name);
    }
}
