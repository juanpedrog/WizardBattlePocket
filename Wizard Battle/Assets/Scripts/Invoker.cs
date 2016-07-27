using UnityEngine;
using System.Collections;

public class Invoker : MonoBehaviour {
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = (Controller)GameObject.FindObjectOfType<Controller>();
        controller.charge();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
