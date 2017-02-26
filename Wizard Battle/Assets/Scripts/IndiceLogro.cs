using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IndiceLogro : MonoBehaviour {
    public int index;
    string[] texto;
    public GameObject mensaje;
    public Image image,palomita;
    public GameObject m;
    Controller controller;
    // Use this for initialization
    void Start () {
        texto = new string[30];
        texto[0] = "Pass the arcade\nmode with Wizard1";
        controller = GameObject.FindObjectOfType<Controller>();
        for(int i = 0; i < controller.logros.Length; i++)
        {
            if (index == controller.logros[i])
            {
                image.color = Color.yellow;
                palomita.color = Color.green;
            }
        }
	}
    public void mostrar()
    {
        controller.logroMensaje = texto[index-1];
        GameObject n = GameObject.Find("LogroMensage(Clone)");
        if (n == null)
        {
            Instantiate(mensaje, new Vector3(0, 0, -3.22f), Quaternion.identity);
            Time.timeScale = 0;
        }
    }
	// Update is called once per frame
	void Update () {
     
	}
}
