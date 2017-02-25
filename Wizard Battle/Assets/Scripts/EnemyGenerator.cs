using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
    Controller controller;
    public GameObject enemy;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        if (controller.versusMode)
        {
            if (controller.posEnemy == 7)
            {
                Instantiate(controller.bosses[0], GetComponent<Transform>().position, Quaternion.identity);
            }
            if (controller.posEnemy == 8)
            {
                Instantiate(controller.bosses[1], GetComponent<Transform>().position, Quaternion.identity);
            }
            if (controller.posEnemy == 9)
            {
                Instantiate(controller.bosses[2], GetComponent<Transform>().position, Quaternion.identity);
            }
            if (controller.posEnemy < 7)
            {
                Instantiate(controller.wizardEnemy[controller.posEnemy], GetComponent<Transform>().position, Quaternion.identity);
            }
        }
        else
        {
            findEnemy();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void findEnemy()
    {
        if (controller.bossTime  || controller.monsterTime) {
            if (controller.bossTime)
            {
                controller.posEnemy = Random.Range(0, controller.bosses.Length);
                Instantiate(controller.bosses[controller.posEnemy], GetComponent<Transform>().position, Quaternion.identity);
            }
            else
            {
                Instantiate(controller.monsters[0], GetComponent<Transform>().position, Quaternion.identity);
            }
        }
        else {
            int pos = Random.Range(0, controller.wizardEnemy.Length);
            controller.posEnemy = pos;
            enemy = controller.wizardEnemy[pos];
            if (enemy != null)
            {
                Instantiate(enemy, GetComponent<Transform>().position, Quaternion.identity);
                controller.wizardEnemy[pos] = null;

            }
            else
            {
                findEnemy();
            }
        }
    }
    public bool checkEnemys(){
        for (int i = 0; i < controller.wizardEnemy.Length; i++)
        {
            if (controller.wizardEnemy[i] != null)
            {
                return false;
            }
        }
        return true;
    }

}
