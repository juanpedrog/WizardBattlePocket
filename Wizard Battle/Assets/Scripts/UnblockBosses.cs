using UnityEngine;
using System.Collections;

public class UnblockBosses : MonoBehaviour {
    Controller controller;
    public GameObject boss1,boss2,boss3;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        Invoke("unblockboss1",0.5f);
	}
	public void unblockboss1()
    {
        if (controller.boss1Block)
        {
            boss1.SetActive(true);
        }
        if (controller.boss2Block)
        {
            boss2.SetActive(true);
        }
        if (controller.boss3Block)
        {
            boss3.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
