using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public GameObject expl;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            Destroy(collider.gameObject);
            Instantiate(expl,GetComponent<Transform>().position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
