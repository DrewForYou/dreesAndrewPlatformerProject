using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //public bool CheckForShadowmorph;
    public SylviaBehaviour Sylvia;

    private void Start()
    {
        Sylvia = FindObjectOfType<SylviaBehaviour>();
    }

    private void Update()
    {
        if (Sylvia.IsShadowMorphed)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Sylvia.GetComponent<Collider2D>());
        }
        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Sylvia.GetComponent<Collider2D>(), false);
        }
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
        if (Sylvia.IsShadowMorphed)
        {
            Sylvia.Hurt();
        }
    }

}
