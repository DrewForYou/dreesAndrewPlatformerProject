using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGlassBehaviour : MonoBehaviour
{
    public SylviaBehaviour Sylvia;
    public bool DiveThrough;

    private void Start()
    {
        Sylvia = FindObjectOfType<SylviaBehaviour>();
    }

    private void Update()
    {
        //Checks if Sylvia is shadowmorphed and turns off collision when Sylvia is Shadowmoprhed true and on when she is not
        //note you can dive thorugh the walls even if you are standing on them.
        if (Sylvia.IsShadowMorphed)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Sylvia.GetComponent<Collider2D>());
        }
        else if(DiveThrough && Sylvia.IsDiving)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Sylvia.GetComponent<Collider2D>());
        }
        else
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Sylvia.GetComponent<Collider2D>(), false);
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Use to eject player from object if they get stuck in it.
    }
}
