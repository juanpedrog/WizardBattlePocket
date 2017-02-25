using UnityEngine;
using System.Collections;

public class MusicStopper : MonoBehaviour {
    GameObject[] music, superPower, superPowerEnemy;
    Controller controller;
    public string tagText;
    public GameObject a1, a2, a3, duel;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        music = GameObject.FindGameObjectsWithTag(tagText);
        if (tag.Equals("Sound"))
        {
            superPower = GameObject.FindGameObjectsWithTag("SuperPower");
            superPowerEnemy = GameObject.FindGameObjectsWithTag("SuperPowerEnemy");
        }
        if (controller.music)
        {
            for (int i = 0; i < music.Length; i++)
            {
                music[i].GetComponent<AudioSource>().mute = false;
                if (superPower != null)
                {
                    superPower[i].GetComponent<AudioSource>().mute = false;
                    superPowerEnemy[i].GetComponent<AudioSource>().mute = false;
                }
            }
            if (GetComponent<Transform>().name.Equals("Invoker")&& tag.Equals("Sound"))
            {
                a1.GetComponent<AudioSource>().mute = false;
                a2.GetComponent<AudioSource>().mute = false;
                a3.GetComponent<AudioSource>().mute = false;
                duel.GetComponent<AudioSource>().mute = false;
            }
        }
        else
        {
            for (int i = 0; i < music.Length; i++)
            {
                music[i].GetComponent<AudioSource>().mute = true;
                if (superPower != null)
                {
                    superPower[i].GetComponent<AudioSource>().mute = true;
                    superPowerEnemy[i].GetComponent<AudioSource>().mute = true;
                }
            }
            if (GetComponent<Transform>().name.Equals("Invoker") && tag.Equals("Sound"))
            {
                a1.GetComponent<AudioSource>().mute = true;
                a2.GetComponent<AudioSource>().mute = true;
                a3.GetComponent<AudioSource>().mute = true;
                duel.GetComponent<AudioSource>().mute = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
