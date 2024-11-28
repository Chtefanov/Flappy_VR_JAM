using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array to hold different obstacle prefabs
    public Transform player;            // The player transform
    public float spawnDistance = 10f;   // Distance from the player
    public float spawnInterval = 2f;    // Time between spawns
    public float minHeight = -4.5f;    // Minimum spawn height
    public float maxHeight = 10f;      // Maximum spawn height

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval); // Spawn at regular intervals
    }

    private void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0)
        {
            Debug.LogError("No obstacle prefabs assigned!");
            return;
        }

        // Choose a random prefab
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randomIndex];

        // Calculate spawn position in front of the player
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;

        // Set a random height between minHeight and maxHeight
        spawnPosition.y = Random.Range(minHeight, maxHeight);

        // Instantiate the selected prefab at the calculated position
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}
