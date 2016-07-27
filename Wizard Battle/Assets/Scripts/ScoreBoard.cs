using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        switch (GetComponent<Transform>().parent.name)
        {
            case "Arcade": GetComponent<TextMesh>().text = controller.dataObject.scoreMax+""; break;
            case "Survival": GetComponent<TextMesh>().text = controller.dataObject.scoreSurvival + ""; break;
            case "Versus": GetComponent<TextMesh>().text = controller.dataObject.scoreVersus + ""; break;
        }
        Debug.Log(GetComponent<Transform>().parent.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
