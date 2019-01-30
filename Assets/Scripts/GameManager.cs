using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using MySql;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    // Use this for initialization
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        string connStr = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;user=vruser;database=world;port=3306;password=9ZxgnmXHSIdYIsK5qoGm";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            // Perform database operations
        }
        catch (MySqlException ex)
        {
            Debug.Log(ex.ToString());
        }
        conn.Close();
        Debug.Log("Done.");
    
}
	
	// Update is called once per frame
	void Update () {
		
	}
}
