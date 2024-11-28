using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this to use TextMeshPro

public class HighscoreManager : MonoBehaviour
{
    private const string HighscoreKey = "Highscore"; // Key to save/load highscore
    public int highscore = 0; // The player's highscore

    public TextMeshProUGUI highscoreText; // UI TextMeshProUGUI to display the highscore

    private void Start()
    {
        LoadHighscore(); // Load the highscore when the game starts
    }

    // Save the highscore if the current score is higher
    public void SaveHighscore(int score)
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(HighscoreKey, highscore); // Save to PlayerPrefs
            PlayerPrefs.Save();
        }
    }

    // Load the highscore from PlayerPrefs
    public void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt(HighscoreKey, 0); // Default to 0 if no highscore is found
        if (highscoreText != null)
        {
            highscoreText.text = "Highscore: " + highscore.ToString(); // Update the highscore text
        }
    }

    // Display the highscore in the UI
    public void DisplayHighscore(TextMeshProUGUI scoreText)
    {
        if (scoreText != null)
        {
            scoreText.text = "Highscore: " + highscore.ToString(); // Update the score text
        }
    }
}


