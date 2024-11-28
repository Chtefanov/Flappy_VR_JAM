using UnityEngine;

public class BeerPong : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PongBall>() != null)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
