using UnityEngine;
using System.Collections;

public class FightMusic : MonoBehaviour {
    public AudioClip[] musica;
	// Use this for initialization
	void Start () {
        int a= Random.Range(0, musica.Length);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = musica[a];
        if (a == 0)
        {
            audio.volume = 0.3f;
        }
        else
        {
            audio.volume = 0.5f;
        }
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
