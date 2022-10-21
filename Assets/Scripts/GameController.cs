using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public int Hearts;
    public TMP_Text Health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth()
    {
        Hearts--;
        Health.text = "Health: " + Hearts;
        if(Hearts == 0)
        {
            //Fix for other levels
            SceneManager.LoadScene(0);
        }
    }
}
