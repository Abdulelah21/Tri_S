using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class DoorButton : MonoBehaviour
{

    public Animator door;
    public GameObject buttonText;
    public GameObject button;

    public AudioSource doorSound;
    public AudioSource wrong;
    public AudioSource correct;



    public bool inReach;

    bool checkingIfFinished = true;
    private bool allowdToTrigger = true;
    public float waitTime = 5.0f;
    private float waitAfterPress = 0.0f;

    public MyKeypad d1;
    public MyKeypad2 d2;
    public MyKeypad3 d3;
    public MyKeypad4 d4;


    public SettingColors changeKeypadColorsWhenPress;



    // Start is called before the first frame update
    void Start()
    {
        inReach = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (allowdToTrigger)
        {
            if (other.gameObject.tag == "Reach" && checkingIfFinished)
            {

                inReach = true;
                buttonText.SetActive(true);
                if (door.GetBool("OpenDoor"))
                {
                    Debug.Log("TEst");
                    buttonText.SetActive(false);
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    GetComponent<OpenKeyPad>().enabled = false;

                }

            }
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (!enabled)
            return;

        if (other.gameObject.tag == "Reach" || !checkingIfFinished)
        {
            inReach = false;
            buttonText.SetActive(false);

        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach && Time.time > waitAfterPress)
        {
            StartCoroutine(WaitButtonWhenPressed());
            changeKeypadColorsWhenPress.ChangeColor();
            d1.Execute();
            d2.Execute2();
            d3.Execute3();
            d4.Execute4();

            if (d1.CheckDoorOpens() && d2.CheckDoorOpens2() && d3.CheckDoorOpens3() && d4.CheckDoorOpens4())
            {
                correct.Play();
                DoorOpens();
                Debug.Log("its open");
                allowdToTrigger = false;
            }
            else
            {
                wrong.Play();
            }



            /*Debug.Log("Pressed");
            waitAfterPress = Time.time + waitTime;
            newTime = waitAfterPress + newTime;

        }
        if (newTime > Time.time)
        {
            checkingIfFinished = false;
        }
        else
        {
            checkingIfFinished = true;

        }*/

        }

        IEnumerator WaitButtonWhenPressed()
        {
            //Print the time of when the function is first called.
            Debug.Log("Started Coroutine at timestamp : " + Time.time);
            checkingIfFinished = false;

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(waitTime);


            //After we have waited 5 seconds print the time again.
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);
            checkingIfFinished = true;

        }

        void DoorOpens()
        {
            Debug.Log("Test");
            door.SetBool("OpenDoor", true);
            door.SetBool("CloseDoor", false);
            doorSound.Play();

        }
    }
}
