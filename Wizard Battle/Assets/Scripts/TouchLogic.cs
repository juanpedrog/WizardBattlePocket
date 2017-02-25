using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touches.Length > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                if(this.GetComponent<GUITexture>().HitTest(Input.GetTouch(i).position))
                {
                    //JUMP
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        NotificationCenter.DefaultCenter().PostNotification(this,"jump");
                    }
                }
            }
        }
	}
}
