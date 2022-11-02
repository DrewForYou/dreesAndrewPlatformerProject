using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public GameController GC;
    // Start is called before the first frame update
    void Start()
    {
        GC = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            GC.WinScren.gameObject.SetActive(true);
            GC.GamePaused = true;
        }
    }
}
