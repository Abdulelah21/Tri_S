using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreaseButton4 : MonoBehaviour
{
    public GameObject keypadOBButton;
    public GameObject keypadTextButton;
    public Animator door;
    [SerializeField] TextMeshProUGUI keypadText;
    public AudioSource pressButton;

    int keypadInput;
    public bool inReach;
    int passingText;




    void Start()
    {
        keypadInput = 0;
        inReach = false;
        keypadText.text = keypadInput + "";
        passingText = 0;

    }




    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Reach")
        {

            inReach = true;
            keypadTextButton.SetActive(true);
            if (door.GetBool("OpenDoor"))
            {
                Debug.Log("TEst");
                keypadTextButton.SetActive(false);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                /*                GetComponent<OpenKeyPad>().enabled = false;
                */
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
            keypadTextButton.SetActive(false);

        }
    }

    public void PassingKeypadInput4(int textInput)
    {
        keypadInput = textInput - 1;
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {

            FindObjectOfType<DecreaseButton4>().PassingKeypadInputTwo4(passingText);

            if (keypadInput >= 0 && keypadInput <= 24)
            {
                keypadInput++;
                passingText = keypadInput;
                keypadText.text = keypadInput + "";
                pressButton.Play();

            }
            if (keypadInput >= 25)
            {
                keypadInput = 0;
                passingText = keypadInput;
                keypadText.text = keypadInput + "";

            }

            keypadOBButton.SetActive(true);
        }


    }
    public int SetKeypadInput4()
    {
        return keypadInput;
    }

}

