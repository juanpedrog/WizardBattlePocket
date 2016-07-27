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
        anim = GetComponent<Animator>();
        Invoke("findWizard", 0.2f);
    }
    public void findWizard()
    {
        wizard = GameObject.Find(controller.playerName + "(Clone)");
        animWizard = wizard.GetComponent<Animator>();
        anim.SetBool("Power", true);
    }
    // Update is called once per frame
    void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this, "activate");
	}
    void OnMouseDown()
    {
        if (isPressed)
        {
            anim.SetBool("Power", true);
            animWizard.SetBool("Attack", true);
            Invoke("standWizard", 1f);
            NotificationCenter.DefaultCenter().PostNotification(this, "powern");
            NotificationCenter.DefaultCenter().PostNotification(this, "resetPower");
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
