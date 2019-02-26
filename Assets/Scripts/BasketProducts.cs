using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class BasketProducts : MonoBehaviour
{
    public Text productName;
    public Text productPrice;

    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    MySqlCommand command;
    MySqlConnection connection = new MySqlConnection(db_connection);
    MySqlDataReader read;

    void Start()
    {
        getData();
    }

    public void getData()
    {
        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "select Name, Price from cTeamTeamProjectDatabase.Product where ListingID in (select UserID from Basket where UserID=@userid);";
            command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@userid", GameManager.selectedListingID);
            read = command.ExecuteReader();

             while (read.Read())
             {
                 productName.text = read.GetValue(0).ToString();
                 productPrice.text = read.GetValue(1).ToString();
             }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }
        read.Close();
        //connection.Close();
        //print("Connection closed! ");
        print("Connection still open!! ");
    }

    //METHOD WHICH REGISTER AN ORDER FROM BASKET GUI INTO DATABASE TABLE--
    public void proceedWithOrder()
    {
        try
        {
            // connection.Open();
            //print("Connection opened! ");     NO NEED TO OPEN CONNECTION IN THIS PHASE BECAUSE IT IS ALREADY OPENED!

            string query = "INSERT INTO cTeamTeamProjectDatabase.Order (PurchaserID,OrderID,SellerID,ProductID)VALUES("+ GameManager.loginUserID + ",15,"+ GameManager.sellerId +","+ GameManager.selectedListingID+"); ";
            command = new MySqlCommand(query, connection);
            read = command.ExecuteReader();
            print("TRY is working");
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
        //print("Connection closed! Order processed.");
    }

    public void sceneTransitionToOrderScene()
    {
        Initiate.Fade("OrdersScene", Color.black, 2.0f);
    }
}
