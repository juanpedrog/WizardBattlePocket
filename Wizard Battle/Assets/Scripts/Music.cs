using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

    GameObject[] music, superPower, superPowerEnemy;
    Controller controller;
    string tagText="Music";
    // Use this for initialization
    void Start()
    {
        controller = GameObject.FindObjectOfType<Controller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.music)
        {
            GetComponent<TextMesh>().color = Color.red;
        }
        else
        {
            GetComponent<TextMesh>().color = Color.white;
        }
    }
    void OnMouseDown()
    {
        controller.music = !controller.music;
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
        }
    }
    public void soundMenu()
    {
        OnMouseDown();
    }
}
