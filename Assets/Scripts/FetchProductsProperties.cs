using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class FetchProductsProperties : MonoBehaviour
{
        public static List<string> sizeValues = new List<string>();
        public static List<string> materialValues = new List<string>();
        public static List<string> colourValues = new List<string>();
    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
        static MySqlCommand command;
        static MySqlConnection connection = new MySqlConnection(db_connection);
        static MySqlDataReader read;


    //testing
    public static List<string> images = new List<string>();

    public void productSizes()
    {
        int index = 0;
        try
        {
            connection.Open();
            print("Connection for productSizes() is open! ");
            
            string query = "SELECT distinct Size from cTeamTeamProjectDatabase.Product order by size asc;";
            command = new MySqlCommand(query, connection);

            read = command.ExecuteReader();
            sizeValues.Add("None");
            while (read.Read())
            {
                sizeValues.Insert(index, read.GetString("Size")); 
            }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }

    public void productMaterials()
    {
        int index = 0;
        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "SELECT distinct Material from cTeamTeamProjectDatabase.Product;";
            command = new MySqlCommand(query, connection);

            read = command.ExecuteReader();
            materialValues.Add("None");
            while (read.Read())
            {
                materialValues.Insert(index, read.GetString("Material"));
            }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }

    public void productColours()
    {
        int index = 0;

        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "SELECT distinct Colour from cTeamTeamProjectDatabase.Product";
            command = new MySqlCommand(query, connection);

            read = command.ExecuteReader();
            colourValues.Add("None");
            while (read.Read())
            {
                colourValues.Insert(index, read.GetString("Colour"));
            }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }

    public void productImages()
    {
        int index = 0;

        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "select ImageBlob from cTeamTeamProjectDatabase.Image;";
            command = new MySqlCommand(query, connection);

            read = command.ExecuteReader();
            while (read.Read())
            {
                images.Insert(index, read.GetString("ImageBlob"));
            }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }

    public void productModel()
    {
        int index = 0;

        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "select ModelString from cTeamTeamProjectDatabase.Model where ModelID=8;";
            command = new MySqlCommand(query, connection);

            read = command.ExecuteReader();
            while (read.Read())
            {
                images.Insert(index, read.GetString("ModelString"));
            }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }
}
