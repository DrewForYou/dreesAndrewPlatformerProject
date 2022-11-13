using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatformBehaviour : MonoBehaviour
{
    public GameController GameControl;
    public Transform UpperBoundry;
    public Transform LowerBoundry;
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
            movePos.y -= PlatformSpeed * Time.deltaTime;
            //Setting Boundries
            movePos.y = Mathf.Clamp(movePos.y, LowerBoundry.position.y, UpperBoundry.position.y);

            //Switches direction when they reach the boundry
            if (movePos.y == LowerBoundry.position.y || movePos.y == UpperBoundry.position.y)
            {
                PlatformSpeed *= -1;
            }
            gameObject.transform.position = movePos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Sylvia.gameObject.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Sylvia.gameObject.transform.SetParent(null);
            Debug.Log("Move");
        }
    }
}
