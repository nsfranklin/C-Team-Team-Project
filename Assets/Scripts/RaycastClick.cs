using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastClick : MonoBehaviour
{
   public GameObject checkOutPanel;
    public GameObject confirmationPopUp;
    public GameObject itemPanelOnBasket;
    public Dropdown sizeDropdown;
    public RectTransform sizeDropdownTemplate;
    public Text filterPrint;

    void Update()
    {
        RaycastHit hit;

              float theDistance = -1.0f;

              Vector3 forward = transform.TransformDirection(Vector3.forward) * 10000;
              Debug.DrawRay(transform.position, forward, Color.red);


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

            if (hit.collider.gameObject.name == "ProdButtonHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Initiate.Fade("Product Description", Color.black, 2.0f);
                }
            }

            if (hit.collider.gameObject.name == "backBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Initiate.Fade("Basket Scene", Color.black, 2.0f);
                }
            }

            if (hit.collider.gameObject.name == "view3dBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Initiate.Fade("3DObjectScene", Color.black, 2.0f);
                }
            }

            if (hit.collider.gameObject.name == "addToBasketBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ProductDescription.addToBasket();
                }
            }

            if (hit.collider.gameObject.name == "CheckOutBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    checkOutPanel.gameObject.SetActive(true);
                }
            }

            if (hit.collider.gameObject.name == "cancelBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    checkOutPanel.gameObject.SetActive(false);
                }
            }
            if (hit.collider.gameObject.name == "purchaseBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    confirmationPopUp.gameObject.SetActive(true);
                }
            }

            if (hit.collider.gameObject.name == "cnclBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    confirmationPopUp.gameObject.SetActive(false);
                }
            }

            if (hit.collider.gameObject.name == "continueBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    BasketProducts.proceedWithOrder();
                }
            }

            if (hit.collider.gameObject.name == "removeBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ProductDescription.removeFromBasket();
                    itemPanelOnBasket.gameObject.SetActive(false);
                }
            }

            if (hit.collider.gameObject.name == "GoBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                   filterPrint.text =  FilteringResults.test();
                }
            }

            if (hit.collider.gameObject.name == "openSizeDrpHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    FetchSizesFromDb.sizeDropdown();
                    sizeDropdown.gameObject.SetActive(true);
                    sizeDropdownTemplate.gameObject.SetActive(true);

                }
            }

        }
    }
}
