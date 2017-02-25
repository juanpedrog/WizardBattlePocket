using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    public GameObject pause;
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if (controller.pause)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
            controller.pause = false;
        }
        else
        {
            pause.SetActive(false);
            Time.timeScale = 1;
            controller.pause = true;
        }
        if (this.GetComponent<Transform>().tag.Equals("MainMenu"))
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
