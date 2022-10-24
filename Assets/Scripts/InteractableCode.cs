using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCode : MonoBehaviour
{
    public bool CanInteract;
    public GameObject GetObject;

    private void Awake()
    {
        CanInteract = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanInteract)
        {
            //Debug.Log("Interacted");
            GetObject.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Entered Interactable");
        CanInteract = true;
    }
    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Exited Interactable");
        CanInteract = false;
    }
}
