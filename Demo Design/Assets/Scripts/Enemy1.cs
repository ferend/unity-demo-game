using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;


public class Enemy1 : MonoBehaviour
{
    
    private Rigidbody2D rigidBody;
    public float speed = 0.5f;
    public float timer = 0;
    public float timeToMove = 0.8f;
    public float timeToMoveLeft = 0.7f;
    public float numOfMovement = 0f;

    public GameObject enemy;
    public GameObject enemyProjectile;
    private GameObject enemyProjectileClone;

    public GameManager GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent < GameManager>();

    }

    void Update ()
    {

        EnemyMovement();
        EnemyProjectile();
       
    }

    void EnemyMovement ()
    {
        if (GameManager.playGame)
        {
            
                // move sideways 
                timer += Time.deltaTime;
                if (timer > timeToMove)
                {
                    transform.Translate(new Vector3(0.4f, 0, 0));
                    timer = 0;
                }
                 if (timer > timeToMoveLeft)
                 {
                      transform.Translate(new Vector3(-0.4f, 0, 0));
                      timer = 0;
                 }

            // mMove down after 14 movements to direction
            if (numOfMovement == 4)
                {
                    transform.Translate(new Vector3(0, 0.5f, 0));
                    numOfMovement = 0;
                    speed = -speed;
                }
          
        }

    }
    void EnemyProjectile ()
    {
        if (Random.Range (0f, 500f) < 1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 2.0f, 0), enemy.transform.rotation) as GameObject;
        }
        if (GameManager.playGame == false)
        {
            Object.Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // For now if collide with wall destroy it 
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(enemy);
        }

        if (collision.gameObject.tag == "Platform")
        {
            
            // add the minus score effect here. If collided with platform minus the score
            Destroy(enemy);
        }
        if (collision.gameObject.tag == "Homeship")
        {
            GameManager.EnemyCollideOver();
            
            
        }
    }
}