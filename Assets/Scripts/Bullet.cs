using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float bulletSpeed = 5f;
    PlayerMovement playerMovement;
    float xSpeed;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        xSpeed = playerMovement.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(xSpeed, myRigidBody.velocity.y);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);

        }
        Destroy(gameObject);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
