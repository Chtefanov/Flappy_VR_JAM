using UnityEngine;

public class FlightControl : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;
    public Transform leftCalibrationPoint;
    public Transform rightCalibrationPoint;
    public Rigidbody sphere;

    public float upwardForce = 5f; // Kraft n?r controllerne peger nedad
    public float downwardForce = -10f; // Kraft n?r controllerne peger opad
    public float gentleDescendForce = -2f; // Langsom faldkraft i neutral position
    public float neutralThreshold = 0.1f; // Neutralzone t?rskel
    public float maxSpeed = 10f; // Begr?ns Sphere's maksimale hastighed

    private void Start()
    {
        if (sphere != null)
        {
            sphere.isKinematic = true;
        }
    }

    private void FixedUpdate()
    {
        if (GameManagement.Instance == null || !GameManagement.Instance.IsGameStarted())
        {
            if (sphere != null)
            {
                sphere.isKinematic = true;
            }
            return;
        }

        if (sphere != null && sphere.isKinematic)
        {
            sphere.isKinematic = false;
        }

        if (leftController == null || rightController == null || leftCalibrationPoint == null || rightCalibrationPoint == null || sphere == null)
            return;

        float leftRelativeY = leftController.position.y - leftCalibrationPoint.position.y;
        float rightRelativeY = rightController.position.y - rightCalibrationPoint.position.y;

        if (leftRelativeY < -neutralThreshold && rightRelativeY < -neutralThreshold)
        {
            ApplyForce(Vector3.up * upwardForce);
        }
        else if (leftRelativeY > neutralThreshold && rightRelativeY > neutralThreshold)
        {
            ApplyForce(Vector3.up * downwardForce);
        }
        else
        {
            ApplyForce(Vector3.up * gentleDescendForce);
        }

        LimitVelocity();
    }

    private void ApplyForce(Vector3 force)
    {
        sphere.AddForce(force, ForceMode.Acceleration);
    }

    private void LimitVelocity()
    {
        if (sphere.velocity.magnitude > maxSpeed)
        {
            sphere.velocity = sphere.velocity.normalized * maxSpeed;
        }
    }
}
