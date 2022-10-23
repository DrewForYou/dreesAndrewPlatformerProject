using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSignBehaviour : MonoBehaviour
{
    public GameController TextGrab;
    public InteractableCode Interact;
    public List<string> SignText = new List<string>();
    private int currentLine = 0;

    private void Start()
    {
        TextGrab = FindObjectOfType<GameController>();
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        
    }
    private void Update()
    {
        if(currentLine == 0)
        {
            Debug.Log(SignText[currentLine]);
            currentLine++;

            if (currentLine >= SignText.Count)
            {
                currentLine = 0;
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Press Enter To Continue");
            }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(currentLine >= SignText.Count)
            {
                currentLine = 0;
                gameObject.SetActive(false);
            }
           else
            {
                Debug.Log(SignText[currentLine]);
                Debug.Log("Press Enter To Continue");
                currentLine++;
            }
                
        }
    }
}
