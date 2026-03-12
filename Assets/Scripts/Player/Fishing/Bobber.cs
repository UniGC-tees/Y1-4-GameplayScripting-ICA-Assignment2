using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class Bobber : MonoBehaviour
{
    Rigidbody body;
    bool currentlyBobbing = false;

    void Start()
    {
        body = GetComponent<Rigidbody>();

        body.AddForce(transform.forward * 400, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!currentlyBobbing)
        {
            if(other.gameObject.tag.Equals("BobbableSurface"))
            {
                UnityEngine.Debug.Log("i should be bobbing");

                StartCoroutine(Bobbing());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator Bobbing()
    {
        UnityEngine.Debug.Log("bobbing started");
        currentlyBobbing = true;

        Vector3 tinyUp = new (0, 0.01f, 0);

        // STOP
        body.useGravity = false;
        body.linearVelocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.isKinematic = true;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 10000, 0), -transform.up, out hit, 30000f, 5, QueryTriggerInteraction.Collide))
        {
            transform.position = hit.point + new Vector3 (0,-0.9f,0);
            UnityEngine.Debug.Log("I HIT!!");
        }

        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                transform.position = transform.position + tinyUp;
                yield return new WaitForSeconds(0.03f);
            }

            for (int i = 0; i < 10; i++)
            {
                transform.position = transform.position + -tinyUp;
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}