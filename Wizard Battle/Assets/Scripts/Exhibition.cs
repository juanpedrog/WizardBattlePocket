using UnityEngine;
using System.Collections;

public class Exhibition : MonoBehaviour {
    Controller controller;
    int pos=-1;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        Invoke("begin", 1.5f);
        if (controller.boss1Image)
        {
            Instantiate(controller.boss1Unblock, new Vector3(0, 0, -4.81f), Quaternion.identity);
            controller.boss1Image = false;
        }
        if (controller.boss2Image)
        {
            Instantiate(controller.boss2Unblock, new Vector3(0, 0, -4.81f), Quaternion.identity);
            controller.boss2Image = false;
        }
        if (controller.boss3Image)
        {
            Instantiate(controller.boss3Unblock, new Vector3(0, 0, -4.81f), Quaternion.identity);
            controller.boss3Image = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void begin()
    {
        if (pos != -1)
        {
            Destroy(GameObject.Find(controller.wizard[pos].name + "(Clone)"));
        }
        pos = Random.Range(0, controller.wizard.Length);
        Instantiate(controller.wizard[pos], GetComponent<Transform>().position, Quaternion.identity);
        GameObject.Find(controller.wizard[pos].name + "(Clone)").GetComponent<Transform>().localScale = new Vector3(1,1,1);

        Invoke("begin",30f);
    }
}
