using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isMuted;

    public void PlayGame ()
    {
        GameManager.score = 0;
        GameManager.lives = 20;
        SceneManager.LoadScene("Level");
    }
    public void QuitGame()
    {
        Debug.Log("qutting");
        Application.Quit();
    }


    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
