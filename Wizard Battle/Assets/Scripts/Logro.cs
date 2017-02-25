using UnityEngine;
using System.Collections;

public class Logro : MonoBehaviour {
    public GameObject[] index;
    public Controller controller;
    IndiceLogro[] objetos;
    // Use this for initialization
    void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        objetos = new IndiceLogro[index.Length];
        for(int i = 0; i < index.Length; i++)
        {
            objetos[i] = index[i].GetComponent<IndiceLogro>();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
