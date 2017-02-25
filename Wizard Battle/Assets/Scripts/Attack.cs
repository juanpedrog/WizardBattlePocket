using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    public Animator anim,animWizard;
    public float time;
    public GameObject wizard;
    private bool isPressed;
    Controller controller;
	// Use this for initialization
	void Start () {
        //anim = GetComponent<Animator>();
        isPressed = true;
        controller = (Controller)GameObject.FindObjectOfType<Controller>();
        Invoke("findWizard", 0.2f);
    }
    public void findWizard()
    {
        wizard = GameObject.Find(controller.playerName + "(Clone)");
        animWizard = wizard.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("m"))
        {
            onMouseDown();
        }
	}
    void Enabled()
    {
        anim.SetBool("Attack",false);
        isPressed = true;
    }
    void standWizard()
    {
        animWizard.SetBool("Attack",false);
    }
    public void onMouseDown()
    {
        if (isPressed)
        {
            anim.SetBool("Attack", true);
            animWizard.SetBool("Attack", true);
            Invoke("Enabled", time);
            Invoke("standWizard", 1f);
            isPressed = false;
            NotificationCenter.DefaultCenter().PostNotification(this, "makeAttack");
        }
    }
    
}
