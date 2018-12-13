using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneWhenMounted : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (OVRManager.hasVrFocus && OVRManager.hasInputFocus)
        {
            SceneManager.LoadScene("Home Scene");
            print("focus gained");
        }
    }
}
