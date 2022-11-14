using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundContactDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public SylviaBehaviour Sylvia;
    public bool IsOnShadowPlatform;
    public bool IsOnPlatform;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Platform" || collision.transform.tag == "ShadowGlass")
        {
            //Checks to see if on a ShadowPlatform
            if(collision.transform.tag == "ShadowGlass" && !Sylvia.IsDiving)
            {
                IsOnShadowPlatform = true;
            }

            if(collision.transform.tag == "Platform")
            {
                IsOnPlatform = true;
            }

            //Resets Air Jumps
            if (Sylvia.AirJumpsLeft != 2)
            {
                Sylvia.AirJumpsLeft = 2;
                //Debug.Log("Jumps Reset");
            }
            
            //turns off IsInAir 
            if(Sylvia.IsInAir)
            {
                //Checks to see if Sylvia was diving before the collision
                if (Sylvia.IsDiving /*&& collision.transform.tag != "ShadowGlass"*/)
                {
                    if(collision.transform.tag != "ShadowGlass")
                    {
                        Sylvia.IsInAir = false;
                        Sylvia.IsShadowMorphed = true;
                    }
                    //Debug.Log("Dived to Ground");
                }
                else
                {
                    Sylvia.IsInAir = false;
                    //Debug.Log("On Ground");
                }
            }

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "ShadowGlass")
        {
            IsOnShadowPlatform = false;
            
            if (Sylvia.IsInAir == false && !IsOnPlatform)
            {
                Sylvia.IsInAir = true;
                //Debug.Log("In Air");
            }
        }
        else if(collision.transform.tag == "Platform")
        {
            IsOnPlatform = false;

            if (Sylvia.IsInAir == false && !IsOnShadowPlatform)
            {
                Sylvia.IsInAir = true;
                //Debug.Log("In Air");
            }
        }
    }
}
