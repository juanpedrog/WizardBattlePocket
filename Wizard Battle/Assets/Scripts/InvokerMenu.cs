using UnityEngine;
using System.Collections;

public class InvokerMenu : MonoBehaviour {
    Controller controller;
    public GameObject menu, exhibition;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        if (!controller.principal)
        {
            AdManager.Instance.showBanner();
            Instantiate(menu, new Vector3(-3.56f, 2.4f, -2.13f), Quaternion.identity);
            Instantiate(exhibition, new Vector3(3.88f, -0.83f, -2.40625f), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
