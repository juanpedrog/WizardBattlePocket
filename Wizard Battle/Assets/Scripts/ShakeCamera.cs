using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour {
    private Transform position;
    public float intensity;
    private bool allow=false;
	// Use this for initialization
	void Start () {
        position = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = position.position;
        if (allow)
        {
            this.GetComponent<Transform>().position = new Vector3(pos.x, pos.y + intensity, pos.z);
            intensity *= -1;
        }
        else
        {
            this.GetComponent<Transform>().position = new Vector3(pos.x, pos.y, pos.z);
        }
        NotificationCenter.DefaultCenter().AddObserver(this,"setAllow");
    }
    void shake()
    {
        Vector3 pos = position.position;
        this.GetComponent<Transform>().position = new Vector3(pos.x,pos.y+intensity,pos.z) ;
    }
    void setAllow(Notification notification)
    {
        allow = !allow;
    }
}
