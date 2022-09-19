using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;



public class MyKeypad2 : MonoBehaviour
{

    public GameObject player;
    public GameObject keypadOB2;
    public GameObject hud;
    /*    public GameObject inv;
    */

    public GameObject animateOB;
    public Animator door;

    int returner2;

    public Text textOB2;

    public Text display2;


    string answer2 = "13";



    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;
    public AudioSource doorSound;


    public bool animate;

    int d2;

    void Start()
    {
        d2 = 0;
        keypadOB2.SetActive(false);

        textOB2.text = d2.ToString();
    }


    public void Number2(int number2)
    {
        if (display2.text == "Wrong")
        {
            Clear2();
        }


        textOB2.text = number2.ToString();
        returner2 = number2;
        button.Play();
    }

    public int RNumber()
    {
        return returner2;
    }


    public void IncreaseDigitsNumAndDisplay2()
    {

        if (d2 >= 0 && d2 <= 24)
        {
            d2++;
            Number2(d2);
        }
        if (d2 >= 25)
        {
            d2 = 0;
            Number2(d2);

        }

    }

    public void DecreaseDigitsNumAndDisplay2()
    {

        if (d2 >= 0 && d2 <= 24)
        {
            d2--;
            if (d2 == -1)
            {
                d2 = 24;
            }
            Number2(d2);
        }

    }

    public int SendIfWrongOrRight2() // this method for changing keypad color by sending 1 or 0 to SettingColors Script
    {
        if (textOB2.text == answer2)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void Execute2()
    {

        Debug.Log(textOB2.text + "    " + answer2);


        if (textOB2.text == answer2)
        {


            display2.color = Color.green;

            display2.text = "Right";



        }
        else
        {
            display2.text = "Wrong";


        }

    }








    public void Clear2()
    {
        {
            textOB2.text = "";
            display2.text = "";
            button.Play();
        }
    }



    public void Exit()
    {
        keypadOB2.SetActive(false);
        //  inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    public void Update()
    {
        /* if (display2.text == "Right" && animate )
         {
             DoorOpens();

             Debug.Log("its open");
             Exit();
         }*/


        if (keypadOB2.activeInHierarchy)
        {
            hud.SetActive(false);
            //   inv.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public bool CheckDoorOpens2()
    {
        if (display2.text == "Right" && animate)
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
