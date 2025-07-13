using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class PickUpBall : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    [HideInInspector] public bool isHeld = false;
    [HideInInspector] public bool wasThrown = false;
    public bool isSimulatedHold = false;

    void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
        rb.useGravity = true;

        // Dacă a fost aruncată cu o anumită viteză, o considerăm aruncată
        if (rb.velocity.magnitude > 1f)
        {
            wasThrown = true;
        }
    }

    public bool IsHeld()
    {
        return isHeld;
    }

    public void ResetThrownFlag()
    {
        wasThrown = false;
    }

    // Test pentru XR Device Simulator: Apăsând P, mingea e ridicată și apoi aruncată
    void Update()
    {
        if (!isSimulatedHold && (Input.GetKeyDown(KeyCode.P)))
        {
            if (!isSimulatedHold)
            {
                // Ridicare simulată
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;
                transform.SetParent(Camera.main.transform);
                isSimulatedHold = true;
                isHeld = true;
            }
            else
            {
                // Aruncare simulată
                transform.SetParent(null);
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.velocity = Camera.main.transform.forward * 5f + Vector3.up * 2f;
                isSimulatedHold = false;
                isHeld = false;
                wasThrown = true;
            }
        }
    }
}
