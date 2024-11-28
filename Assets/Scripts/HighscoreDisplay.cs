using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highscoreText; // UI TextMeshProUGUI to display the highscore
    private HighscoreManager highscoreManager; // Reference to the HighscoreManager script

    private void Start()
    {
        highscoreManager = FindObjectOfType<HighscoreManager>(); // Find HighscoreManager in the scene
        UpdateHighscoreText(); // Update the highscore text when the menu starts
    }

    private void UpdateHighscoreText()
    {
        if (highscoreManager != null && highscoreText != null)
        {
            highscoreText.text = "Highscore: " + highscoreManager.highscore.ToString(); // Display the highscore
        }
    }
}
