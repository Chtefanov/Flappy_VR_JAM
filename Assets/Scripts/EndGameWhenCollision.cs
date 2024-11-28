using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To load the scene

public class PlayerTriggerCollisionDebugger : MonoBehaviour
{
    // When the player enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Log the name of the object the player collided with
        Debug.Log("Triggered with: " + other.gameObject.name);

        // Check if the player triggered with an obstacle (cylinder)
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle detected!");

            // End the game by reloading the current scene
            Debug.Log("Current active scene: " + SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
        }
    }

    // Optional: Log when the player enters the trigger zone to verify if it's being entered
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Player is within trigger range of the obstacle.");
        }
    }

    // Optional: Log when the player exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Player exited trigger range of the obstacle.");
        }
    }
}
