using UnityEngine;
using System.Collections;

public class ChangeColorGlow : MonoBehaviour {
    public Color original, more,aux;
	// Use this for initialization
	void Start () {
        aux = original;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<SpriteRenderer>().color = aux;
        if (aux == more)
        {
            aux = more;
        }
        else
        {
            aux = original;
        }
	}
}
