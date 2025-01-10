using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public float delayBeforeRestart = 2f; // Delay in seconds before restarting the scene

    private bool isGameOver = false; // Prevent multiple triggers

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle detected!");

            // Prevent multiple triggers
            if (!isGameOver)
            {
                isGameOver = true;

                // Stop the game
                StartCoroutine(GameOverSequence());
            }
        }
    }

    // Coroutine to handle game-over delay and restart
    private IEnumerator GameOverSequence()
    {
        // Pause gameplay (not audio)
        Time.timeScale = 0;

        // Wait for the specified delay
        yield return new WaitForSecondsRealtime(delayBeforeRestart);

        // Resume gameplay
        Time.timeScale = 1;

        // Restart the scene
        //Debug.Log("Restarting scene: " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}