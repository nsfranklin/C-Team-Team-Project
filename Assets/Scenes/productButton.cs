
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class productButton : MonoBehaviour
{
    public int PRODUCT_DESCRIPTION_INDEX = 8;

    public Button buttonComponent;
    public Text productName;
    public Image coverImage;
    public Text priceString;


    private int productID;
    private ButtonsList buttonList;

    // Use this for initialization
    void Start()
    {    }

    private void Update()
    {
        /*
        if (RAYCAST_HITTING && INPUT_IS_TRUE)
        {
            SceneManager.LoadScene(PRODUCT_DESCRIPTION_INDEX);
        }
        */
    }
    public void Setup(int productIDFromDB, string productNameFromDB, int price)//, Image coverImageFromDB)
    {
        productID = productIDFromDB;
        productName.text = productNameFromDB;
        //coverImage = coverImageFromDB;
        priceString.text = price.ToString();
        //buttonList = inputButtonList;

    }

}