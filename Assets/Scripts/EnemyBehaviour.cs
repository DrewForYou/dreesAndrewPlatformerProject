using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //public bool CheckForShadowmorph;
    public SylviaBehaviour Sylvia;
    public Transform LeftBoundry;
    public Transform RightBoundry;
    //public Vector2 LeftLocate;
    //public Vector2 RightLocate;
    public float EnemySpeed;
    public float EnemySize;

    private void Start()
    {
        Sylvia = FindObjectOfType<SylviaBehaviour>();
        //LeftLocate = new Vector2(LeftBoundry.position.x, LeftBoundry.position.y);
        //RightLocate = new Vector2(RightBoundry.position.x, RightBoundry.position.y);
    }

    private void Update()
    {
        //Checks if Sylvia is shadowmorphed and turns off collision when Sylvia is Shadowmoprhed true and on when she is not
        if (Sylvia.IsShadowMorphed)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Sylvia.GetComponent<Collider2D>());
        }
        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Sylvia.GetComponent<Collider2D>(), false);
        }
        //Movement code
        Vector2 movePos = gameObject.transform.position;
        movePos.x -= EnemySpeed * Time.deltaTime;
        //Setting Boundries
        movePos.x = Mathf.Clamp(movePos.x, LeftBoundry.position.x, RightBoundry.position.x);

        //Switches direction when they reach the boundry
        if(movePos.x == LeftBoundry.position.x || movePos.x == RightBoundry.position.x)
        {
            EnemySpeed *= -1;
        }
        gameObject.transform.position = movePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (Sylvia.IsShadowMorphed)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Sylvia.GetComponent<Collider2D>());
        }
        else
        {
                Sylvia.Hurt();
        }
        */
        //hurts Sylvia when she is collided with
        if (collision.gameObject.GetComponent<SylviaBehaviour>())
        {
            Sylvia.Hurt();
        }
    }

}
