using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;


public class ProductDescription : MonoBehaviour
{
    public Text listingIdtext;
    //public Text sellerIdtext;
    public Text priceText;
    public Text nameText;
    public Text descriptionText;
    //public Text dateCreatedText;
    public Text conditionText;
    public Text colourText;
    public Text brandText;
    //public Text typeText;
    public Text sizeText;
    public Text materialText;
   // public Text sexText;
    public Text stateText;

   // public Text basketProductNameTxt;
    //public Text basketProductPriceTxt;

 public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
        MySqlCommand command;
        MySqlConnection connection = new MySqlConnection(db_connection);
        MySqlDataReader read;

    public void getData()
    {
        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "select * from cTeamTeamProjectDatabase.Product where ListingID=1";
            command = new MySqlCommand(query, connection);
            read = command.ExecuteReader();

            while (read.Read())
            {
                listingIdtext.text = read.GetValue(0).ToString();
                //sellerIdtext.text = read.GetValue(1).ToString();
                priceText.text = read.GetValue(2).ToString();
                nameText.text = read.GetValue(3).ToString();
                descriptionText.text = read.GetValue(4).ToString();
                //dateCreatedText.text = read.GetValue(5).ToString();
                conditionText.text = read.GetValue(7).ToString();
                colourText.text = read.GetValue(8).ToString();
                brandText.text = read.GetValue(9).ToString();
                //typeText.text = read.GetValue(10).ToString();
                sizeText.text = read.GetValue(11).ToString();
                materialText.text = read.GetValue(12).ToString();
               // sexText.text = read.GetValue(13).ToString();
                stateText.text = read.GetValue(14).ToString();
            }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
        print("Connection closed! ");
    }

    public void addToBasket()
    {
        try
        { 
        connection.Open();
        print("Connection opened! ");

        string query = "insert into cTeamTeamProjectDatabase.Basket (UserID,ProductID) values("+listingIdtext.text+","+priceText.text+")";
        command = new MySqlCommand(query, connection);
        read = command.ExecuteReader();

       /* while (read.Read())
        {
            basketProductNameTxt.text = read.GetValue(0).ToString();
            basketProductPriceTxt.text = read.GetValue(1).ToString();
        }*/
        }
        catch (MySqlException exception)
         {
            print("Error" + exception.ToString());
         }

connection.Close();
        print("Connection closed! ");

 
    }
}
