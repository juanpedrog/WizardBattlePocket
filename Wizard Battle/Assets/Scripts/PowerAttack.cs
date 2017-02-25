using UnityEngine;
using System.Collections;

public class PowerAttack : MonoBehaviour {
    public Animator anim,animWizard;
    public GameObject wizard;
    Controller controller;
    public bool isPressed=false;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        //anim = GetComponent<Animator>();
        controller.powerStill=true;
        Invoke("findWizard", 0.2f);
    }
    public void findWizard()
    {
        wizard = GameObject.Find(controller.playerName + "(Clone)");
        animWizard = wizard.GetComponent<Animator>();
        anim.SetBool("Power", true);
    }
    // Update is called once per frame
    void FixedUpdate () {
        if(isPressed && controller.powerStill)
        {
            anim.SetBool("Power", false);
        }
        else
        {
            anim.SetBool("Power", true);
        }
	}
    void Update()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "activate");
        if (Input.GetKeyUp("b"))
        {
            onMouseDown();
        }
    }
    public void onMouseDown()
    {
        if (isPressed)
        {
            anim.SetBool("Power", true);
            animWizard.SetBool("Attack", true);
            Invoke("standWizard", 1f);
            //NotificationCenter.DefaultCenter().PostNotification(this, "powern");
            NotificationCenter.DefaultCenter().PostNotification(this, "powerUp");
            NotificationCenter.DefaultCenter().PostNotification(this, "superAttack");
            if (!controller.isPower)
            {
                NotificationCenter.DefaultCenter().PostNotification(this, "resetPower");
            }
            else
            {
                controller.isPower = false;
            }

            isPressed = false;
        }
    }
    public void disable()
    {
        anim.SetBool("Power", false);
    }
    void standWizard()
    {
        animWizard.SetBool("Attack", false);
    }
    void activate(Notification notifation)
    {
        activarAnim();
    }
    public void activarAnim()
    {
        anim.SetBool("Power", false);
        isPressed = true;
    }
}
