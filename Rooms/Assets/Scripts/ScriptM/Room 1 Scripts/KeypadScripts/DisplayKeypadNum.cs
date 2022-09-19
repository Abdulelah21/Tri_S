using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayKeypadNum : MonoBehaviour
{
    public Text userInputText;
    public Text userInputText2;
    public Text userInputText3;
    public Text userInputText4;



    public MyKeypad d1;
    public MyKeypad2 d2;
    public MyKeypad3 d3;
    public MyKeypad4 d4;




    void Update()
    {
        userInputText.text = d1.textOB.text;
        userInputText2.text = d2.textOB2.text;
        userInputText3.text = d3.textOB3.text;
        userInputText4.text = d4.textOB4.text;


    }
}
