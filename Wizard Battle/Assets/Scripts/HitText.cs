using UnityEngine;
using System.Collections;

public class HitText : MonoBehaviour {
    int num = 0;
    Controller controller;
	void Awake()
    {
        if (GetComponent<Transform>().tag.Equals("Hit"))
        {
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        GetComponent<TextMesh>().text = controller.numHits+"Hits";
        GetComponent<Transform>().tag = "Hit";
        Invoke("dest", 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
        //NotificationCenter.DefaultCenter().AddObserver(this,"change");
        //NotificationCenter.DefaultCenter().AddObserver(this,"destHits");
	}
    void change(Notification notification)
    {
        controller.numHits++;
        GetComponent<TextMesh>().text = controller.numHits + "Hits";
    }
    void destHits(Notification notification)
    {
        Invoke("dest",1.5f);
    }
    void dest()
    {
        Destroy(GetComponent<Transform>().parent.gameObject);
    }
}
