using System.Collections;
using UnityEngine;

public class PlayerTriggerCollisionDebugger : MonoBehaviour
{
    public PlayerScore playerScore; // Reference to PlayerScore
    public AudioSource gameOverSound; // Game-over sound
    public float delayBeforeGameOverUI = 2f; // Delay before showing the Game Over UI

    private bool isGameOver = false; // Prevent multiple triggers

    // References to other components
    public UIManager uiManager; // For UI management
    public CalibrationNoticer calibrationNoticer; // For UI canvas control
    public ObstacleSpawner obstacleSpawner; // To handle obstacle spawning and despawning

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) // Check if collided object is an obstacle
        {
            if (!isGameOver)
            {
                isGameOver = true; // Mark game as over

                // Trigger PlayerScore OnGameOver logic
                if (playerScore != null)
                {
                    playerScore.OnGameOver();
                }

                // Start game-over sequence
                StartCoroutine(GameOverSequence(other.gameObject)); // Pass the collided obstacle
            }
        }
    }

    private IEnumerator GameOverSequence(GameObject collidedObstacle)
    {
        // Play game-over sound
        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }

        // Pause the game
        Time.timeScale = 0;

        // Deactivate the collided obstacle immediately
        if (collidedObstacle != null)
        {
            Destroy(collidedObstacle); // Remove the specific obstacle from the scene
        }

        // Wait for 2 seconds before despawning the remaining obstacles
        yield return new WaitForSecondsRealtime(2f);

        // Despawn all remaining obstacles
        if (obstacleSpawner != null)
        {
            obstacleSpawner.DespawnAllObstacles();
        }

        // Reactivate the canvas
        if (calibrationNoticer != null && calibrationNoticer.uiCanvas != null)
        {
            // Clear "Begin Flapping" text to avoid showing it in the wrong state
            calibrationNoticer.ClearBeginFlappingText();

            calibrationNoticer.uiCanvas.SetActive(true);
        }

        // Wait before showing the Game Over UI
        yield return new WaitForSecondsRealtime(delayBeforeGameOverUI);

        // Update GameManagement state
        if (GameManagement.Instance != null)
        {
            GameManagement.Instance.ResetGame(); // Set isGameStarted to false
        }

        // Show Game Over UI
        if (uiManager != null && uiManager.lastUIElements != null)
        {
            uiManager.lastUIElements.SetActive(true);
        }

        Debug.Log("Game Over UI is now active.");
    }
}
