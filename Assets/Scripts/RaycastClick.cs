using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastClick : MonoBehaviour
{
    public Text sizes;
    public Text materials;
    public Text colours;
    public Text condition;
    public Text sex;
    public Text brands;
    public GameObject checkOutPanel;
    public GameObject confirmationPopUp;
    public GameObject itemPanelOnBasket;
    public GameObject previousPageButton;
    public Text filterPrint;

    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    MySqlCommand command;
    MySqlConnection connection = new MySqlConnection(db_connection);
    MySqlDataReader read;

    bool filterButtonPressed = false;
    int sizeIndex =0;
    int materialIndex = 0;
    int colourIndex = 0;
    int conditionIndex = 0;
    int brandIndex = 0;
    int sexIndex = 0;
    FetchProductsProperties fetch = new FetchProductsProperties();
    FilteringResults productsFilter = new FilteringResults();
    void Start()
    {
        if (FilteringResults.limitation > 0)
            productsFilter.showButton(previousPageButton);
        else
            productsFilter.hideButton(previousPageButton);
        fetch.productSizes();
        Debug.Log("Sizes Fetched");
        fetch.productMaterials();
        Debug.Log("Materials Fetched");
        fetch.productColours();
        Debug.Log("Colours Fetched");
        fetch.productCondition();
        Debug.Log("Condition Fetched");
        fetch.productSex();
        Debug.Log("Sex fetched");
        fetch.productBrand();
        Debug.Log("Brand fetched");
    }

    void Update()
    {
        RaycastHit hit;


              float theDistance = -1.0f;

              Vector3 forward = transform.TransformDirection(Vector3.forward) * 10000;
              Debug.DrawRay(transform.position, forward, Color.red);


        if (Physics.Raycast(transform.position, (forward), out hit))
              {

                    theDistance = hit.distance;
                    //print(theDistance + " " + hit.collider.gameObject.name);

            if (hit.collider.gameObject.name == "Product1")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {                  
                    if (filterButtonPressed == false)
                    {
                        productsFilter.fetchProducts();

                        if (FilteringResults.productList[3].Equals("-1"))
                        {
                            print("No product to show on Button 1! ");
                        }
                        else if (!FilteringResults.productList[3].Equals("-1"))
                        {
                            GameManager.selectedListingID = FilteringResults.productList[3];
                            Initiate.Fade("Product Description", Color.black, 2.0f);
                            print("Its fetching without filters");
                        }
                    }
                    else if (filterButtonPressed == true)
                    {
                        productsFilter.filterProducts();
                       
                        if (FilteringResults.filteredProducts[3].Equals("-1"))
                        {
                            print("No product to show on Button 1! ");
                        }
                        else if (!FilteringResults.filteredProducts[3].Equals("-1"))                            
                        {
                            GameManager.selectedListingID = FilteringResults.filteredProducts[3];
                            Initiate.Fade("Product Description", Color.black, 2.0f);
                            print("Its fetching with filters");
                        }
                    }
                }
                }

            if (hit.collider.gameObject.name == "Product2")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (filterButtonPressed == false)
                    {
                        productsFilter.fetchProducts();
                        if (FilteringResults.productList[2].Equals("-1"))
                        {
                            print(" No product to show on Button 2! ");
                        }
                        else if (!FilteringResults.productList[2].Equals("-1"))
                        {
                            GameManager.selectedListingID = FilteringResults.productList[2];
                            Initiate.Fade("Product Description", Color.black, 2.0f);
                        }                      
                    }
                    else if (filterButtonPressed == true)
                    {
                        productsFilter.filterProducts();
                        if (FilteringResults.filteredProducts[2].Equals("-1"))
                        {
                            print("No product to show on Button 2! ");
                        }
                        else if(!FilteringResults.filteredProducts[2].Equals("-1")){
                            GameManager.selectedListingID = FilteringResults.filteredProducts[2];
                            Initiate.Fade("Product Description", Color.black, 2.0f);
                        }
                    }
                }
            }

            if (hit.collider.gameObject.name == "Product3")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (filterButtonPressed == false)
                    {
                        productsFilter.fetchProducts();
                        if (FilteringResults.productList[1].Equals("-1"))
                        {
                            print(" No product to show on Button 3!");
                        }
                        else if (!FilteringResults.productList[1].Equals("-1"))
                        {
                            GameManager.selectedListingID = FilteringResults.productList[1];
                            Initiate.Fade("Product Description", Color.black, 2.0f);
                        }
                    }
                    else if (filterButtonPressed == true)
                    {
                        productsFilter.filterProducts();
                        if (FilteringResults.filteredProducts[1].Equals("-1"))
                        {
                            print(" No product to show on Button 3! ");
                        }
                        else if(!FilteringResults.filteredProducts.Equals("-1"))
                        {
                            GameManager.selectedListingID = FilteringResults.filteredProducts[1];
                            Initiate.Fade("Product Description", Color.black, 2.0f);
                        }
                    }
                }
            }

            if (hit.collider.gameObject.name == "Product4")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (filterButtonPressed == false)
                    {
                        productsFilter.fetchProducts();
                        if (FilteringResults.productList[0].Equals("-1"))
                        {
                            print(" No product to show on Button 4! ");
                        }
                        else if (!FilteringResults.productList[0].Equals("-1"))
                        {
                            GameManager.selectedListingID = FilteringResults.productList[0];
                            Initiate.Fade("Product Description", Color.black, 2.0f);
                        }
                    }
                    else if (filterButtonPressed == true)
                    {
                        productsFilter.filterProducts();

                        if (FilteringResults.filteredProducts[0].Equals("-1"))
                        {
                            print(" No product to show on Button 4! ");
                        }
                        else if (!FilteringResults.filteredProducts[0].Equals("-1"))
                        {
                            GameManager.selectedListingID = FilteringResults.filteredProducts[0];
                            Initiate.Fade("Product Description", Color.black, 2.0f);
                        }
                       /* for (int i = 0; i < FilteringResults.filteredProducts.Count; i++)
                        {
                            print("Element : "+FilteringResults.filteredProducts[i]);
                        }*/
                    }
                }
            }

            if (hit.collider.gameObject.name == "NextButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    productsFilter.nextPage();
                    //productsFilter.fetchProducts();
                    if (FilteringResults.limitation > 0)
                    {
                        productsFilter.showButton(previousPageButton);
                    }
                }
            }

            if (hit.collider.gameObject.name == "PreviousButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    productsFilter.previousPage();

                    if (FilteringResults.limitation <= 0)
                    {
                        productsFilter.hideButton(previousPageButton);
                        //previousPageButton.gameObject.SetActive(false);         // SOLVE THIS !!
                    }
                }
            }

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

            if (hit.collider.gameObject.name == "ProductPageButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Initiate.Fade("Product Scene", Color.black, 2.0f);
                }
            }

            if (hit.collider.gameObject.name == "view3Dbtn")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Initiate.Fade("ModelScene", Color.black, 2.0f);
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
                    Initiate.Fade("Product Scene", Color.black, 2.0f);
                }
            }

            if (hit.collider.gameObject.name == "view3dBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Initiate.Fade("ModelScene", Color.black, 2.0f);
                }
            }

            if (hit.collider.gameObject.name == "addToBasketBtnHelper")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ProductDescription.addToBasket();
                    Initiate.Fade("Basket Scene", Color.black, 2.0f);
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
                    Initiate.Fade("OrdersScene", Color.black, 2.0f);
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
                     filterButtonPressed = true;
                    FilteringResults.sizeSelected = FetchProductsProperties.sizeValues[sizeIndex];
                    FilteringResults.materialSelected = FetchProductsProperties.materialValues[materialIndex];
                    FilteringResults.colourSelected = FetchProductsProperties.colourValues[colourIndex];
                    FilteringResults.conditionSelected = FetchProductsProperties.conditionValues[conditionIndex];
                    FilteringResults.sexSelected = FetchProductsProperties.sexValues[sexIndex];
                    FilteringResults.brandSelected = FetchProductsProperties.brandValues[brandIndex];
                    filterPrint.text =  FilteringResults.test();
                   
                }
            }

            if (hit.collider.gameObject.name == "rmvFiltersButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    filterButtonPressed = false;
                    print("Filter Removed! ");
                }
            }

            if (hit.collider.gameObject.name == "sizeUpButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (sizeIndex < FetchProductsProperties.sizeValues.Count -1) {
                        sizeIndex++;
                        sizes.text = FetchProductsProperties.sizeValues[sizeIndex];
                    }
                    else
                    {
                        sizeIndex = 0;
                        sizes.text = FetchProductsProperties.sizeValues[sizeIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "sizeDownButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (sizeIndex > 0)
                    {
                        sizeIndex--;
                        sizes.text = FetchProductsProperties.sizeValues[sizeIndex];
                    }
                    else
                    {
                        sizeIndex = FetchProductsProperties.sizeValues.Count - 1;
                        sizes.text = FetchProductsProperties.sizeValues[sizeIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "materialUpButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (materialIndex < FetchProductsProperties.materialValues.Count - 1)
                    {
                        materialIndex++;
                        materials.text = FetchProductsProperties.materialValues[materialIndex];
                    }
                    else
                    {
                        materialIndex = 0;
                        materials.text = FetchProductsProperties.materialValues[materialIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "materialDownButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (materialIndex > 0)
                    {
                        materialIndex--;
                        materials.text = FetchProductsProperties.materialValues[materialIndex];
                    }
                    else
                    {
                        materialIndex = FetchProductsProperties.materialValues.Count - 1;
                        materials.text = FetchProductsProperties.materialValues[materialIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "colourUpButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (colourIndex < FetchProductsProperties.colourValues.Count -1) {
                        colourIndex++;
                        colours.text = FetchProductsProperties.colourValues[colourIndex];
                    }
                    else
                    {
                        colourIndex = 0;
                        colours.text = FetchProductsProperties.colourValues[colourIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "colourDownButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (colourIndex > 0)
                    {
                        colourIndex--;
                        colours.text = FetchProductsProperties.colourValues[colourIndex];
                    }
                    else
                    {
                        colourIndex = FetchProductsProperties.colourValues.Count - 1;
                        colours.text = FetchProductsProperties.colourValues[colourIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "conditionUpButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (conditionIndex < FetchProductsProperties.conditionValues.Count - 1)
                    {
                        conditionIndex++;
                        condition.text = FetchProductsProperties.conditionValues[conditionIndex];
                    }
                    else
                    {
                        conditionIndex = 0;
                        condition.text = FetchProductsProperties.conditionValues[conditionIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "conditionDownButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (conditionIndex > 0)
                    {
                        conditionIndex--;
                        condition.text = FetchProductsProperties.conditionValues[conditionIndex];
                    }
                    else
                    {
                        conditionIndex = FetchProductsProperties.conditionValues.Count - 1;
                        condition.text = FetchProductsProperties.conditionValues[conditionIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "brandUpButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (brandIndex < FetchProductsProperties.brandValues.Count - 1)
                    {
                        brandIndex++;
                        brands.text = FetchProductsProperties.brandValues[brandIndex];
                    }
                    else
                    {
                        brandIndex = 0;
                        brands.text = FetchProductsProperties.brandValues[brandIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "brandDownButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (brandIndex > 0)
                    {
                        brandIndex--;
                        brands.text = FetchProductsProperties.brandValues[brandIndex];
                    }
                    else
                    {
                        brandIndex = FetchProductsProperties.brandValues.Count - 1;
                        brands.text = FetchProductsProperties.brandValues[brandIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "sexUpButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (sexIndex < FetchProductsProperties.sexValues.Count - 1)
                    {
                        sexIndex++;
                        sex.text = FetchProductsProperties.sexValues[sexIndex];
                    }
                    else
                    {
                        sexIndex = 0;
                        sex.text = FetchProductsProperties.sexValues[sexIndex];
                    }
                }
            }

            if (hit.collider.gameObject.name == "sexDownButton")
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (sexIndex > 0)
                    {
                        sexIndex--;
                        sex.text = FetchProductsProperties.sexValues[sexIndex];
                    }
                    else
                    {
                        sexIndex = FetchProductsProperties.sexValues.Count - 1;
                        sex.text = FetchProductsProperties.sexValues[conditionIndex];
                    }
                }
            }
        }
    }
}
