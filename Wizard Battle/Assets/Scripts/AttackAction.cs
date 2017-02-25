using UnityEngine;
using System.Collections;
using System;

public class AttackAction : MonoBehaviour {
    public int vel;
    public GameObject wizard;
    public Color[] colores;
	// Use this for initialization
	void Start () {
        try {
            GetComponent<SpriteRenderer>().color = colores[(int)UnityEngine.Random.Range(0f, colores.Length)];
        }
        catch (IndexOutOfRangeException e)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (GetComponent<Transform>().position.x<0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(vel, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-vel, GetComponent<Rigidbody2D>().velocity.y);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
