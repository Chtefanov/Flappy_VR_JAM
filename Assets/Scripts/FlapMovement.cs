using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FlappyBirdVR : MonoBehaviour
{
    [SerializeField] private XRNode controllerNode = XRNode.RightHand;
    [SerializeField] private float flapStrength = 5f;
    [SerializeField] private float flapThreshold = 0.1f;

    private Rigidbody rb;
    private InputDevice controller;
    private Vector3 lastControllerPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true; // Ensure Rigidbody gravity is enabled
        controller = InputDevices.GetDeviceAtXRNode(controllerNode);
        controller.TryGetFeatureValue(CommonUsages.devicePosition, out lastControllerPosition);
    }

    void Update()
    {
        if (controller.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 currentControllerPosition))
        {
            float verticalMovement = currentControllerPosition.y - lastControllerPosition.y;

            if (verticalMovement > flapThreshold)
            {
                rb.velocity = new Vector3(rb.velocity.x, flapStrength, rb.velocity.z); // Apply upward force
            }

            lastControllerPosition = currentControllerPosition;
        }
    }
}

