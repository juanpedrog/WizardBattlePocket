using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossLocked : MonoBehaviour {
    Controller controller;
    public int boss;
    public Image im;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        switch (boss)
        {
            case 1:
                if (controller.boss1Block)
                {
                    im.enabled = false;
                }
                break;
            case 2:
                if (controller.boss2Block)
                {
                    im.enabled = false;
                }
                break;
            case 3:
                if (controller.boss3Block)
                {
                    im.enabled = false;
                }
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
