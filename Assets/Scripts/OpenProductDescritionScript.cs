﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OpenProductDescritionScript : MonoBehaviour {

    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();

    // Use this for initialization
    void Start()
    {
        definedButton = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                //SceneManager.LoadScene("Product Description");
                Initiate.Fade("Product Description", Color.black, 2.0f);  //This will change the scene using Fade to black animation!!!
                OnClick.Invoke();
            }
        }
    }
}
