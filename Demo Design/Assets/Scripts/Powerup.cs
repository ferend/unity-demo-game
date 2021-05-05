using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject powerup;
   private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        //Debug.Log("Pickup");
        Destroy(gameObject);

        GameManager.lives++;
    }

    void PowerupSpawn ()
    {

    }

}
