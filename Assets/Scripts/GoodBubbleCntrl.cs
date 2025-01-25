using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBubbleCntrl : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }
    }
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
            scoreManager.AddScore();
            return;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            scoreManager.MinusScore();
            return;
        }
    }
}
