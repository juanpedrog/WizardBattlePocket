using UnityEngine;
using System.Collections;

public class KOButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void next()
    {
        Application.LoadLevel("FightScene");
    }
    public void selectionscene()
    {
        Application.LoadLevel("SelectionScene");
    }
}
