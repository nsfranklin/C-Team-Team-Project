using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsList : MonoBehaviour
{
    [SerializeField]
    private Text mytext;

   // [SerializeField]
    //private ButtonsControl buttonControl;

   // private string myTextString;

    public void setText(string textstring)
    {
      //  myTextString = textstring;
        mytext.text = textstring;
    }

    public void OnClick()
    {
        //buttonControl.buttonClicked(myTextString);
    }
}
