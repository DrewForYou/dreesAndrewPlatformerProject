using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SylviaBehaviour : MonoBehaviour
{
    private bool isDiving;
    private bool isShadowMorphed;
    private bool isGliding;

    //Used to make sure jumps use the same force in respects to Gravity
    //private float currentGravity;

    //Different fall speed limits for Syvlia
    public float GlideSpeedLimit;
    public float FallSpeedLimit;
    public float DiveSpeedLimit;

    //Gravity Scales for Normal, Glide, Dive. I feel like this was what I was mean to do for the fall speed limits
    public float GlideGravity;
    public float NormalGravity;
    public float DiveGravity;

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

        
        if (Input.GetKeyDown(KeyCode.W))
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

        //Gliding and Diving are meant to be held down in order to allow for their code to cancel eachother out
        //Having it be press only may be able to work but I'm choosing to go this route

        //Glide Code

        //When Glide Is Pressed
        if (Input.GetKeyDown(KeyCode.Space) && IsInAir)
        {
            isGliding = true;
            //Gliding and Diving Cancel eachother out
            isDiving = false;

            //Setting gravity
            GetComponent<Rigidbody2D>().gravityScale = GlideGravity;
            Debug.Log("Glide");
        }

        //When Glide Is Released
        if (Input.GetKeyUp(KeyCode.Space) || IsInAir == false)
        {
            isGliding = false;
            //Reseting Gravity
            GetComponent<Rigidbody2D>().gravityScale = NormalGravity;
        }


        //Diving Code

        //When Diving Is Pressed
        if (Input.GetKeyDown(KeyCode.S) && IsInAir)
        {
            isDiving = true;
            //Gliding and Diving Cancel eachother out
            isGliding = false;

            //Setting Gravity
            GetComponent<Rigidbody2D>().gravityScale = DiveGravity;
            Debug.Log("Dive");
        }

        //When Diving Is Released
        if (Input.GetKeyUp(KeyCode.S) || IsInAir == false)
        {
            isDiving = false;
            //Reseting Gravity
            GetComponent<Rigidbody2D>().gravityScale = NormalGravity;
        }


        //Fall Speed Limit Code
        
        //Glide Speed
        if (isGliding)
        {
            hold = GetComponent<Rigidbody2D>().velocity;
            //the Mathf.clamp limites the minimum fall speed to the GlideSpeedLimit, and sets the maximum to the sum of
            //AirJumpForce and GroundJumpForce to make sure it will always be high enough to not interfere with jumping velocity
            GetComponent<Rigidbody2D>().velocity = new Vector2(hold.x, Mathf.Clamp(hold.y, GlideSpeedLimit, AirJumpForce + GroundJumpForce));
        }

        //Dive Speed
        else if(isDiving)
        {
            hold = GetComponent<Rigidbody2D>().velocity;
            //the Mathf.clamp limites the minimum fall speed to the DiveSpeedLimit, and sets the maximum to the sum of
            //AirJumpForce and GroundJumpForce to make sure it will always be high enough to not interfere with jumping velocity
            GetComponent<Rigidbody2D>().velocity = new Vector2(hold.x, Mathf.Clamp(hold.y, DiveSpeedLimit, AirJumpForce + GroundJumpForce));
        }

        //Normal Fall Speed
        else
        {
            hold = GetComponent<Rigidbody2D>().velocity;
            //the Mathf.clamp limites the minimum fall speed to the FallSpeedLimit, and sets the maximum to the sum of
            //AirJumpForce and GroundJumpForce to make sure it will always be high enough to not interfere with jumping velocity
            GetComponent<Rigidbody2D>().velocity = new Vector2(hold.x, Mathf.Clamp(hold.y, FallSpeedLimit, AirJumpForce + GroundJumpForce));
        }
    }

}
