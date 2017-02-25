using UnityEngine;
using System.Collections;

public class HeadInvoker : MonoBehaviour {
    Controller controller;
    public bool player;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        if (player)
        {
            Instantiate(controller.heads[controller.posPlayer],GetComponent<Transform>().position,Quaternion.identity);
        }
        else
        {
            if (controller.bossTime)
            {
                if (controller.posEnemy == 0 || controller.posEnemy == 3)
                {
                    Instantiate(controller.headsEnemy[7], GetComponent<Transform>().position, Quaternion.identity);
                }
                if (controller.posEnemy == 1 || controller.posEnemy == 4)
                {
                    Instantiate(controller.headsEnemy[8], GetComponent<Transform>().position, Quaternion.identity);
                }
                if (controller.posEnemy == 2)
                {
                    Instantiate(controller.headsEnemy[9], GetComponent<Transform>().position, Quaternion.identity);
                }
            }
            else
            {
                if (controller.monsterTime)
                {
                    Instantiate(controller.headsEnemy[10], GetComponent<Transform>().position, Quaternion.identity);
                }
                else
                {
                    Instantiate(controller.headsEnemy[controller.posEnemy], GetComponent<Transform>().position, Quaternion.identity);
                }
            }
            
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
