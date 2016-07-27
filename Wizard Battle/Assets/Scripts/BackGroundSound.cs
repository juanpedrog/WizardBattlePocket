using UnityEngine;
using System.Collections;

public class BackGroundSound : MonoBehaviour {
    public static BackGroundSound backgroundsound;
    void Awake()
    {
        if (backgroundsound == null)
        {
            backgroundsound = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this,"DestroySound");
	}
    void DestroySound(Notification notification)
    {
        Destroy(gameObject);
    }
}
