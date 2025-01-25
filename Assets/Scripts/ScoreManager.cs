using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;


    public void AddScore ()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void MinusScore()
    {
        score--;
        scoreText.text = score.ToString();
    }
}
