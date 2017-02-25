using UnityEngine;
using System.Collections;

public class Destructer : MonoBehaviour {
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
        if (collider.tag.Equals("Attack"))
        {
            controller.powerDamage = 0;
            controller.numHits = 0;
        }
    }
}
