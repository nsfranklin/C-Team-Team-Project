using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 20; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonsList>().setText("Product #" + i);
            button.transform.SetParent(buttonTemplate.transform.parent,false);
        }
    }
}

