using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObstacles : MonoBehaviour
{
    public float pushForce = 10f;

    private Rigidbody2D rb;
    private bool isBeingPushed = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 pushDirection = collision.contacts[0].normal;
            rb.velocity = pushDirection * pushForce;
            isBeingPushed = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isBeingPushed)
        {
            Vector2 pushDirection = collision.contacts[0].normal;
            rb.velocity = pushDirection * pushForce;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        isBeingPushed = false;
    }
}



