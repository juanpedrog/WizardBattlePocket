using UnityEngine;
using System.Collections;

public class UnblockBosses : MonoBehaviour {
  
	// Use this for initialization
	void Start () {
        
	}
	public void block(Notification notification)
    {
        GameObject.Find("BossMessage").GetComponent<TextMesh>().text= "THIS CHARACTER IS BLOCKED-";
    }
	// Update is called once per frame
	void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this,"block");
	}
}
