using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemySpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform spawnPoint;
    private float timeBetweenWaves = 8f;
    private float countdown = 2f;


    public static int score = 0;
    public Text playerScore;

    int enemyWaveNumber = 2;
    public static int enemyCount;

    private GameManager gameManager;

    void Start ()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

       
    }
    
    void Update()
    {
        

        playerScore.text = "" + score;

        enemyCount = FindObjectsOfType<Enemy1>().Length;

        if (countdown <= 0f)
        {
            if(enemyCount == 0)
            {
                enemyWaveNumber++;
                StartCoroutine(SpawnWave(enemyWaveNumber));
                countdown = timeBetweenWaves;

                
            }

        }
        countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave(int enemyWaveNumber)
    {
        //waveNumber++;
       
        yield return new WaitForSeconds(4f);

        for (int i = 0; i < enemyWaveNumber; i++)
        {
            // offsetValue += Vector3.right * 2;
            SpawnEnemy();
            
        }
      

    }
    void SpawnEnemy()
    {
        float randomX = Random.Range(-18, 18);
        Vector3 offsetValue = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

        Instantiate(enemyPrefab, offsetValue, spawnPoint.rotation);
        
    }

}
