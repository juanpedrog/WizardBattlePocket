using UnityEngine;
using System.Collections;

public class FloorEnemy : MonoBehaviour {
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
        if (collider.gameObject.tag.Equals("Floor"))
        {
            controller.jumpenemy = true;
            if (GetComponent<Transform>().name.Equals("FloorMonster"))
            {
                GameObject foot = GameObject.Find("FootMonster");
            }
        }
    }
}
