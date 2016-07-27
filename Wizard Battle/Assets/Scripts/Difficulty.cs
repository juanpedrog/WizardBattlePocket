using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour {
    Controller controller;
    int turn;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        switch (controller.loadDifficulty())
        {
            case 1: GameObject.Find("Easy").GetComponent<TextMesh>().color = Color.red; turn = 1;
                break;
            case 2: GameObject.Find("Medium").GetComponent<TextMesh>().color = Color.red; turn = 2;
                break;
            case 3: GameObject.Find("Hard").GetComponent<TextMesh>().color = Color.red; turn = 3;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        switch (GetComponent<Transform>().name)
        {
            case "Easy": controller.saveDifficulty(1); turn = 1; break;
            case "Medium": controller.saveDifficulty(2); turn = 2; break;
            case "Hard": controller.saveDifficulty(3); turn = 3; break;
        }

        block();
    }
    public void block()
    {
        if (turn == 1)
        {
            GameObject.Find("Medium").GetComponent<TextMesh>().color = Color.white;
            GameObject.Find("Hard").GetComponent<TextMesh>().color = Color.white;
        }
        if (turn == 2)
        {
            GameObject.Find("Easy").GetComponent<TextMesh>().color = Color.white;
            GameObject.Find("Hard").GetComponent<TextMesh>().color = Color.white;
        }
        if (turn == 3)
        {
            GameObject.Find("Easy").GetComponent<TextMesh>().color = Color.white;
            GameObject.Find("Medium").GetComponent<TextMesh>().color = Color.white;
        }
        GetComponent<TextMesh>().color = Color.red;
    }
}
