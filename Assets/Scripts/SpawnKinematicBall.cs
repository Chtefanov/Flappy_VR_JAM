using UnityEngine;

public class SpawnKinematicBall : MonoBehaviour
{
    public GameObject kinematicBallPrefab; // Reference til den kinematiske bolds prefab
    public Transform spawnLocation; // Hvor bolden skal spawnes

    private void OnTriggerEnter(Collider other)
    {
        // Spawn den kinematiske bold, n?r cuben ber?res
        SpawnBall();
    }

    private void SpawnBall()
    {
        // Check at b?de kinematicBallPrefab og spawnLocation er sat
        if (kinematicBallPrefab != null && spawnLocation != null)
        {
            // Spawn den kinematiske bold ved spawnLocation's position og rotation
            Instantiate(kinematicBallPrefab, spawnLocation.position, spawnLocation.rotation);
        }
        else
        {
            Debug.LogError("kinematicBallPrefab eller spawnLocation er ikke sat i Inspector!");
        }
    }
}
