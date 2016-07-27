using UnityEngine;
using System.Collections;

public class PowerEnemy : MonoBehaviour {
    public GameObject power,lighting;
    public float timeIn, timeFin;
    Controller controller;
	// Use this for initialization
	void Start () {
        Invoke("powerAttack",Random.Range(timeIn,timeFin));
        controller=GameObject.FindObjectOfType<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void powerAttack()
    {
        if (controller.power)
        {
            GetComponent<AudioSource>().Play();
            switch (GetComponent<Transform>().parent.name)
            {
                case "Wizard1Enemy(Clone)": power1(); break;
                case "Wizard2Enemy(Clone)": power2(); break;
                case "Wizard3Enemy(Clone)": power6(); break;
                case "Wizard4Enemy(Clone)": power5(); break;
                case "Wizard5Enemy(Clone)": power2(); break;
                case "Wizard6Enemy(Clone)": power4(); break;
                case "Wizard7Enemy(Clone)": power7(); break;
                case "Boss1Enemy(Clone)": powerBoss1(); break;
                case "Boss2Enemy(Clone)": powerBoss2(); break;
                case "Boss3Enemy(Clone)": powerBoss3(); break;
            }
        }
        Invoke("powerAttack", Random.Range(timeIn, timeFin));
    }
    void power1()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(12.02f, 2.802013f, -2.11f), Quaternion.identity);
        Invoke("disableLighting", 2.5f);
        Invoke("destroyPower1", 2.5f);
    }
    void destroyPower1()
    {
        Destroy(GameObject.Find("Power2Enemy(Clone)"));
    }
    public void disableLighting()
    {
        Destroy(GameObject.Find("Lighting(Clone)"));
    }
    void power2()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(3.46f, 7.72f, -6.8f), Quaternion.identity);
        Invoke("disableLighting", 1f);
    }
    public void secondAttack1()
    {
        Instantiate(power, new Vector3(-0.61f, 7.72f, -6.8f), Quaternion.identity);
    }
    void power6()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(2.92f, -0.3420576f, -1.01f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPower6", 1.5f);
    }
    void destroyPower6()
    {
        Destroy(GameObject.Find("Power6(Clone)"));
    }
    void power5()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(13.69f, -1.15f, 4.32f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPower5", 1.5f);
    }
    void destroyPower5()
    {
        Destroy(GameObject.Find("Power5(Clone)"));
    }
    void power4()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(-20.96f, -9.64f, 4.32f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPower4", 1.5f);
    }
    void destroyPower4()
    {
        Destroy(GameObject.Find("Powe4(Clone)"));
    }
    void powerBoss1()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(-9f, -5.57f, -1.94f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPowerBoss1", 1.5f);
    }
    void destroyPowerBoss1()
    {
        Destroy(GameObject.Find("PowerBoss1Enemy(Clone)"));
    }
    void power7()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(8.6f, 2.3f, -1.2f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPower7", 1.5f);
    }
    void destroyPower7()
    {
        Destroy(GameObject.Find("Power7(Clone)"));
    }
    void powerBoss2()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(-1f, -0.15f, -1.94f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPowerBoss2", 1.5f);
    }
    void destroyPowerBoss2()
    {
        Destroy(GameObject.Find("powerBoss2Enemy(Clone)"));
    }
    void powerBoss3()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(8f, 7.64f, -1.43f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPowerBoss3", 1.5f);
    }
    void destroyPowerBoss3()
    {
        Destroy(GameObject.Find("PowerBoss3Enemy(Clone)"));
    }
}
