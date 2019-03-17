using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class FetchSizesFromDb : MonoBehaviour
{
        public  static Dropdown dropdownSizes;
        public static List<string> sizeValues = new List<string>();
        public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
        static MySqlCommand command;
        static MySqlConnection connection = new MySqlConnection(db_connection);
        static MySqlDataReader read;

    public int dropdownValue;
    public string message;

    // Start is called before the first frame update
    void Start()
    {
        sizeDropdown();
    }

    public static void sizeDropdown()
    {
        int index = 0;

        try
        {
            connection.Open();
            print("Connection  iiiissss opppeeeeeeennnnn  opened! ");
            
            string query = "SELECT distinct Size from cTeamTeamProjectDatabase.Product order by size asc;";
            command = new MySqlCommand(query, connection);

            read = command.ExecuteReader();

            while (read.Read())
            {
                sizeValues.Insert(index, read.GetString("Size"));
                //index++;
                
            }
           // dropdownSizes = GetComponent<Dropdown>();
            dropdownSizes.ClearOptions();
            dropdownSizes.AddOptions(sizeValues);

            FilteringResults.sizeSelected = sizeValues[index];
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
            print("QA KARI KI TA QIFSHA PIDHIN E NANES!! ");
        }

        connection.Close();
        print(" It is coming in this method! ");
    }

   /* void Update()
    {
        dropdownValue = dropdownSizes.value;
        message = dropdownSizes.options[dropdownValue].text;
        FilteringResults.sizeSelected = message;
    }*/
}
