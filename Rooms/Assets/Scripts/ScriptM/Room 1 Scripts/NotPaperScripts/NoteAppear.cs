using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class NoteAppear : MonoBehaviour
{

    [SerializeField] private Image _noteImage;
    public bool inReach;
    [SerializeField] private GameObject fpController;

    // Start is called before the first frame update


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Reach")
        {

            inReach = true;



        }

    }

    void OnTriggerExit(Collider other)
    {

        if (!enabled)
            return;

        if (other.gameObject.tag == "Reach")
        {
            inReach = false;

        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            _noteImage.enabled = true;
            fpController.GetComponent<FirstPersonController>().enabled = false;
            
        }
         if(Input.GetButtonDown("Escapee") && inReach) { 
                _noteImage.enabled = false;
            fpController.GetComponent<FirstPersonController>().enabled = true;

        }
    }
}
