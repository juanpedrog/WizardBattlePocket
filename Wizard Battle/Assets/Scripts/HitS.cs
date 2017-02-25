using UnityEngine;
using System.Collections;

public class HitS : MonoBehaviour {

    public GameObject hit;
    private int numHits;
    Vector3 posOrigin;
    bool keep;
    Controller controller;
	// Use this for initialization
	void Start () {
        numHits = 0;
        keep = true;
        controller = GameObject.FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this,"showHits");
	}
    void showHits(Notification notification)
    {
        controller.numHits++;
        Instantiate(hit, new Vector3(-6.3f, 2.5f, -1f),Quaternion.identity);
        keep = true;
    }
    void resetHit()
    {
        //Pone en 0 numHits para volver a empezar
        numHits = 0;
    }
    void dest()
    {
        keep = false;
    }
}
