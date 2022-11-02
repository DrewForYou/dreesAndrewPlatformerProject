using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseOrWinScreen : MonoBehaviour
{
    public int WhichScene;
    public GameController GameControl;

    private void Start()
    {
        GameControl = FindObjectOfType<GameController>();
    }

    public void WinGame()
    {
        SceneManager.LoadScene(1);
    }
    public void RetartGame()
    {
        Debug.Log("Restarted");
        SceneManager.LoadScene(WhichScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
