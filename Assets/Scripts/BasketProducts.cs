﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class BasketProducts : MonoBehaviour
{
    public Text listingId;
    public Text productName;
    public Text productPrice;

    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    public static MySqlCommand command;
    public static MySqlConnection connection = new MySqlConnection(db_connection);
    public static MySqlDataReader read;

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

            string query = "select ListingID, Name, Price from cTeamTeamProjectDatabase.Product where ListingID="+GameManager.selectedListingID+";";       //in (select UserID from Basket where UserID=@userid);";
            command = new MySqlCommand(query, connection);

           // command.Parameters.AddWithValue("@userid", GameManager.loginUserID);
            read = command.ExecuteReader();

             while (read.Read())
             {
                listingId.text = read.GetValue(0).ToString();
                 productName.text = read.GetValue(1).ToString();
                 productPrice.text = read.GetValue(2).ToString();
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
    public static void proceedWithOrder()
    {
        try
        {
            // connection.Open();
            //print("Connection opened! ");     NO NEED TO OPEN CONNECTION IN THIS PHASE BECAUSE IT IS ALREADY OPENED!
            read.Close();
            string query = "INSERT INTO cTeamTeamProjectDatabase.Order (PurchaserID,OrderID,SellerID,ProductID)VALUES(@purchaserid ,15, @sellerId, @prodid); ";
            command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@purchaserid", GameManager.loginUserID);
            command.Parameters.AddWithValue("@sellerId", GameManager.sellerId);
            command.Parameters.AddWithValue("@prodid", GameManager.selectedListingID);

            read = command.ExecuteReader();
            print("Order Proceeded! ");
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
