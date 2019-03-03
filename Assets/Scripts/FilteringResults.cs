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
    public static string sizeSelected;
    public static string materialSelected;
    public static string colourSelected;

    public Text theText;

    public void test()
    {
        theText.text = "Filters: "+sizeSelected + " - " + materialSelected + " - " + colourSelected;
    }
}
