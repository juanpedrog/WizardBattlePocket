using UnityEngine;
using System.Collections;

public class PowerInvoker : MonoBehaviour {
    public GameObject power;
	// Use this for initialization
	void Awake () {
        Instantiate(power,new Vector3(0,0,0),Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
