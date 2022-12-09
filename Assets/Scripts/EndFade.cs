using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFade : MonoBehaviour
{
    public GameObject GetObject;
    public void TurnOnText()
    {
        Debug.Log("HIya");
        GetObject.gameObject.SetActive(true);
        GetObject.gameObject.SetActive(true);
    }
}
