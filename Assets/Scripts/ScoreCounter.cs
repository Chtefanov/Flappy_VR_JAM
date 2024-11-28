using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For updating UI
using TMPro; // Add this to use TextMeshPro

public class PlayerScore : MonoBehaviour
{
    public int score = 0; // The player's score
    public TextMeshProUGUI scoreText; // UI TextMeshProUGUI to display the score

    private void Start()
    {
        UpdateScoreText(); // Initialize the score text when the game starts
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText(); // Update score when points are added
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update the score text
        }
    }
}
