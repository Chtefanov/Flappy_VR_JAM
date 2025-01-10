using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class PlayerTriggerCollisionDebugger : MonoBehaviour
{
    //public PlayerScore playerScore; // Reference to PlayerScore to call OnGameOver()
    //public AudioSource gameOverSound; // Reference to the AudioSource for the game-over sound
    public float delayBeforeRestart = 2f; // Delay in seconds before restarting the scene
    public GameObject sphere; // Reference to the Sphere for collision detection

    private bool isGameOver = false; // Prevent multiple triggers

    private void OnTriggerEnter(Collider other)
    {
        // Log the name of the object the player collided with
        Debug.Log("Triggered with: " + other.gameObject.name);

        // Check if the collision is with the specific Sphere
        if (other.gameObject == sphere)
        {
          // Debug.Log("Collision with Sphere detected!");

            // Prevent multiple triggers
            if (!isGameOver)
            {
                isGameOver = true; // Prevent further triggers

                // Call OnGameOver to save the high score
               /* if (playerScore != null)
                {
                    playerScore.OnGameOver();
                }*/

                // Start the game-over sequence
                StartCoroutine(GameOverSequence());
            }
        }
        else
        {
            Debug.Log("Collision with an object that is not the Sphere.");
        }
    }

    // Coroutine to handle game-over delay and restart
    private IEnumerator GameOverSequence()
    {
        // Play the game-over sound only once
       /* if (gameOverSound != null)
        {
            gameOverSound.Play();
        }
        else
        {
            Debug.LogWarning("Game over sound is not assigned!");
        }
       */
        // Pause gameplay (not audio)
        Time.timeScale = 0;

        // Wait for the specified delay
        yield return new WaitForSecondsRealtime(delayBeforeRestart);

        // Resume gameplay
        Time.timeScale = 1;

        // Restart the scene
       // Debug.Log("Restarting scene: " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
