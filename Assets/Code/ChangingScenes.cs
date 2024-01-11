using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextScene; // Name of the next scene
    public float timeToChangeScene = 5.0f; // Adjust this value to the time you want

    void Start()
    {
        Invoke("ChangeScene", timeToChangeScene);
    }

    void ChangeScene()
    {
        // Load the next scene specified in the Inspector
        SceneManager.LoadScene(nextScene);
    }
}




