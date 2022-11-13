using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventClip : MonoBehaviour
{
    public bool CanDemorph;

    private void Start()
    {
        CanDemorph = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "sign")
        {
            CanDemorph = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanDemorph = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag != "sign")
        {
            if (CanDemorph)
            {
                CanDemorph = false;
            }
        }
        
    }
}
