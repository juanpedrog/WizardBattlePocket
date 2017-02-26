using UnityEngine;
using System.Collections;

public class LogroMensaje : MonoBehaviour {
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        GetComponent<TextMesh>().text=controller.logroMensaje;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        Destroy(this.GetComponent<Transform>().parent.gameObject,0.5f);
        Time.timeScale = 1;
    }
}
