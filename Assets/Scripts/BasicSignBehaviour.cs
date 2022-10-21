using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSignBehaviour : MonoBehaviour
{
    public List<string> SignText = new List<string>();
    private int currentLine = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(currentLine == SignText.Count)
            {
                currentLine = 0;
                gameObject.SetActive(false);
            }
            Debug.Log(SignText[currentLine]);
            currentLine++;
            
        }
    }
}
