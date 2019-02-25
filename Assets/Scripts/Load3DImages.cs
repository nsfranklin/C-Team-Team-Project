using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class Load3DImages : MonoBehaviour
{
    //public Transform tr;
    public GameObject cube;

    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    MySqlCommand command;
    MySqlConnection connection = new MySqlConnection(db_connection);
    MySqlDataReader read;

    public void test()
    {
        Mesh holderMesh = new Mesh();
        FastObjImporter newMesh = new FastObjImporter();
        holderMesh = newMesh.ImportFile("C:/Users/cvpa2/Desktop/ng/output.obj");

        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = holderMesh;
    }

    public void load3Dimage()
    {
        try
        {
            connection.Open();
            print("Connection opened! ");

            string query = "select ModelString from cTeamTeamProjectDatabase.Model where ModelID=1;";
            command = new MySqlCommand(query, connection);
            read = command.ExecuteReader();

            while (read.Read())
             {
              

             }
        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
        print("Connection closed! ");
    }


}
