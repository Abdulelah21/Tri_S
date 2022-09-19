using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MyKeypad3 : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB3;
    public GameObject hud;
    /*    public GameObject inv;
    */

    public GameObject animateOB;
    public Animator door;

    int returner3;

    public Text textOB3;

    public Text display3;


    string answer3 = "22";



    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;
    public AudioSource doorSound;


    public bool animate;

    int d3;

    void Start()
    {
        d3 = 0;
        keypadOB3.SetActive(false);

        textOB3.text = d3.ToString();
    }


    public void Number3(int number3)
    {
        if (display3.text == "Wrong")
        {
            Clear3();
        }


        textOB3.text = number3.ToString();
        returner3 = number3;
        button.Play();
    }

    public int RNumbe3r()
    {
        return returner3;
    }


    public void IncreaseDigitsNumAnddisplay3()
    {

        if (d3 >= 0 && d3 <= 24)
        {
            d3++;
            Number3(d3);
        }
        if (d3 >= 25)
        {
            d3 = 0;
            Number3(d3);

        }

    }

    public void DecreaseDigitsNumAnddisplay3()
    {

        if (d3 >= 0 && d3 <= 24)
        {
            d3--;
            if (d3 == -1)
            {
                d3 = 24;
            }
            Number3(d3);
        }

    }

    public int SendIfWrongOrRight3() // this method for changing keypad color by sending 1 or 0 to SettingColors Script
    {
        if (textOB3.text == answer3)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void Execute3()
    {

        Debug.Log(textOB3.text + "    " + answer3);


        if (textOB3.text == answer3)
        {


            display3.color = Color.green;

            display3.text = "Right";



        }
        else
        {
            display3.text = "Wrong";


        }

    }








    public void Clear3()
    {
        {
            textOB3.text = "";
            display3.text = "";
            button.Play();
        }
    }



    public void Exit()
    {
        keypadOB3.SetActive(false);
        //  inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    public void Update()
    {

        if (keypadOB3.activeInHierarchy)
        {
            hud.SetActive(false);
            //   inv.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public bool CheckDoorOpens3()
    {
        if (display3.text == "Right" && animate)
        {
            Debug.Log("its open");

            return true;
        }
        else
        {
            return false;
        }
    }

}
