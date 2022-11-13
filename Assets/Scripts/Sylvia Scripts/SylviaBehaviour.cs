using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SylviaBehaviour : MonoBehaviour
{
    //Ignore the inconsistency with Shadowmorph being spelled ShadowMorph, I'm aware
    public bool IsDiving;
    public bool IsShadowMorphed;
    public bool IsGliding;

    //Used to make sure jumps use the same force in respects to Gravity
    //private float currentGravity;

    //TEST: Alternative for Gravity Scales
    //These amounts multiple the rate at which Sylvia is falling
    public float GlideFallRate;
    public float FallRate;
    public float DiveFallRate;

    //Different fall speed limits for Syvlia
    public float GlideSpeedLimit;
    public float FallSpeedLimit;
    public float DiveSpeedLimit;

    //Gravity Scales for Normal, Glide, Dive. I feel like this was what I was mean to do for the fall speed limits
    /*
    public float GlideGravity;
    public float NormalGravity;
    public float DiveGravity;
    */

    public float SylviaSpeed;
    public bool IsInAir;
    public int AirJumpsLeft;
    public float GroundJumpForce;
    public float AirJumpForce;
    public bool IsInvincible;

    public Vector2 HoldVelocity;
    public bool PausedOrUnpaused;
    public float GrabGravity;

    public GameController GC;
    //public ShadowMorphBehaviour SMB;
    public GroundContactDetection GCD;
    public PreventClip Prevent;

    // Start is called before the first frame update
    void Start()
    {
        IsDiving = false;
        IsShadowMorphed = false;
        IsGliding = false;
        IsInvincible = false;
        IsInAir = false;
        AirJumpsLeft = 2;
        GC = FindObjectOfType<GameController>();
        GrabGravity = GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GC.GamePaused)
        {
            //holds current velocity for each function
            Vector2 hold = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * SylviaSpeed, hold.y);

            //Shadowmorph Code
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(IsShadowMorphed && Prevent.CanDemorph)
                {
                    IsShadowMorphed = !IsShadowMorphed;
                }
                else if (IsShadowMorphed && !Prevent.CanDemorph)
                {

                }
                else
                {
                    IsShadowMorphed = !IsShadowMorphed;
                }
            }

            //makes sure Sylvia is not shadowmorphed in the air.
            if (IsInAir && IsShadowMorphed)
            {
                IsShadowMorphed = false;
            }

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
                IsGliding = true;
                //Gliding and Diving Cancel eachother out
                IsDiving = false;

                //Setting gravity
                //GetComponent<Rigidbody2D>().gravityScale = GlideGravity;
                //Debug.Log("Glide");
            }

            //When Glide Is Released
            if (Input.GetKeyUp(KeyCode.Space) || IsInAir == false)
            {
                IsGliding = false;
                //Reseting Gravity
                //GetComponent<Rigidbody2D>().gravityScale = NormalGravity;
            }


            //Diving Code

            //When Diving Is Pressed
            if (Input.GetKeyDown(KeyCode.S) && IsInAir)
            {
                IsDiving = true;
                //Gliding and Diving Cancel eachother out
                IsGliding = false;

                //Setting Gravity
                //GetComponent<Rigidbody2D>().gravityScale = DiveGravity;
                //Debug.Log("Dive");
            }

            //When Diving Is Released
            if (Input.GetKeyUp(KeyCode.S) || IsInAir == false)
            {
                IsDiving = false;
                //Reseting Gravity
                //GetComponent<Rigidbody2D>().gravityScale = NormalGravity;
            }


            //Fall Speed Limit Code
            //Eventually I'd like to make the Gravity Change only happen when Y is Negatvie

            //Glide Speed
            if (IsGliding)
            {

                hold = GetComponent<Rigidbody2D>().velocity;

                //Setting Gravity Change to Only Occur when it has a negative Y
                if (hold.y < 0)
                {
                    hold.y = hold.y * GlideFallRate;
                    //GetComponent<Rigidbody2D>().gravityScale = GlideGravity;
                }
                /*
                //Makes sure to change gravity back to normal if not already set to normal
                else if(GetComponent<Rigidbody2D>().gravityScale != NormalGravity)
                {
                    GetComponent<Rigidbody2D>().gravityScale = NormalGravity;
                }
                */
                //the Mathf.clamp limites the minimum fall speed to the GlideSpeedLimit, and sets the maximum to the sum of
                //AirJumpForce and GroundJumpForce to make sure it will always be high enough to not interfere with jumping velocity
                GetComponent<Rigidbody2D>().velocity = new Vector2(hold.x, Mathf.Clamp(hold.y, GlideSpeedLimit, AirJumpForce + GroundJumpForce));
            }

            //Dive Speed
            else if (IsDiving)
            {
                hold = GetComponent<Rigidbody2D>().velocity;

                //Setting Gravity Change to Only Occur when it has a negative Y
                if (hold.y < 0)
                {
                    hold.y = hold.y * DiveFallRate;
                    //GetComponent<Rigidbody2D>().gravityScale = DiveGravity;
                }
                /*
                //Makes sure to change gravity back to normal if not already set to normal
                else if (GetComponent<Rigidbody2D>().gravityScale != NormalGravity)
                {
                    GetComponent<Rigidbody2D>().gravityScale = NormalGravity;
                }
                */

                //the Mathf.clamp limites the minimum fall speed to the DiveSpeedLimit, /*and sets max to 0 to speed up fall*/
                GetComponent<Rigidbody2D>().velocity = new Vector2(hold.x, Mathf.Clamp(hold.y, DiveSpeedLimit, 0.0f));
            }

            //Normal Fall Speed
            else
            {

                hold = GetComponent<Rigidbody2D>().velocity;
                /*
                //Makes sure to change gravity back to normal if not already set to normal
                if (GetComponent<Rigidbody2D>().gravityScale != NormalGravity)
                {
                    GetComponent<Rigidbody2D>().gravityScale = NormalGravity;
                }
                */
                if (hold.y < 0)
                {
                    hold.y = hold.y * FallRate;
                }
                //the Mathf.clamp limites the minimum fall speed to the FallSpeedLimit, and sets the maximum to the sum of
                //AirJumpForce and GroundJumpForce to make sure it will always be high enough to not interfere with jumping velocity
                GetComponent<Rigidbody2D>().velocity = new Vector2(hold.x, Mathf.Clamp(hold.y, FallSpeedLimit, AirJumpForce + GroundJumpForce));
            }

            //Shadowmorph Code
            if (IsShadowMorphed != GetComponent<Animator>().GetBool("ShadowmorphActive"))
            {
                //Have tags changes and go back to animation to see if you can have somethingTrigger when that animation ends
                //So that it works. ALso see about tag things...Tired go to bed.
                GetComponent<Animator>().SetBool("ShadowmorphActive", IsShadowMorphed);
                /*if (IsShadowMorphed)
                {

                    
                    int ShadowmorphLayer = LayerMask.NameToLayer("ShadowMorph");
                    gameObject.layer = ShadowmorphLayer;
                    
                }
                else
                {
                    
                    int SylivaLayer = LayerMask.NameToLayer("Sylvia");
                    gameObject.layer = SylivaLayer;
                    
                } */
                //SylviaShadowmorphTransitions();
            }

            /*if (IsShadowMorphed == false && !Prevent.CanDemorph)
            {
                IsShadowMorphed = true;
            }*/
        }
        /*else
        {
            if(PausedOrUnpaused)
            {

            }
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.transform.tag);

        if(collision.transform.tag == "Enemy" && !IsInvincible)
        {
            Hurt();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(IsInvincible)
        {
            GetComponent<Animator>().SetBool("SylivaHurt", false);
            //IsInvincible = false;
        }
    }

    //Damage Update Code
    public void Hurt()
    {
        GC.UpdateHealth();
        GetComponent<Animator>().SetBool("SylivaHurt", true);
        Debug.Log("Ouch");
        //IsInvincible = true;
    }

    //Holds onto Sylvia's velocity when the game is paused
    public void HoldOntoVelocity()
    {
        HoldVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        
    }

    //Sets Sylvia to the velocity she had before the game was paused
    public void ReturnToVelocity()
    {
        GetComponent<Rigidbody2D>().gravityScale = GrabGravity;
        GetComponent<Rigidbody2D>().velocity = new Vector2(HoldVelocity.x, HoldVelocity.y);
    }

    //Code for SylviaToShadowmorph and ShadowmorphToSylvia Animations
    /*private void SylviaShadowmorphTransitions()
    {
        if(GetComponent<Animator>().GetBool("ShadowmorphActive"))
        { 

        }

    }*/

}
