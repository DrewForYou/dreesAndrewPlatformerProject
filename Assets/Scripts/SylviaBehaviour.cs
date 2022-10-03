using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SylviaBehaviour : MonoBehaviour
{
    private bool isDiving;
    private bool isShadowMorphed;
    private bool isInAir;
    public int AirJumpsLeft;
    public float GroundJumpForce;
    public float AirJumpForce;

    public GroundContactDetection GCD;
    
    // Start is called before the first frame update
    void Start()
    {
        isDiving = false;
        isShadowMorphed = false;
        isInAir = false;
        AirJumpsLeft = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2
    }

    public void ResetAirJumps()
    {
        AirJumpsLeft = 2;
    }

}
