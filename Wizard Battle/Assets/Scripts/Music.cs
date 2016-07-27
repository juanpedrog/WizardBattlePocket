using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

    Controller controller;
    // Use this for initialization
    void Start()
    {
        controller = GameObject.FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.music)
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
        controller.music = !controller.music;
    }
    public void soundMenu()
    {
        OnMouseDown();
    }
}
