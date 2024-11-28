using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FlappyBirdVR : MonoBehaviour
{
    [SerializeField] private XRNode controllerNode = XRNode.RightHand; // Choose Right or Left controller
    [SerializeField] private float flapStrength = 5f; // The force applied when "flapping"
    [SerializeField] private float flapThreshold = 0.1f; // Minimum movement to trigger a flap

    private Rigidbody rb;
    private InputDevice controller;
    private Vector3 lastControllerPosition;

    void Start()
    {
        // Initialize the Rigidbody and controller
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the GameObject!");
            return;
        }

        controller = InputDevices.GetDeviceAtXRNode(controllerNode);
        if (!controller.isValid)
        {
            Debug.LogError("Controller not found! Check XR setup.");
        }
        else
        {
            controller.TryGetFeatureValue(CommonUsages.devicePosition, out lastControllerPosition);
        }
    }

    void Update()
    {
        if (controller.isValid && controller.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 currentControllerPosition))
        {
            // Calculate vertical movement
            float verticalMovement = currentControllerPosition.y - lastControllerPosition.y;

            // Apply a flap if the movement exceeds the threshold
            if (verticalMovement > flapThreshold)
            {
                rb.velocity = new Vector3(rb.velocity.x, flapStrength, rb.velocity.z);
            }

            // Update the last position for the next frame
            lastControllerPosition = currentControllerPosition;
        }
        else
        {
            Debug.LogWarning("Controller not providing position data.");
        }
    }
}


