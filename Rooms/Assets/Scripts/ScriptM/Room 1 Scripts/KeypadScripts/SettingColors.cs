using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingColors : MonoBehaviour
{

    public GameObject keypadObject1;
    public GameObject keypadObject2;
    public GameObject keypadObject3;
    public GameObject keypadObject4;

    public Renderer keypadRenderer1;
    public Renderer keypadRenderer2;
    public Renderer keypadRenderer3;
    public Renderer keypadRenderer4;

    public MyKeypad d1Script;
    public MyKeypad2 d2Script;
    public MyKeypad3 d3Script;
    public MyKeypad4 d4Script;


    [SerializeField] private Color newColor;

    // Start is called before the first frame update
    void Start()
    {

        keypadRenderer1 = keypadObject1.GetComponent<Renderer>();
        keypadRenderer2 = keypadObject2.GetComponent<Renderer>();
        keypadRenderer3 = keypadObject3.GetComponent<Renderer>();
        keypadRenderer4 = keypadObject4.GetComponent<Renderer>();

    }
    public void ChangeColor()
    {
        //Change Color 1st Keypad
        if (d1Script.SendIfWrongOrRight1() == 1)
        {
            keypadRenderer1.material.color = Color.green;
           /* Debug.Log("Paint Green");*/
        }
        else
        {
            keypadRenderer1.material.color = Color.red;
            /*Debug.Log("Paint Red");*/
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////


        //Change Color 2nd Keypad
        if (d2Script.SendIfWrongOrRight2() == 1)
        {
            keypadRenderer2.material.color = Color.green;
            Debug.Log("Paint Green");
        }
        else
        {
            keypadRenderer2.material.color = Color.red;
            Debug.Log("Paint Red");
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////////



        //Change Color 3rdKeypad
        if (d3Script.SendIfWrongOrRight3() == 1)
        {
            keypadRenderer3.material.color = Color.green;
            Debug.Log("Paint Green");
        }
        else
        {
            keypadRenderer3.material.color = Color.red;
            Debug.Log("Paint Red");
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////



        //Change Color 3rdKeypad
        if (d4Script.SendIfWrongOrRight4() == 1)
        {
            keypadRenderer4.material.color = Color.green;
            Debug.Log("Paint Green");
        }
        else
        {
            keypadRenderer4.material.color = Color.red;
            Debug.Log("Paint Red");
        }
    }
}
