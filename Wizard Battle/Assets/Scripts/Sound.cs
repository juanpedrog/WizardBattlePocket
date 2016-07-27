using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
    Controller controller;
    // Use this for initialization
    void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.sound)
        {
            GetComponent<TextMesh>().color = Color.red;
        }
        else
        {
            GetComponent<TextMesh>().color = Color.white;
        }
	}
    void OnMouseDown()
    {
        controller.sound = !controller.sound;
    }
    public void soundMenu()
    {
        OnMouseDown();
    }
}
