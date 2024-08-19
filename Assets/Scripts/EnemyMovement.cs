using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    BoxCollider2D myBoxCollider;
    CapsuleCollider2D myCapsuleCollider;

    [SerializeField] float moveSpeed = 1f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Enemy")
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }

    }
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
