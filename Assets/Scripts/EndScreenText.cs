using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenText : MonoBehaviour
{
    public GameController TextGrab;
    public EndInteraction Interact;
    //public EndGoal EnableEnd;
    public bool CrystalisTalking;
    public GameObject BackBox;
    public TMP_Text BackBoxText;
    public GameObject EndBox;
    public TMP_Text EndBoxText;
    public List<string> SignText = new List<string>();
    public List<bool> SwapSpeaker = new List<bool>();
    private int currentLine = 0;


    private void Start()
    { 
        //TextGrab = FindObjectOfType<GameController>();
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        Debug.Log("Go");
    }

    private void Update()
    {
        //Show first line when interacted with
        if (currentLine == 0)
        {
            //Enable TextBox
            TextGrab.ShowTextBox();
            //Show the string for the current line in the list
            TextGrab.UpdateText(SignText[currentLine]);
            //Goes to next line
            currentLine++;
        }
        //Moves to next line in the list when enter is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //if there is no longer a next line exit
            if (currentLine >= SignText.Count)
            {
                //Resets list to first line
                currentLine = 0;
                //Hide text box UI (TBI)
                TextGrab.HideTextBox();
                //EnableEnd.GetComponent<EndGoal>().enabled = true;
                TextGrab.WinScren.gameObject.SetActive(true);
                TextGrab.GamePaused = true;
                Destroy(this);
            }
            else
            {
                //Show the string for the current line in the list
                if(SwapSpeaker[currentLine] != CrystalisTalking)
                {
                    SwapTextBox();
                }
                TextGrab.UpdateText(SignText[currentLine]);
                //Showing the continue button for now, may or may not impliment in the final.
                //Debug.Log("Press Enter To Continue");
                //Goes to next line
                currentLine++;
            }

        }
    }

    public void SwapTextBox()
    {
        if(CrystalisTalking)
        {
            TextGrab.HideTextBox();
            TextGrab.TextBox = BackBox;
            TextGrab.TextBoxText = BackBoxText;
            TextGrab.ShowTextBox();
            CrystalisTalking = false;
        }
        else
        {
            TextGrab.HideTextBox();
            TextGrab.TextBox = EndBox;
            TextGrab.TextBoxText = EndBoxText;
            TextGrab.ShowTextBox();
            CrystalisTalking = true;
        }
    }
}