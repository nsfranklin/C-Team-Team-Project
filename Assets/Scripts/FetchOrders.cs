using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;
public class FetchOrders : MonoBehaviour
{
    public Text productID;

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

            string query = "SELECT ProductID FROM cTeamTeamProjectDatabase.`Order` where ProductID="+ GameManager.selectedListingID + ";";
            command = new MySqlCommand(query, connection);
            read = command.ExecuteReader();

            while (read.Read())
            {
                productID.text = read.GetValue(0).ToString();
            }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }
        read.Close();
        connection.Close();
        print("Connection closed! ");
    }
}
