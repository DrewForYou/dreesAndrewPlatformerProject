using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    public SylviaBehaviour Sylvia;

    private void Start()
    {
        Sylvia = FindObjectOfType<SylviaBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
