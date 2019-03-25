using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class View3Dimage : MonoBehaviour
{
    public void sceneTransition()
    {
        //SceneManager.LoadScene("Product Description");
        Initiate.Fade("3DObjectScene", Color.black, 2.0f);
    }
}