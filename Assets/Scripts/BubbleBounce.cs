using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            return;
        }
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 10f);
    }
}
