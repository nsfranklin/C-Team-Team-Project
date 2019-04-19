using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class FilteringResults :MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    public static string sizeSelected;
    public static string materialSelected;
    public static string colourSelected;
    public static string conditionSelected;
    public static string sexSelected;
    public static string brandSelected;

    public static List<string> productList = new List<string>();
    public static List<string> filteredProducts = new List<string>();

    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    MySqlCommand command;
    MySqlConnection connection = new MySqlConnection(db_connection);
    MySqlDataReader read;

    public static Text theText;
    private int numberofFilteredProd;
    public static int limitation =0;

    public static string test()
    {
        string s= "Filters: "+sizeSelected + " - " + materialSelected + " - " + conditionSelected+" - "+sexSelected+" - "+colourSelected+" - "+brandSelected;
        return s;
    }

    public void nextPage()
    {
        limitation = limitation + 4;
        print("Limitation reset! ");
    }

    public void showButton(GameObject x)
    {
        x.SetActive(true);
    }
    public void hideButton(GameObject x)
    {
        x.SetActive(false);
    }

    public void previousPage()
    {
        if (limitation > 0)
        {
            limitation = limitation - 4;
            print("Limitation reduced by 4 ! ");
        }
        else
            print("No previous products to show! ");
    }

    public void fetchProducts()
    {
        int index = 0;
        try
        {
            connection.Open();
            print("Connection for fetchProducts() method is open ");

            string query = "select ListingID from cTeamTeamProjectDatabase.Product LIMIT "+limitation+",4;";
            command = new MySqlCommand(query, connection);

            read = command.ExecuteReader();

            while (read.Read())
            {
                productList.Insert(index, read.GetString("ListingID"));
            }

        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
        print(" It is coming in this method! ");
    }

    public void filterProducts()
    {
        int index = 0;
        try
        {
            connection.Open();
            print("Connection opened! ");

            // string query = "SELECT ListingID FROM cTeamTeamProjectDatabase.Product  where Size ="+sizeSelected+" and Material = '"+materialSelected+"' and Colour='"+colourSelected+ "' LIMIT " + limitation + ",4;";
            string query = "SELECT ListingID FROM cTeamTeamProjectDatabase.Product  where ListingID IS NOT NULL ";

            if (!sizeSelected.Equals("None"))
            {
                query = query + " AND Size =" + sizeSelected;
            }
            if (!materialSelected.Equals("None"))
            {
                query = query + " AND Material = '" + materialSelected + "'";
            }
            if (!colourSelected.Equals("None"))
            {
                query = query + " AND Colour='" + colourSelected + "'";
            }
            if (!conditionSelected.Equals("None"))
            {
                query = query + " AND Product.Condition='" + conditionSelected + "'";
            }
            if (!sexSelected.Equals("None"))
            {
                query = query + " AND Sex='" + sexSelected + "'";
            }
            if (!brandSelected.Equals("None"))
            {
                query = query + " AND Product.Brand ='" + brandSelected + "'";
            }
            query = query + " LIMIT " + limitation + ",4;";


            command = new MySqlCommand(query, connection);
            read = command.ExecuteReader();

            while (read.Read())
            {
                filteredProducts.Insert(index, read.GetString("ListingID"));

            }

            int x = filteredProducts.Count % 4;
            if (filteredProducts.Count == 0)
            {
                x = 4;
            }
            if (x != 0)
            {
                while ((4-x) < 4)
                {
                    filteredProducts.Add("-1");
                    x = x- 1;
                }
            }
            print(" filterProducts() method is working! ");

        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }

}
