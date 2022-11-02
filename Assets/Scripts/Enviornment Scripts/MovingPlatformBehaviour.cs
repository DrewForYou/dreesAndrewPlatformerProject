using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{
    public GameController GameControl;
    public Transform LeftBoundry;
    public Transform RightBoundry;
    public SylviaBehaviour Sylvia;
    
    public float PlatformSpeed;


    // Start is called before the first frame update
    void Start()
    {
        Sylvia = FindObjectOfType<SylviaBehaviour>();
        GameControl = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControl.GamePaused)
        {
            //Movement code
            Vector2 movePos = gameObject.transform.position;
            movePos.x -= PlatformSpeed * Time.deltaTime;
            //Setting Boundries
            movePos.x = Mathf.Clamp(movePos.x, LeftBoundry.position.x, RightBoundry.position.x);

            //Switches direction when they reach the boundry
            if (movePos.x == LeftBoundry.position.x || movePos.x == RightBoundry.position.x)
            {
                PlatformSpeed *= -1;
            }
            gameObject.transform.position = movePos;
        }
    }
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Sylvia.gameObject.transform.SetParent(gameObject.transform, true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Sylvia.gameObject.transform.SetParent(gameObject.transform, false);
            Debug.Log("Move");
        }
    }*/
}
