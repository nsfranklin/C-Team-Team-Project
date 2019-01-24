using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneWhenUnmounted : MonoBehaviour
{
    public string SceneToLoad;
    // Use this for initialization
    void Start()
    {

    }
    /*
    void Update()
    {
        if (!(OVRPlugin.hasVrFocus && OVRPlugin.hasInputFocus))
        {
            SceneManager.LoadScene(SceneToLoad);
            print("focus lost");
        }
    }
    */
}
