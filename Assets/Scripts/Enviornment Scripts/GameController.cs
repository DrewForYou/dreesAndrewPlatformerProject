using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //reattch stuff to Canvas each scene
    public int Hearts;
    //public TMP_Text Health;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public TMP_Text TextBoxText;
    public GameObject TextBox;
    public GameObject LoseScreen;
    public GameObject WinScren;
    public bool GamePaused;
    public SylviaBehaviour Sylvia;
    void Start()
    {
        Sylvia = FindObjectOfType<SylviaBehaviour>();
    }

    // Update is called once per frame
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

    public void UpdateHealth()
    {
        Hearts--;
        
        //Health.text = "Health: " + Hearts;
        if(Hearts == 2)
        {
            Heart1.GetComponent<Animator>().SetBool("Heart1On", false);
        }
        else if(Hearts == 1)
        {
            Heart1.GetComponent<Animator>().SetBool("Heart1On", false);
            Heart2.GetComponent<Animator>().SetBool("Heart2On", false);
        }
        else if(Hearts == 0)
        {
            /*
            //Fix for other levels
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);*/
            Heart1.GetComponent<Animator>().SetBool("Heart1On", false);
            Heart2.GetComponent<Animator>().SetBool("Heart2On", false);
            Heart3.GetComponent<Animator>().SetBool("Heart3On", false);
            LoseScreen.gameObject.SetActive(true);
            GamePaused = true;
        }
    }

    public void ShowTextBox()
    {
        TextBox.gameObject.SetActive(true);
        Sylvia.HoldOntoVelocity();
        GamePaused = true;
    }

    //Updates text
    //ReadOrSaid was intended to italicize text read off of a sign but instead sign text has Quatiation marks around it.
    public void UpdateText(string text /*, bool ReadOrSaid*/)
    {
        TextBoxText.SetText(text);
    }

    public void HideTextBox()
    {
        TextBox.gameObject.SetActive(false);
        GamePaused = false;
        Sylvia.ReturnToVelocity();
    }
}
