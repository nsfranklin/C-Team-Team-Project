using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;
public class ProceedWithOrder : MonoBehaviour
{/*
    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    MySqlCommand command;
    MySqlConnection connection = new MySqlConnection(db_connection);
    MySqlDataReader read;

    public void proceedWithOrder()
    {
        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "INSERT INTO cTeamTeamProjectDatabase.Order (PurchaserID,OrderID,SellerID,ProductID,OrderState,isOpen)VALUES(" + userIdText.text + ",2," + sellerIdtext.text + "," + listingIdtext.text + ",0,1); ";
            command = new MySqlCommand(query, connection);
            read = command.ExecuteReader();
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
        print("Connection closed! Order processed.");
    }
    */
}
