using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateInputActions : MonoBehaviour
{
    public InputActionAsset inputActionAsset; // Drag dit Input Action Asset her

    void Start()
    {
        if (inputActionAsset != null)
        {
            Debug.Log("Input Actions enabled!");
            inputActionAsset.Enable();
        }
        else
        {
            Debug.LogWarning("Input Action Asset is missing!");
        }
    }
}
