using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnTouchVelocity : MonoBehaviour
{
    public GameObject ballPrefab; // Reference til boldens prefab
    public Transform spawnLocation; // Hvor bolden skal spawnes
    private void OnTriggerEnter(Collider other)
    {
        SpawnBall();
    }
    private void SpawnBall()
    {
        if (ballPrefab != null && spawnLocation != null)
        {
            Instantiate(ballPrefab, spawnLocation.position, spawnLocation.rotation);
        }
    }

}
