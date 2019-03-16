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


    public static List<string> products = new List<string>();
    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    MySqlCommand command;
    MySqlConnection connection = new MySqlConnection(db_connection);
    MySqlDataReader read;

    public static Text theText;
    private int numberofFilteredProd;
    private List<GameObject> buttons;
    ButtonsControl allButtons = new ButtonsControl();

    public static string test()
    {
        string s= "Filters: "+sizeSelected + " - " + materialSelected + " - " + colourSelected;
        return s;
    }

   public void FilterButtonClicked()
    {
        filterProducts();
        buttons = allButtons.GetButtonsList();

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }

            buttons.Clear();
        }

        for (int i = 1; i <= numberofFilteredProd; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonsList>().setText("Product #" + i);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
        print("It is going through start method");
    }

    public void filterProducts()
    {
        string temp ="";
        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "SELECT count(*) FROM cTeamTeamProjectDatabase.Product  where Size = 10 and Material = 'Cotton' and Colour='Black';";
            command = new MySqlCommand(query, connection);
            read = command.ExecuteReader();

            while (read.Read())
            {
                temp = read.GetValue(0).ToString();

            }
            numberofFilteredProd = int.Parse(temp);
            print(" This motherfucker is workiiiinggg ");

        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }

}
