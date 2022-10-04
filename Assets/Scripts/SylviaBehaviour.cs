using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SylviaBehaviour : MonoBehaviour
{
    private bool isDiving;
    private bool isShadowMorphed;
    
    public float FallSpeedLimit;
    public float DiveSpeedLimit;
    public float SylviaSpeed;
    public bool IsInAir;
    public int AirJumpsLeft;
    public float GroundJumpForce;
    public float AirJumpForce;

    public GroundContactDetection GCD;
    
    // Start is called before the first frame update
    void Start()
    {
        isDiving = false;
        isShadowMorphed = false;
        IsInAir = false;
        AirJumpsLeft = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //holds current velocity for each function
        Vector2 hold = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * SylviaSpeed,  hold.y);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hold = GetComponent<Rigidbody2D>().velocity;
            if (IsInAir == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(hold.x, GroundJumpForce);
            }

            else if (IsInAir == true && AirJumpsLeft != 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(hold.x, AirJumpForce);
                AirJumpsLeft -= 1;
            }
        }

        if(isDiving == false)
        {
            hold = GetComponent<Rigidbody2D>().velocity;

            //the Mathf.clamp limites the minimum fall speed to the fall speed limit, and sets the maximum to the sum of
            //AirJumpForce and GroundJumpForce to make sure it will always be high enough to not interfere with jumping velocity
            GetComponent<Rigidbody2D>().velocity = new Vector2(hold.x, Mathf.Clamp(hold.y, FallSpeedLimit, AirJumpForce + GroundJumpForce));
        }
    }

}
