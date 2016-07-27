using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {
    public GameObject power;
    public GameObject lighting;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this, "powern");
	}
    public void powern(Notification notification)
    {
        GetComponent<AudioSource>().Play();
        switch (GetComponent<Transform>().name)
        {
            case "Wizard1(Clone)": power2(); break;
            case "Wizard2(Clone)": power1(); break;
            case "Wizard4(Clone)": power5(); break;
            case "Wizard3(Clone)": power6(); break;
            case "Wizard5(Clone)": power1(); break;
            case "Wizard6(Clone)": power4(); break;
            case "Wizard7(Clone)": power7(); break;
            case "Boss1(Clone)": powerBoss1(); break;
            case "Boss2(Clone)": powerBoss2(); break;
            case "Boss3(Clone)": powerBoss3(); break;
        }
    }
    public void power1()
    {
        Instantiate(lighting,new Vector3(0,0, 2.94f),Quaternion.identity);
        Instantiate(power, new Vector3(-4.67f, 7.72f, -6.8f), Quaternion.identity);
        Invoke("disableLighting",1f);
    }
    public void secondAttack1()
    {
        Instantiate(power, new Vector3(-1.02f, 7.72f, -6.8f), Quaternion.identity);
    }
    public void disableLighting()
    {
        Destroy(GameObject.Find("Lighting(Clone)"));
    }
    void power2()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(-12.34831f, 2.802013f, -2.11f), Quaternion.identity);
        Invoke("disableLighting", 2f);
        Invoke("destroyPower2",2f);
    }
    void power4()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(-13.81516f, -9.64f, 4.32f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPower4",1.5f);
    }
    void destroyPower4()
    {
        Destroy(GameObject.Find("Powe4(Clone)"));
    }
    void destroyPower2()
    {
        Destroy(GameObject.Find("Power2(Clone)"));
    }
    void power5()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(-15.08f, -1.15f, 4.32f), Quaternion.identity);;
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPower5", 1.5f);
    }
    void destroyPower5()
    {
        Destroy(GameObject.Find("Power5(Clone)"));
    }
    void power6()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(-3.036436f, -0.3420576f, -2.98f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPower6", 1.5f);
    }
    void destroyPower6()
    {
        Destroy(GameObject.Find("Power6(Clone)"));
    }
    void powerBoss1()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(1.41f, -5.57f, -1.94f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPowerBoss1", 1.5f);
    }
    void destroyPowerBoss1()
    {
        Destroy(GameObject.Find("PowerBoss1(Clone)"));
    }
    void power7()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(-10f, 2.3f, -1.2f), Quaternion.identity);
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
        Instantiate(power, new Vector3(-1.32f, -0.15f, -1.94f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPowerBoss2", 1.5f);
    }
    void destroyPowerBoss2()
    {
        Destroy(GameObject.Find("powerBoss2(Clone)"));
    }
    void powerBoss3()
    {
        Instantiate(lighting, new Vector3(0, 0, 2.94f), Quaternion.identity);
        Instantiate(power, new Vector3(-9.08f, 7.64f, -1.43f), Quaternion.identity);
        Invoke("disableLighting", 1.5f);
        Invoke("destroyPowerBoss3", 1.5f);
    }
    void destroyPowerBoss3()
    {
        Destroy(GameObject.Find("PowerBoss3(Clone)"));
    }
}
