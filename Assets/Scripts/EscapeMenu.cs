using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenu; // Reference to the escape menu (panel with buttons)
    private bool isMenuActive = false; // Flag to track the menu state

    void Update()
    {
        // Listen for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu(); // Toggle the menu visibility when Escape is pressed
        }
    }

    // Method to toggle the escape menu
    void ToggleMenu()
    {
        isMenuActive = !isMenuActive; // Toggle the state
        escapeMenu.SetActive(isMenuActive); // Set the menu active or inactive
        Time.timeScale = isMenuActive ? 0f : 1f; // Pause/unpause the game
    }

    // Method to resume the game when clicking the "Resume" button
    public void ResumeGame()
    {
        ToggleMenu(); // Close the menu
    }

    // Method to quit the game when clicking the "Quit" button
    public void QuitGame()
    {
        // For editor testing:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
