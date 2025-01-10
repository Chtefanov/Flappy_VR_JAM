using UnityEngine;

public class FlightControl : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;
    public Transform leftCalibrationPoint;
    public Transform rightCalibrationPoint;
    public Rigidbody sphere;

    public float upwardForce = 8f; // Kraft til at bev?ge opad
    public float downwardForce = -8f; // Kraft til at bev?ge nedad
    public float gentleDescendForce = -2f; // Langsom nedadg?ende bev?gelse
    public float neutralThreshold = 0.1f; // Omr?de omkring kalibreringspunktet, der anses for neutralt
    public float maxSpeed = 10f; // Maksimal hastighed for Sphere

    private void Start()
    {
        if (sphere != null)
        {
            sphere.useGravity = false; // Deaktiver gravity
            sphere.isKinematic = true; // Forhindr fysisk bev?gelse indtil spillet starter
        }
    }

    private void FixedUpdate()
    {
        if (GameManagement.Instance == null || !GameManagement.Instance.IsGameStarted())
        {
            if (sphere != null)
            {
                sphere.useGravity = false;
                sphere.isKinematic = true;
            }
            return; // G?r intet, hvis spillet ikke er startet
        }

        if (sphere != null && sphere.isKinematic)
        {
            sphere.useGravity = false; // Forbliv uden gravity
            sphere.isKinematic = false;
        }

        if (leftController == null || rightController == null || leftCalibrationPoint == null || rightCalibrationPoint == null || sphere == null)
            return;

        float leftRelativeY = leftController.position.y - leftCalibrationPoint.position.y;
        float rightRelativeY = rightController.position.y - rightCalibrationPoint.position.y;

        // Gennemsnit af begge controllere for at finde en samlet retning
        float averageRelativeY = (leftRelativeY + rightRelativeY) / 2f;

        if (averageRelativeY < -neutralThreshold) // Controllere peger nedad
        {
            ApplyForce(Vector3.up * upwardForce);
        }
        else if (averageRelativeY > neutralThreshold) // Controllere peger opad
        {
            ApplyForce(Vector3.up * downwardForce);
        }
        else // Neutral position (arme t?t p? kalibreringspunkt)
        {
            ApplyForce(Vector3.up * gentleDescendForce);
        }

        LimitVelocity(); // Begr?ns Sphere's hastighed
    }

    private void ApplyForce(Vector3 force)
    {
        sphere.AddForce(force, ForceMode.Acceleration);
    }

    private void LimitVelocity()
    {
        if (sphere.velocity.y > maxSpeed)
        {
            sphere.velocity = new Vector3(sphere.velocity.x, maxSpeed, sphere.velocity.z);
        }
        else if (sphere.velocity.y < -maxSpeed)
        {
            sphere.velocity = new Vector3(sphere.velocity.x, -maxSpeed, sphere.velocity.z);
        }
    }
}
