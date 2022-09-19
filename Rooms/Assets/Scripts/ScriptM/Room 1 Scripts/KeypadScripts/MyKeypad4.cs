using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MyKeypad4 : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB4;
    public GameObject hud;
    /*    public GameObject inv;
    */

    public GameObject animateOB;
    public Animator door;

    int returner4;

    public Text textOB4;

    public Text display4;


    string answer4 = "4";



    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;
    public AudioSource doorSound;


    public bool animate;

    int d4;

    void Start()
    {
        d4 = 0;
        keypadOB4.SetActive(false);

        textOB4.text = d4.ToString();
    }


    public void Number4(int number4)
    {
        if (display4.text == "Wrong")
        {
            Clear4();
        }


        textOB4.text = number4.ToString();
        returner4 = number4;
        button.Play();
    }

    public int RNumber4()
    {
        return returner4;
    }


    public void IncreaseDigitsNumAnddisplay4()
    {

        if (d4 >= 0 && d4 <= 24)
        {
            d4++;
            Number4(d4);
        }
        if (d4 >= 25)
        {
            d4 = 0;
            Number4(d4);

        }

    }

    public void DecreaseDigitsNumAnddisplay4()
    {

        if (d4 >= 0 && d4 <= 24)
        {
            d4--;
            if (d4 == -1)
            {
                d4 = 24;
            }
            Number4(d4);
        }

    }

    public int SendIfWrongOrRight4() // this method for changing keypad color by sending 1 or 0 to SettingColors Script
    {
        if (textOB4.text == answer4)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void Execute4()
    {

        Debug.Log(textOB4.text + "    " + answer4);


        if (textOB4.text == answer4)
        {


            display4.color = Color.green;

            display4.text = "Right";



        }
        else
        {
            display4.text = "Wrong";


        }

    }








    public void Clear4()
    {
        {
            textOB4.text = "";
            display4.text = "";
            button.Play();
        }
    }



    public void Exit()
    {
        keypadOB4.SetActive(false);
        //  inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    public void Update()
    {

        if (keypadOB4.activeInHierarchy)
        {
            hud.SetActive(false);
            //   inv.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    public bool CheckDoorOpens4()
    {
        if (display4.text == "Right" && animate)
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
