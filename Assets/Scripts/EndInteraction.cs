using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndInteraction : MonoBehaviour
{
    public GameObject GetObject;
    public Canvas Fade;

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //This is for interactions that are scripted to happen. 
        Debug.Log("End");
        //Fade.gameObject.SetActive(true);
        //GetObject.gameObject.SetActive(true);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This is for interactions that are scripted to happen. 
        Debug.Log("End");
        Fade.gameObject.SetActive(true);
        //GetObject.gameObject.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //This is for interactions that are scripted to happen. 
        Debug.Log("Set");
        Fade.gameObject.SetActive(true);
        //GetObject.gameObject.SetActive(true);
    }
}
