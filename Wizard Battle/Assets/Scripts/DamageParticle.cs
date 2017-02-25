using UnityEngine;
using System.Collections;

public class DamageParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("destroy",1.2f);//Destruye el efecto de la particula para que no gaste memoria
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void destroy()
    {
        Destroy(this.gameObject);
    }
}
