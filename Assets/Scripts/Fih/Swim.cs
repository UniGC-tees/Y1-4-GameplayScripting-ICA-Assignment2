using System.Collections;
using UnityEngine;

public class Swim : MonoBehaviour
{
    private float swimAngle;
    [SerializeField] private float swimSpeed;
    public LayerMask mask;

    private void Start()
    {
        swimAngle = Random.Range(-10, 10);

        InvokeRepeating(nameof(Nudge), 0, 0.2f);
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + swimAngle, 0);

        transform.position += -transform.forward * swimSpeed;

        AlignToWater();
    }

    private void Nudge()
    {
        swimAngle =+ Random.Range(-2,2);
    }

    // just trying out overloads (woah)
    private void Nudge(int angleRange)
    {
        swimAngle = +Random.Range(-angleRange, angleRange);
    }

    private void AlignToWater()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0,10000,0), -transform.up, out hit, 30000f, mask, QueryTriggerInteraction.Collide))
        {
            transform.position = hit.point - new Vector3(0,0,0);

            Debug.Log("hit");


            // Debug.DrawRay(transform.position + new Vector3(0, 50, 0), -transform.up, new Color(50, 50, 50), 30f);
        }
        else
        {
            Debug.Log("no hit");
        }
    }
}