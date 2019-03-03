using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsList : MonoBehaviour
{
    [SerializeField]
    private Text mytext;

    public void setText(string textstring)
    {
        mytext.text = textstring;
    }

    public void OnClick()
    {

    }
}
