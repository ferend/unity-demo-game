using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	// Start is called before the first frame update
	
	private Rigidbody2D rigidBody;

    public GameObject EnemySpawner;
   
    public GameObject enemyProjectile;

    public float speed = 22;
    Vector3 respawn = new Vector3(0, -2, 0);
	
    void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();

		
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -10 * Time.deltaTime, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = respawn;
            
            Destroy(enemyProjectile);
           
            GameManager.lives--;
            

        }
        if (collision.gameObject.tag == "Homeship")
        {
           
            Destroy(enemyProjectile);

            GameManager.lives--;


        }
        if (collision.gameObject.tag == "Platform")
        {

            Destroy(enemyProjectile);
        }
        if (collision.gameObject.tag == "Wall")
        {

            Destroy(enemyProjectile);
        }
    }
}