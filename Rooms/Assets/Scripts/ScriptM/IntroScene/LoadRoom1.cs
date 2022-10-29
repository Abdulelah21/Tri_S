using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadRoom1 : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Room1", LoadSceneMode.Single);
    }
}

