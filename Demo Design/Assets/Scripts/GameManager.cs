using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lives = 20;
    public static int score = 0;
    public bool playGame = true;

    public GameObject Player;
    public  GameObject  powerup;
    public int powerupCount;

    public  Text livesText;
    public Text scoreText;

    public bool isGameActive;
    public GameObject gameOverPanel;


   public void Start()
    {
        InvokeRepeating("SpawnPowerup", 20.0f, 20.0f);
    }

    public void Update()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives:" + lives;
        GameOver();
        powerupCount = FindObjectsOfType<Powerup>().Length;
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver ()
    {
        if (lives == 0)
        {
            gameOverPanel.SetActive(true);
            playGame = false;
            Time.timeScale = 0f;
        }

    }

    public void EnemyCollideOver()
    {
        playGame = false;
    }


    public  void SpawnPowerup()
    {

        if ( powerupCount == 0)
        {
            Vector3 powerupRange = new Vector3(Random.Range(-26, 27), -10, 0);
            GameObject powerupClone = Instantiate(powerup, powerupRange, powerup.transform.rotation);   
        }

    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
       
    }
}
