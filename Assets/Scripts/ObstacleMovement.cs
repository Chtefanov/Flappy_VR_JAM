using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;

        // Optional: Destroy obstacles after they've passed the player
        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }
}

