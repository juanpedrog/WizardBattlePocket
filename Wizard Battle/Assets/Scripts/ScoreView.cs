using UnityEngine;
using System.Collections;

public class ScoreView : MonoBehaviour {
    Controller controller;
    public bool already;
	// Use this for initialization
	void Start () {
        already = true;
        controller = GameObject.FindObjectOfType<Controller>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.score < controller.score0)
        {
            controller.score0+=100;
        }
        else
        {
            GetComponent<TextMesh>().text = controller.score + "";
            already = false;
        }
        if (already)
        {
            GetComponent<TextMesh>().text = controller.score0 + "";
        }
    }
}
