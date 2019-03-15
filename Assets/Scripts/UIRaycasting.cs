﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRaycasting : MonoBehaviour
{
     GraphicRaycaster m_Raycaster;
      PointerEventData m_PointerEventData;
      EventSystem m_EventSystem;
   // Image pointer;



      void Start()
      {
          //Fetch the Raycaster from the GameObject (the Canvas)
          m_Raycaster = GetComponent<GraphicRaycaster>();
          //Fetch the Event System from the Scene
          m_EventSystem = GetComponent<EventSystem>();
      }

      void Update()
      {      
            //Check if the left Mouse button is clicked
    
                //Set up the new Pointer Event
                m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = transform.position;

                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                foreach (RaycastResult result in results)
                {
                    print("Hit " + result.gameObject.name);
                }

                if (Input.GetKey(KeyCode.P))
                {
                   //click on buttons!!     
                }
    }
}