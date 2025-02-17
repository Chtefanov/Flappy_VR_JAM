using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementNoScore : MonoBehaviour
{
    public float speed = 5f;              // The speed at which the obstacle moves
    private float playerZPosition;        // Z position of the player when the obstacle spawns

    private void Update()
    {
        // Move the obstacle towards the player (along negative Z-axis)
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Optionally destroy the obstacle once it's out of the screen
        if (transform.position.z < -10f)
        {
            Destroy(gameObject); // Destroy the object when it's out of the screen
        }
    }

    // Set the initial player Z position when the obstacle spawns
    public void SetPlayerZPosition(float playerZ)
    {
        playerZPosition = playerZ; // This stores the player's initial position for reference
    }
}
