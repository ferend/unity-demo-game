using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile1 : MonoBehaviour
{
    public GameObject projectile;
    public GameObject enemyProjectile;

    public Text Score;

    public GameObject ExpAnimator;
    public AudioClip destroySound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 8 * Time.deltaTime, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(projectile);
            Destroy(enemyProjectile);

            EnemySpawner.score = EnemySpawner.score + 5;
            EnemySpawner.enemyCount--;

            ExpAnimator.gameObject.SetActive(true);

        }

        if (collision.gameObject.tag == "Wall")
        {
            
            Destroy(projectile);
        }

        if (collision.gameObject.tag == "Platform")
        {
            
            Destroy(projectile);
        }
        if (collision.gameObject.tag == "Enemy Projectile")
        {

            Destroy(projectile);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Outlier")
        {

            Destroy(projectile);
        }
    }


   
}
