using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseNote : MonoBehaviour
{
    public GameObject noteOBJ;
    public GameObject noteUseText;
    [SerializeField] private TextWriter textWriter;
    private Text noteText;

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
            noteUseText.SetActive(true);

            if (textWriter.NoteIsOpen())
            {
                Debug.Log("TEst");
                noteUseText.SetActive(false);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                GetComponent<UseNote>().enabled = false;
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
            noteUseText.SetActive(false);

        }
    }



    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            noteText = transform.Find("NoteUI").Find("Note").Find("NoteText").Find("NoteBackground").Find("NoteHelp").GetComponent<Text>();
            textWriter.AddWriter(noteText, "There's something wrong with this room why there're too many clocks this is creepy ", .1f);
            noteOBJ.SetActive(true);
            noteUseText.SetActive(false);

        }


    }
}

