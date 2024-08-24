using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] AudioClip bulletSound;
    PlayerMovement playerMovement;
    //Testing
    [SerializeField] int pointsForEnemyDead = 100;

    float xSpeed;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        xSpeed = playerMovement.transform.localScale.x * bulletSpeed;
        AudioSource.PlayClipAtPoint(bulletSound, Camera.main.transform.position,0.2f);
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(xSpeed, myRigidBody.velocity.y);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            FindObjectOfType<GameSession>().addScore(pointsForEnemyDead);
            Destroy(other.gameObject);

        }
        Destroy(gameObject);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
