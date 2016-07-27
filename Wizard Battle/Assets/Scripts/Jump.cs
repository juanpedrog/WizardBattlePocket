using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
    private bool isJump;
    public GameObject wizard;
    public int force;
    Controller controller;
	// Use this for initialization
	void Start () {
        isJump = true;
        controller = (Controller)GameObject.FindObjectOfType<Controller>();
        Invoke("findWizard",0.2f);
    }
	public void findWizard()
    {
        wizard = GameObject.Find(controller.playerName + "(Clone)");
    }
    // Update is called once per frame
    void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this, "isFloor");
	}
    public void Disable()
    {
        isJump = true;
        GetComponent<Animator>().SetBool("Jump", false);
    }
    void OnMouseDown()
    {
        if (isJump)
        {
            wizard.GetComponent<Rigidbody2D>().velocity=new Vector2(wizard.GetComponent<Rigidbody2D>().velocity.x, force);
            GetComponent<Animator>().SetBool("Jump",true);
            isJump = false;
        }
    }
    void isFloor(Notification notification)
    {
        Disable();
    }
}
