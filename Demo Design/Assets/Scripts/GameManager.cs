using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lives = 18;
    public static bool playGame = true;

    public GameObject Player;
    public  GameObject  powerup;
    public int powerupCount;

    public  Text livesText;
    public  Text endScreen;

    public bool isGameActive;


    // Start is called before the first frame update

    public void StartGame()
    {
        isGameActive = true;
        livesText.text = "Lives:" + lives;
    }

   public void Start()
    {
        
        InvokeRepeating("SpawnPowerup", 20.0f, 20.0f);
    }

    // Update is called once per frame
    public  void Update()
    {

        GameOver();
        livesText.text = "Lives: " + lives;

        powerupCount = FindObjectsOfType<Powerup>().Length;

    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");

    }

    public void GameOver ()
    {
        if (lives == 0)
        {
            endScreen.text = "Game Over!";
            GameManager.playGame = false;
            // Destroy(Player);

        }

    }

    public void EnemyCollideOver()
    {
        endScreen.text = "Game Over!";
        GameManager.playGame = false;
    }


    public  void SpawnPowerup()
    {

        if ( powerupCount == 0)
        {
            Vector3 powerupRange = new Vector3(Random.Range(-26, 27), -10, 0);
            GameObject powerupClone = Instantiate(powerup, powerupRange, powerup.transform.rotation);   
        }

    }
}
