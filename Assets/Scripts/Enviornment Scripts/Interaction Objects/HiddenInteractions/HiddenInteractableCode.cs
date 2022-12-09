using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenInteractableCode : MonoBehaviour
{
    public GameObject GetObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This is for interactions that are scripted to happen. 
        //Debug.Log("End");
        GetObject.gameObject.SetActive(true);
    }
}
