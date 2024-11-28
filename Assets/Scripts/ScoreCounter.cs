using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For updating UI
using TMPro; // Add this to use TextMeshPro

public class PlayerScore : MonoBehaviour
{
    public int score = 0; // The player's score
    public TextMeshProUGUI scoreText; // UI TextMeshProUGUI to display the score
    private HighscoreManager highscoreManager; // Reference to the HighscoreManager script

    private void Start()
    {
        highscoreManager = FindObjectOfType<HighscoreManager>(); // Find HighscoreManager in the scene
        UpdateScoreText(); // Initialize the score text when the game starts

        // Load and display the highscore at the start
        if (highscoreManager != null)
        {
            highscoreManager.LoadHighscore();
        }
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

    // Call this method when the game ends to save the highscore and update the UI
    public void OnGameOver()
    {
        if (highscoreManager != null)
        {
            highscoreManager.SaveHighscore(score); // Save the highscore if necessary
            highscoreManager.DisplayHighscore(scoreText); // Display highscore in the UI
        }
    }
}
