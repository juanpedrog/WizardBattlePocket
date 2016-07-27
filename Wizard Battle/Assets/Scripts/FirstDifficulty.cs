using UnityEngine;
using System.Collections;

public class FirstDifficulty : MonoBehaviour {
    Controller controller;
    // Use this for initialization
    void Start()
    {
        controller = GameObject.FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        switch (GetComponent<Transform>().name)
        {
            case "Easy": controller.saveDifficulty(1); Destroy(GameObject.Find("Difficulty(Clone)")); break;
            case "Medium": controller.saveDifficulty(2); Destroy(GameObject.Find("Difficulty(Clone)")); break;
            case "Hard": controller.saveDifficulty(3); Destroy(GameObject.Find("Difficulty(Clone)")); break;
        }
    }
    
}
