using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionProperty leftHandPositionAction;  // Venstre h?nd position
    public InputActionProperty rightHandPositionAction; // H?jre h?nd position

    [Header("Movement Settings")]
    public float movementSpeed = 2.0f;  // Hvor hurtigt fuglen bev?ger sig
    public float shoulderHeight = 1.5f; // H?jde over jorden for skulderniveau
    public float hipHeight = 0.8f;      // H?jde over jorden for hofteniveau

    void Update()
    {
        // Hent h?ndpositioner
        Vector3 leftHandPosition = leftHandPositionAction.action.ReadValue<Vector3>();
        Vector3 rightHandPosition = rightHandPositionAction.action.ReadValue<Vector3>();

        // Beregn gennemsnitlig h?jde p? h?nderne
        float averageHandHeight = (leftHandPosition.y + rightHandPosition.y) / 2.0f;

        // Tjek h?ndniveau og bev?g sf?ren
        if (averageHandHeight > shoulderHeight) // Hvis h?nderne er over skulderniveau
        {
            transform.position += new Vector3(0, -movementSpeed * Time.deltaTime, 0); // Bev?g nedad
        }
        else if (averageHandHeight < hipHeight) // Hvis h?nderne er under hofteniveau
        {
            transform.position += new Vector3(0, movementSpeed * Time.deltaTime, 0); // Bev?g opad
        }
        // Hvis h?nderne er mellem skulder- og hofteniveau, bev?ger sf?ren sig ikke
    }
}
