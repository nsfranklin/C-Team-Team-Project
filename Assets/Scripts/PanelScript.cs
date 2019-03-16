using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public GameObject Panel;

    public void hidePanel()
    {
        Panel.gameObject.SetActive(false);
    }

    public void showPanel()
    {
        Panel.gameObject.SetActive(true);
    }
}
