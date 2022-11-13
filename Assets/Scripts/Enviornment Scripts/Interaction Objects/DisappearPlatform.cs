using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    //Sign that is interacted with
    public BasicSignBehaviour Sign;
    //the object to turn on
    public GameObject DeActivateMe;

    private void Update()
    {
        if (Sign.isActiveAndEnabled)
        {
            DeActivateMe.SetActive(false);
        }
    }
/*
    //Activates the object
    public void ActivateObject()
    {
        DeActivateMe.SetActive(false);
    }*/
}
