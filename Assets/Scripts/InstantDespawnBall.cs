using UnityEngine;

public class InstantDespawnBall : MonoBehaviour
{
    public float despawnTime = 20.0f; 

    private void Start()
    {
        if (despawnTime > 0)
        {
            Destroy(gameObject, despawnTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
