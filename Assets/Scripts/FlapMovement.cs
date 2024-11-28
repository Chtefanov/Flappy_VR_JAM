using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FlappyBirdVR : MonoBehaviour
{
    [SerializeField] private XRNode controllerNode = XRNode.RightHand; // Use the right-hand controller by default
    [SerializeField] private float flapStrength = 5f; // Vertical boost on a "flap"
    [SerializeField] private float gravity = -9.8f; // Gravity applied to the bird
    [SerializeField] private float flapThreshold = 0.1f; // Minimum controller Y movement to trigger a flap

    private Vector3 velocity = Vector3.zero; // Bird's velocity
    private InputDevice controller;
    private Vector3 lastControllerPosition;

    void Start()
    {
        // Initialize the controller
        controller = InputDevices.GetDeviceAtXRNode(controllerNode);
        controller.TryGetFeatureValue(CommonUsages.devicePosition, out lastControllerPosition);
    }

    void Update()
    {
        // Get the current position of the controller
        if (controller.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 currentControllerPosition))
        {
            float verticalMovement = currentControllerPosition.y - lastControllerPosition.y;

            // If the controller moves upward enough, trigger a flap
            if (verticalMovement > flapThreshold)
            {
                velocity.y = flapStrength;
            }

            // Update the last controller position
            lastControllerPosition = currentControllerPosition;
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Move the bird based on velocity
        transform.position += velocity * Time.deltaTime;

        // Optional: Limit downward speed
        if (velocity.y < -10f)
        {
            velocity.y = -10f;
        }
    }
}
