using UnityEngine;
using TMPro; // Add this to use TextMeshPro

public class PlayerScore : MonoBehaviour
{
    public int score = 0; // The player's score
    public TextMeshProUGUI scoreText; // UI TextMeshProUGUI to display the score
    private HighscoreManager highscoreManager; // Reference to the HighscoreManager script
    private AudioSource audioSource; // Reference to AudioSource

    private void Start()
    {
        highscoreManager = FindObjectOfType<HighscoreManager>(); // Find HighscoreManager in the scene
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
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
        PlayScoreSound(); // Play sound when score is added
        UpdateScoreText(); // Update score when points are added
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update the score text
        }
    }

    private void PlayScoreSound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Play the assigned sound
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
