using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;
public class FetchMaterialFromDb : MonoBehaviour
{
    public Dropdown dropdownMaterial;
    public List<string> materials = new List<string>();

    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    MySqlCommand command;
    MySqlConnection connection = new MySqlConnection(db_connection);
    MySqlDataReader read;

    public int dropdownValue;
    public string message;

    private void Start()
    {
        materialDropdown();
    }

    public void materialDropdown()
    {
        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "SELECT distinct Material from cTeamTeamProjectDatabase.Product;";
            command = new MySqlCommand(query, connection);

            read = command.ExecuteReader();

            while (read.Read())
            {
                materials.Insert(dropdownValue, read.GetString("Material"));
            }
            dropdownMaterial = GetComponent<Dropdown>();
            dropdownMaterial.ClearOptions();
            dropdownMaterial.AddOptions(materials);
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }

    void Update()
    {
        dropdownValue = dropdownMaterial.value;
        message = dropdownMaterial.options[dropdownValue].text;
        FilteringResults.materialSelected = message;
    }
}
