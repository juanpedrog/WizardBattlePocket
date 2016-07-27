using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
    float score = 0;
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        score = controller.score;
    }
	
	// Update is called once per frame
	void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this, "score100");
        NotificationCenter.DefaultCenter().AddObserver(this,"saveScore");
        GetComponent<TextMesh>().text = score + "";
	}
    void score100(Notification notification)
    {
        points100();
    }
    void points100()
    {
        score += 100;
    }
    void saveScore(Notification notification)
    {
        controller.score = score;
    }
}
