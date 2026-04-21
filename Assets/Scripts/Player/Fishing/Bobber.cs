using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SphereCollider))]

public class Bobber : MonoBehaviour
{
    Rigidbody body;
    public GameObject fisher;
    bool currentlyBobbing = false;

    void Start()
    {
        body = transform.parent.GetComponent<Rigidbody>();

        body.AddForce(transform.forward * 400, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!currentlyBobbing && other.transform.parent != transform.parent)
        {
            if(other.gameObject.tag.Equals("BobbableSurface"))
            {
                StartCoroutine(Bobbing());
            }
            else
            {
                Destroy(transform.parent.gameObject);
            }
        }
        else
        {
            if (currentlyBobbing && other.TryGetComponent<Swim>(out Swim swim))
            {
                swim.shouldMove = false;
                Debug.Log("i am going to tell the fih to be pulled");
                swim.StartCoroutine(swim.Pull(fisher));
            }
        }
    }

    private IEnumerator Bobbing()
    {
        currentlyBobbing = true;

        Vector3 tinyUp = new (0, 0.01f, 0);

        // STOP
        body.useGravity = false;
        body.linearVelocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.isKinematic = true;


        if (Physics.Raycast(transform.position + new Vector3(0, 10000, 0), -transform.up, out RaycastHit hit, 30000f, 5, QueryTriggerInteraction.Collide))
        {
            transform.position = hit.point + new Vector3 (0,-2.35f,0);
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