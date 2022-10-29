using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMazeScene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Maz1", LoadSceneMode.Single);
    }

}
