using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPlatformBehaviour : MonoBehaviour
{
    public SylviaBehaviour Sylvia;

    private void Start()
    {
        Sylvia = FindObjectOfType<SylviaBehaviour>();
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Sylvia.GetComponent<Collider2D>());
    }

    private void Update()
    {
        //Checks if Sylvia is shadowmorphed and turns off collision when Sylvia is Shadowmoprhed true and on when she is not
        
        if (Sylvia.IsShadowMorphed)
        {
            GetComponent<Animator>().SetBool("IsShadowmorphed", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsShadowmorphed", false);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Use to eject player from object if they get stuck in it.
    }
}
