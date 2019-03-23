using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class ButtonsControl : MonoBehaviour
{
    [SerializeField]
    //private GameObject buttonTemplate;

    public static string db_connection = "server=cteamteamprojectdatabase.csed5aholavi.eu-west-2.rds.amazonaws.com;" + "uid=vruser;" + "pwd=9ZxgnmXHSIdYIsK5qoGm;" + "database=cTeamTeamProjectDatabase;";
    MySqlCommand command;
    MySqlConnection connection = new MySqlConnection(db_connection);
    MySqlDataReader read;


    public List<GameObject> buttons;
    public int numberOfProducts;
    public SimpleObjectPool buttonObjectPool;

    public List<GameObject> GetButtonsList()
    {
        return buttons;
    }

    // Start is called before the first frame update
    void Start()
    {
        //allProducts();

        buttons = new List<GameObject>();

        if (buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }

            buttons.Clear();
        }

        // foreach (int i in intArray)    
        for (int i = 1; i <= numberOfProducts; i++)
        {
            GameObject newProductButton = new GameObject();
            //newProductButton.transform.SetParent(buttonTemplate.transform.parent, false);
            //newProductButton.SetActive(true);
            productButton productButton = gameObject.AddComponent(typeof(productButton)) as productButton;// newProductButton.GetComponent<productButton>();
            productButton.Setup(8, "Test Product", 200);
            print("in loop at " + i);
            //productButton.GetComponent<ButtonsList>().setText("Product #" + i);
            
        }

    }

    public void buttonClicked(string myTextString)
    {
        //Debug.Log(myTextString);
    }

    public void allProducts()
    {
        //List<string> listingIDlist = new List<string>();
        string temp = "";
        try
        {
            //connection.Open();
            print("Connection opened! ");

            string query = "SELECT count(*) FROM cTeamTeamProjectDatabase.Product where State='available';";
            command = new MySqlCommand(query, connection);
            read = command.ExecuteReader();

            while (read.Read())
            {
                temp = read.GetValue(0).ToString();
                
            }
            numberOfProducts = int.Parse(temp);

        }
        catch (MySqlException exception)
        {
            print("Error" + exception.ToString());
        }

        connection.Close();
    }
}

