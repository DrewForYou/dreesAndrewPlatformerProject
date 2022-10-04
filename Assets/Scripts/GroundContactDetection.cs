using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundContactDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public SylviaBehaviour Sylvia;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Platform")
        {
            if(Sylvia.AirJumpsLeft != 2)
            {
                Sylvia.AirJumpsLeft = 2;
                Debug.Log("Jumps Reset");
            }
            
            if(Sylvia.IsInAir)
            {
                Sylvia.IsInAir = false;
                Debug.Log("On Ground");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Platform")
        {
            if (Sylvia.IsInAir == false)
            {
                Sylvia.IsInAir = true;
                Debug.Log("In Air");
            }
        }
    }
}
