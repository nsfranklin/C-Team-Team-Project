using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

//THIS CLASS IS NOT IN USE.!!!!
public class DatabaseConnection : MonoBehaviour
{
    private static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    private MySqlConnection connection = new MySqlConnection(db_connection);

    public void openConnection()
    {
        connection.Open();
    }

    public void closeDatabaseConnection()
    {
        connection.Close();
    }
}
