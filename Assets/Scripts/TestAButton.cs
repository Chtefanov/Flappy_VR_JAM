using UnityEngine;
using UnityEngine.InputSystem;

public class TestAButton : MonoBehaviour
{
    public InputActionProperty selectUIAction; // Tr?k din SelectUI Action her

    void OnEnable()
    {
        // S?rg for, at Action er aktiveret
        selectUIAction.action.Enable();
    }

    void OnDisable()
    {
        // Deaktiver Action for at undg? fejl
        selectUIAction.action.Disable();
    }

    void Update()
    {
        if (selectUIAction.action.WasPressedThisFrame())
        {
            Debug.Log("A-knappen blev trykket!");
        }
    }
}
