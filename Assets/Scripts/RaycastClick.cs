using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastClick : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

            RaycastHit hit;
              float theDistance = -1.0f;

              Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
              Debug.DrawRay(transform.position, forward, Color.green);

              if (Physics.Raycast(transform.position, (forward), out hit))
              {

                    theDistance = hit.distance;
                    print(theDistance + " " + hit.collider.gameObject.name);
                    if (hit.collider.gameObject.name == "ProductsBtn")
                    {
                          if (Input.GetKeyDown(KeyCode.P))
                          {
                             Initiate.Fade("Product Scene", Color.black, 2.0f);
                          }
                    }
                    if (hit.collider.gameObject.name == "BasketButton")
                    {
                        if (Input.GetKeyDown(KeyCode.P))
                        {
                            Initiate.Fade("Basket Scene", Color.black, 2.0f);
                        }
                    }

                    if (hit.collider.gameObject.name == "OrdersBtn")
                    {
                        if (Input.GetKeyDown(KeyCode.P))
                        {
                            Initiate.Fade("OrdersScene", Color.black, 2.0f);
                        }
                    }

            if (hit.collider.gameObject.name == "BasketButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Initiate.Fade("Basket Scene", Color.black, 2.0f);
                }
            }

            if (hit.collider.gameObject.name == "HomeButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Initiate.Fade("Home Scene", Color.black, 2.0f);
                }
            }

            if (hit.collider.gameObject.name == "view3Dbtn")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Initiate.Fade("3DObjectScene", Color.black, 2.0f);
                }
            }
        }
    }
}
