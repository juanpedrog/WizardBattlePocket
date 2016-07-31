using UnityEngine;
using System.Collections;

public class PrincipalScreen : MonoBehaviour {
    public GameObject principal,exhibition,menu;
    Controller controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        if (!controller.principal)
        {
            Destroy(principal.gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        GetComponent<Collider2D>().enabled = false;
        principal.GetComponent<Animator>().SetBool("Enter",true);
        principal.GetComponent<AudioSource>().Play();
        Invoke("disableAnimator",1f);
        Instantiate(menu,new Vector3(-3.56f, 2.4f, -2.13f),Quaternion.identity);
        Instantiate(exhibition, new Vector3(3.88f, -0.83f, -2.40625f),Quaternion.identity);
    }
    void disableAnimator()
    {
        controller.principal = false;
        Destroy(principal.gameObject);
    }
}
