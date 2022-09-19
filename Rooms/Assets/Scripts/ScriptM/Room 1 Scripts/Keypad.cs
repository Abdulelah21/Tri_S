using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypad;
    public GameObject hud; // hud system
    //public GameObject inv;  // inventory

    public GameObject animateOB;
    public Animator ANI;

    public Text textOB;
    public string answer = "07";

   /* int d1Counter ;
     int d2Counter;
     int d3Counter;
     int d4Counter;*/



    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public bool animate;

    // Start is called before the first frame update
    void Start()
    {
  /*      d1Counter = 00;
        d2Counter = 00; 
        d3Counter = 00; 
        d4Counter = 00;*/
/*        keypad.SetActive(false);
*/
    }

/*    public void IncreaseDigitsNumAndDisplay()
    {
        d1Counter++;
        Number();
    }*/

    public void Number(int number)
    {
        textOB.text += number.ToString();
        button.Play();
    }

    public void Execture()
    {
        if(textOB.text == answer)
        {
            correct.Play();
            textOB.text = "Right";
        }
        else
        {
            wrong.Play();
            textOB.text = "Wrong"; 
        }
    }

    public void Clear()
    {
        textOB.text = "";
        button.Play();
    }

    public void Exit()
    {
        keypad.SetActive(false);
        //inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(textOB.text == "Right" && animate)
        {
            ANI.SetBool("animate", true);
            Debug.Log("its open");

            if (keypad.activeInHierarchy) // if the keypad is active
            {
                //inv.SetActive(false);
                hud.SetActive(false);
                player.GetComponent<FirstPersonController>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
