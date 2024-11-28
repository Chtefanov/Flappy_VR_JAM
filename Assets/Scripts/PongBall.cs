using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        grabInteractable.selectExited.AddListener(OnThrow);
    }
    private void OnDisable()
    {
        grabInteractable.selectExited.RemoveListener(OnThrow);
    }
    private void OnThrow(SelectExitEventArgs args)
    {
        rb.isKinematic = false;
        var interactor = args.interactorObject.transform.GetComponent<Rigidbody>();
        if (interactor != null)
        {
            rb.velocity = interactor.velocity;
            rb.angularVelocity = interactor.angularVelocity;
        }
    }
}
