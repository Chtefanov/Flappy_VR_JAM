using TMPro;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public int highscore = 0; // Stores the high score

    private const string HighscoreKey = "Highscore"; // Key for PlayerPrefs

    // Load the high score from PlayerPrefs
    public void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt(HighscoreKey, 0); // Default is 0 if no high score exists
    }

    // Save the high score to PlayerPrefs
    public void SaveHighscore(int score)
    {
        if (score > highscore) // Save only if the new score is higher
        {
            highscore = score;
            PlayerPrefs.SetInt(HighscoreKey, highscore);
            PlayerPrefs.Save(); // Ensure data is written to disk
        }
    }

    // Optional: Display high score in UI
    public void DisplayHighscore(TextMeshProUGUI highscoreText)
    {
        if (highscoreText != null)
        {
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
    }
}



