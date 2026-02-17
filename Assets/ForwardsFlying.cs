using Unity.VisualScripting.ReorderableList.Internal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ForwardsFlying : MonoBehaviour
{
    public float flySpeed = 0.2f;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.transform.position = (rb.transform.forward * flySpeed) + rb.transform.position;
    }
}
