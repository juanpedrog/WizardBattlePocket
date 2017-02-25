using UnityEngine;
using System.Collections;

public class ActivateButtons : MonoBehaviour {
    public GameObject jump,attack,power;
    bool allow;
	// Use this for initialization
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "activateButtons");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void activateButtons(Notification notification)
    {
        allow = !allow;
        jump.SetActive(allow);
        attack.SetActive(allow);
        power.SetActive(allow);
    }
}
