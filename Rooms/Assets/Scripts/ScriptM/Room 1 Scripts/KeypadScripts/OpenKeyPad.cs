using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyPad : MonoBehaviour
{
    public GameObject keypadOB;
    public GameObject keypadText;
    public Animator door;


    public bool inReach;




    void Start()
    {
        inReach = false;
        
    }

  


    void OnTriggerEnter(Collider other)
    {

        /* if (other.gameObject.GetComponent<MyKeypad>().enabled == false)
         {
             Debug.Log("Testing");

             return;
         }*/
   
        if (other.gameObject.tag == "Reach")
        {
         
                inReach = true;
                keypadText.SetActive(true);
            if(door.GetBool("OpenDoor"))
            {
                Debug.Log("TEst");
                keypadText.SetActive(false);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                GetComponent<OpenKeyPad>().enabled = false;
                
            }

            

        }
    }

    void OnTriggerExit(Collider other)
    {

        if (!enabled)
            return;

        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            keypadText.SetActive(false);

        }
    }



    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            keypadOB.SetActive(true);
        }
        

    }
}
