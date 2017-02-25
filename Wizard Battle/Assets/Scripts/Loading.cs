using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
    public string scene;
    AsyncOperation ao;
    bool allow = false;
    Controller controller;
    // Use this for initialization
    void Start () {
        controller = GameObject.FindObjectOfType<Controller>();
        if (controller != null)
        {
            scene = controller.scene;
            loading();
        }
        else
        {
            Invoke("loading", 2f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void loading()
    {
        ao=SceneManager.LoadSceneAsync(scene);
        allow = true;
    }
}
