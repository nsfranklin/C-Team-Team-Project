using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class ShowPayeeDetails : MonoBehaviour
{
    public Text sortCodeText;
    public Text accountNumberText;
    public Text cardholderNameText;

    public void getData()
    {
        string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
        MySqlCommand command;
        MySqlConnection connection = new MySqlConnection(db_connection);
        MySqlDataReader read;

        string query = "select SortCode,AccountNumber,PayeeName from cTeamTeamProjectDatabase.PayeeInformation where UserID = 8";

        try
        {
            connection.Open();
            print("Connection to MySQL Database is succeeded! ");
            command = new MySqlCommand(query,connection);
            read = command.ExecuteReader();

            while (read.Read())
            {
                sortCodeText.text = read.GetValue(0).ToString();
                accountNumberText.text = read.GetValue(1).ToString();
                cardholderNameText.text = read.GetValue(2).ToString();
            }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
        print("Test! Connection Closed! ");
    }
}
