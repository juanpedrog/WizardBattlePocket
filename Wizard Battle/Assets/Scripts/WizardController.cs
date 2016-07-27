using UnityEngine;
using System.Collections;

public class WizardController : MonoBehaviour {
    public int force;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,force);
    }
}
