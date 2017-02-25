using UnityEngine;
using System.Collections;

public class Parent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Transform>().parent = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
