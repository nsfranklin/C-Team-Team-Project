using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class FetchColoursFromDb : MonoBehaviour
{
    public Dropdown dropdownColours;
    public List<string> colourslist = new List<string>();

    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    MySqlCommand command;
    MySqlConnection connection = new MySqlConnection(db_connection);
    MySqlDataReader read;

    public int dropdownValue;
    public string message;

    // Start is called before the first frame update
    void Start()
    {
        colourDropdown();
    }


    public void colourDropdown()
    {
        int index = 0;

        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "SELECT distinct Colour from cTeamTeamProjectDatabase.Product";
            command = new MySqlCommand(query, connection);

            read = command.ExecuteReader();

            while (read.Read())
            {
                colourslist.Insert(index, read.GetString("Colour"));
               // index++;
            }
            dropdownColours = GetComponent<Dropdown>();
            dropdownColours.ClearOptions();
            dropdownColours.AddOptions(colourslist);

            FilteringResults.colourSelected = colourslist[index];
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }

    void Update()
    {
        dropdownValue = dropdownColours.value;
        message = dropdownColours.options[dropdownValue].text;
        FilteringResults.colourSelected = message;
    }
}