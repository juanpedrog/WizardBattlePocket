using UnityEngine;
using System.Collections;

public class OpeningNext : MonoBehaviour {
    public Animator anim;
    public TextMesh text;
    int counter;
	// Use this for initialization
	void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        switch (counter)
        {
            case 0: text.text = "But he can't,because the wizards fight together."; anim.SetBool("pass", true); counter++; break;
            case 1: text.text = "But, after 100 years later two evil wizards help him\nto return, and now its your responsability stop them.\n¡Good Luck!";
                anim.SetBool("pass2",true);
                counter++;
                break;
            case 2: Application.LoadLevel("SelectionScene"); break;
        }
        
    }
}
