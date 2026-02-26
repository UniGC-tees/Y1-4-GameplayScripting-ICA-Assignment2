using Unity.VisualScripting.ReorderableList.Internal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ForwardsFlying : MonoBehaviour
{
    public float flySpeed = 0.2f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.transform.position = (rb.transform.forward * flySpeed) + rb.transform.position;
    }
}
