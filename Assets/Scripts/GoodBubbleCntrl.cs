using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBubbleCntrl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //add points
        }
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
    }
}
