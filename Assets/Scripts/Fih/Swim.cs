using System.Collections;
using UnityEngine;

public class Swim : MonoBehaviour
{

    private float swimAngle;

    private void Start()
    {
        swimAngle = Random.Range(-10, 10);

        InvokeRepeating(nameof(Nudge), 0, 0.2f);
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + swimAngle, 0);

        transform.position += -transform.forward*0.1f;
    }

    private void Nudge()
    {
        swimAngle =+ Random.Range(-2,2);
    }
}
