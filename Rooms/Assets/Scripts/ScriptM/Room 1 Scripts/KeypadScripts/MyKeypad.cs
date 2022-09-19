using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class MyKeypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject hud;
    /*    public GameObject inv;
    */

    public GameObject animateOB;
    public Animator door;

    int returner1;

    public Text textOB;

    public Text display1;


    string answer1 = "7";
 

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;
    public AudioSource doorSound;


    public bool animate;

    int d1;

    void Start()
    {
        d1 = 0; 
        keypadOB.SetActive(false);
        
        textOB.text = d1.ToString();
    }


    public void Number(int number)
    {
        if (display1.text == "Wrong")
        {
            Clear();
        }
     

        textOB.text = number.ToString();
        returner1 = number;
        button.Play();
    }

    public int RNumber()
    {
        return returner1;
    }


    public void IncreaseDigitsNumAndDisplay()
    {

        if (d1 >= 0 && d1 <= 24)
        {
            d1++;
            Number(d1);
        }
        if (d1 >= 25)
        {
            d1 = 0;
            Number(d1);

        }

    }

    public void DecreaseDigitsNumAndDisplay()
    {

        if (d1 >= 0 && d1 <= 24)
        {
            d1--;
            if(d1 == -1)
            {
                d1 = 24;
            }
            Number(d1);
        }
    
    }

    public int SendIfWrongOrRight1() // this method for changing keypad color by sending 1 or 0 to SettingColors Script
    {
        if (textOB.text == answer1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void Execute()
    {

        Debug.Log(textOB.text + "    " + answer1);


        if (textOB.text == answer1)
        {
            

            display1.color = Color.green;

            display1.text = "Right";
         


        }
        else
        {
            display1.text = "Wrong";


        }

    }








    public void Clear()
    {
        {
            textOB.text = "";
            display1.text = "";
            button.Play();
        }
    }



    public void Exit()
    {
        keypadOB.SetActive(false);
      //  inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    public void Update()
    {
       /* if (display1.text == "Right" && animate )
        {
            DoorOpens();

            Debug.Log("its open");
            Exit();
        }*/


        if (keypadOB.activeInHierarchy)
        {
            hud.SetActive(false);
         //   inv.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

   

    public bool CheckDoorOpens()
    {
        if (display1.text == "Right" && animate)
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
