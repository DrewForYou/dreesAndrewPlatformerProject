using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        //Quit and Restrart
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
