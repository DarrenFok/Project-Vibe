using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //loads scene "1", currently "base"
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); //quits game
    }
}
