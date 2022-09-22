using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class ActivateKeypad : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keypadText;
    [SerializeField] TextMeshProUGUI keypadText2;
    [SerializeField] TextMeshProUGUI keypadText3;
    [SerializeField] TextMeshProUGUI keypadText4;

    public Light lt1;
    public Light lt1_2;
    public Light lt2;
    public Light lt2_2;
    public Light lt3;
    public Light lt3_2;
    public Light lt4;
    public Light lt4_2;


    bool checkingIfFinished = true;
    private bool allowdToTrigger = true;
    public float waitTime = 5.0f;
    private float waitAfterPress = 0.0f;


    /*    public IncreaseButton keypad1_1;
        public DecreaseButton keypad1_2;*/
    int keypadAnswer = 13;
    int answerOne;
    int answerOne_2;
/*    public IncreaseButton2 keypad2_1;
    public DecreaseButton2 keypad2_2;*/
    int keypadAnswer2 = 7;
    int answerTwo;
    int answerTwo_2;

    /*
        public IncreaseButton3 keypad3_1;
        public DecreaseButton3 keypad3_2;*/
    int keypadAnswer3 = 20;
    int answerThree;
    int answerThree_2;


    /*    public IncreaseButton4 keypad4_1;
        public DecreaseButton4 keypad4_2;*/
    int keypadAnswer4 = 11;
    int answerFour;
    int answerFour_2;


    public GameObject activeOBButton;
    public bool inReach;

    public Animator door;
    public Animator button;


    public AudioSource correct;
    public AudioSource wrong;


    // Start is called before the first frame update
    void Start()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (allowdToTrigger)
        {
            if (other.gameObject.tag == "Reach" && checkingIfFinished)
            {

                inReach = true;



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

        }
    }



    void Update()
    {
        answerOne = FindObjectOfType<IncreaseButton>().SetKeyInput();
        answerOne_2 = FindObjectOfType<DecreaseButton>().SetKeypadInput_2();

        answerTwo = FindObjectOfType<IncreaseButton2>().SetKeypadInput2();
        answerTwo_2 = FindObjectOfType<DecreaseButton2>().SetKeypadInput2_2();

        answerThree = FindObjectOfType<IncreaseButton3>().SetKeypadInput3();
        answerThree_2 = FindObjectOfType<DecreaseButton3>().SetKeypadInput3_2();

        answerFour = FindObjectOfType<IncreaseButton4>().SetKeypadInput4();
        answerFour_2 = FindObjectOfType<DecreaseButton4>().SetKeypadInput4_2();



        if (Input.GetButtonDown("Interact") && inReach && checkingIfFinished && allowdToTrigger)
        {
            StartCoroutine(WaitButtonWhenPressed());
            if ( ( (answerOne == keypadAnswer) || (answerOne_2 == keypadAnswer)  ) && 
                ( (answerTwo == keypadAnswer2) || (answerTwo_2 == keypadAnswer2) ) &&
                ( (answerThree == keypadAnswer3) || (answerThree_2 == keypadAnswer3) ) && 
                ( (answerFour == keypadAnswer4) || (answerFour_2 == keypadAnswer4) ) ) 
            {
                DoorOpen();
                correct.Play();
                allowdToTrigger = false;
            }
            else
            {
                wrong.Play();
            }

            if ((answerOne != keypadAnswer) || (answerOne_2 != keypadAnswer))
            {
                lt1.color = Color.red;
                lt1_2.color = Color.red;
            }
            else
            {
                lt1.color = Color.green;
                lt1_2.color = Color.green;
            }

            if ((answerTwo != keypadAnswer2) || (answerTwo_2 != keypadAnswer2))
            {
                lt2.color = Color.red;
                lt2_2.color = Color.red;
            }
            else
            {
                lt2.color = Color.green;
                lt2_2.color = Color.green;
            }

            if ((answerThree != keypadAnswer3) || (answerThree_2 != keypadAnswer3))
            {
                lt3.color = Color.red;
                lt3_2.color = Color.red;
            }
            else
            {
                lt3.color = Color.green;
                lt3_2.color = Color.green;
            }

            if ((answerFour != keypadAnswer4) || (answerFour_2 != keypadAnswer4)) {
                lt4.color = Color.red;
                lt4_2.color = Color.red;
            }
            else
            {
                lt4.color = Color.green;
                lt4_2.color = Color.green;
            }

        }
        }
    IEnumerator WaitButtonWhenPressed()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        checkingIfFinished = false;
        activeOBButton.GetComponent<BoxCollider>().isTrigger = false;
        PushButton();
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitTime);

        Pullbutton();
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        checkingIfFinished = true;
        activeOBButton.GetComponent<BoxCollider>().isTrigger = true;


    }

    void PushButton()
    {
        button.SetBool("Push", true);
        button.SetBool("Pull", false);
        
    }

    void Pullbutton()
    {
        button.SetBool("Push", false);
        button.SetBool("Pull", true);
    }

    void DoorOpen()
    {
        door.SetBool("OpenDoor",true);
        door.SetBool("CloseDoor", false);

    }

    void DoorClose()
    {
        door.SetBool("OpenDoor", false);
        door.SetBool("CloseDoor", true);

    }

    public bool AnswerIsTrue()
    {
        return allowdToTrigger;
    }

}
