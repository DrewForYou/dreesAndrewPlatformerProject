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
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
