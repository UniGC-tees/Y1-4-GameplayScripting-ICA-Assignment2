using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

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

        Vector3 tinyUp = new (0, 0.05f, 0);

        body.useGravity = false;
        body.angularVelocity = new Vector3(0, 0, 0);

        for (int i = 0; i < 30; i++)
        {
            transform.position = transform.position + tinyUp;
            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(1);

        for (int i = 0; i < 30; i++)
        {
            transform.position = transform.position + -tinyUp;
            yield return new WaitForSeconds(0.03f);
        }
    }
}