using UnityEngine;
using System.Collections;

public class BackgroundsGenerator : MonoBehaviour {
    public GameObject[] backgrounds;
    public GameObject[] backgroundsBoss;
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        int pos = Random.Range(0,backgrounds.Length);
        if (!controller.bossTime)
        {
            switch (pos)
            {
                case 0:
                    Instantiate(backgrounds[0], new Vector3(0 , -1.7f, 3.64f), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(backgrounds[1], new Vector3(-0.71f, 0.94f, 3.19f), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(backgrounds[2], new Vector3(0, 1f, 3.19f), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(backgrounds[3], new Vector3(-0.07f, 0.84f, 3.19f), Quaternion.identity);
                    break;
            }
        }
        else
        {
            if (controller.bossTime)
            {
                if(controller.posEnemy==0 || controller.posEnemy == 3)
                {
                    Instantiate(backgroundsBoss[0], new Vector3(-0.06f, 1.37f, 3.19f), Quaternion.identity);
                }
                if(controller.posEnemy==1 || controller.posEnemy == 4)
                {
                    Instantiate(backgroundsBoss[1], new Vector3(-0.04f, 0.59f, 3.19f), Quaternion.identity);
                }
                if (controller.posEnemy == 2)
                {
                    Instantiate(backgroundsBoss[2], new Vector3(0.1f, 0.2f, 3.19f), Quaternion.identity);
                }
            }
            controller.backgroundboss1 = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
