using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public GameObject Player;
    public GameObject projectile;
    private GameObject projectileClone;

    private AudioSource playerAudio;
    public AudioClip fireSound;
   
    public AudioClip dieSound;

    public float speed = 1.0f;

    public ParticleSystem explosionEffect;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.lives > 0)
        {
            MovePlayer();
            fireProjectile();
        }
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.up * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

    }
   

    void fireProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectileClone = Instantiate(projectile, new Vector3(Player.transform.position.x, Player.transform.position.y + 0.8f, 0), Player.transform.rotation) as GameObject;
         //   playerAudio.PlayOneShot(fireSound);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.lives--;
            playerAudio.PlayOneShot(dieSound);
            
        }
    }
    }