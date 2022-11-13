using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealPlatform : MonoBehaviour
{
    //Sign that is interacted with
    public BasicSignBehaviour Sign;
    //the object to turn on
    public GameObject ActivateMe;

    private void Update()
    {
        if(Sign.isActiveAndEnabled)
        {
            ActivateMe.SetActive(true);
        }
    }

    //Activates the object
    public void ActivateObject()
    {
        ActivateMe.SetActive(true);
    }
}
