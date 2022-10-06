using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfInRange : MonoBehaviour
{

    public bool inRange;
    public GameObject enemy;

    public void Awake()
    {
          inRange = false;

}

public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.GetComponent<BoxCollider>().size = new Vector3(40.0f, 1.0f, 40.0f);

            inRange = true;

            
        }
    }

    public void OnTriggerExit(Collider other)
    {
         
        if (other.tag == "Player")
        {

            inRange = false;



        }
        enemy.GetComponent<BoxCollider>().size = new Vector3(13.0f, 1.0f, 13.0f);

    }


    public bool GetPlayerIfIn()
    {
        return inRange;
    }



}
