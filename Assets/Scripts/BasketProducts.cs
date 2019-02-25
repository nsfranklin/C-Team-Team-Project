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

    public void getData()
    {
        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "select Name, Price from cTeamTeamProjectDatabase.Product where ListingID in (select UserID from Basket where UserID=5)";
            command = new MySqlCommand(query, connection);
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

        connection.Close();
        print("Connection closed! ");
    }
}
