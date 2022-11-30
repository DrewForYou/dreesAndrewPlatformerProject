using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneText : MonoBehaviour
{
    public GameController TextGrab;
    public HiddenInteractableCode Interact;
    public GameObject DestroyParent;
    public List<string> SignText = new List<string>();
    private int currentLine = 0;
    

    private void Start()
    {
        TextGrab = FindObjectOfType<GameController>();
        gameObject.SetActive(false);
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
                //Turns off sign
                Destroy(DestroyParent);
            }
            else
            {
                //Show the string for the current line in the list
                TextGrab.UpdateText(SignText[currentLine]);
                //Showing the continue button for now, may or may not impliment in the final.
                //Debug.Log("Press Enter To Continue");
                //Goes to next line
                currentLine++;
            }

        }
    }
}
