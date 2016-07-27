using UnityEngine;
using System.Collections;

public class AttackAction : MonoBehaviour {
    public int vel;
    public GameObject wizard;
	// Use this for initialization
	void Start () {
        if (GetComponent<Transform>().position.x<0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(vel, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-vel, GetComponent<Rigidbody2D>().velocity.y);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
