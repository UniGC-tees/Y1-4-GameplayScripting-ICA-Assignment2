using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Swim : MonoBehaviour
{
    private float swimAngle;
    [SerializeField] private float swimSpeed;
    public LayerMask mask;
    [HideInInspector] public bool freaky = true;
    private GameObject bob;
    [HideInInspector] public bool shouldMove = true;

    private void Start()
    {
        swimAngle = Random.Range(-10, 10);

        InvokeRepeating(nameof(Nudge), 0, 0.2f);
    }

    private void FixedUpdate()
    {
        if (shouldMove)
        {
            if (freaky)
            {
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + swimAngle, 0);
            }
            else
            {
                Vector3 targetDir = bob.transform.position - transform.position;
                float angle = Vector3.Angle(targetDir, -transform.forward);

                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + angle, 0);
            }

            transform.position += -transform.forward * swimSpeed; 

            AlignToWater();
        }
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
        }
        else
        {
            Debug.Log("fih: tried to align to water... but no hit");
        }
    }

    public void GoCrazy(GameObject bob)
    {
        Debug.Log("hey yo im liyt crae");
        this.bob = bob;
    }

    public IEnumerator Pull(GameObject towards)
    {
        bool reached = false;
        while (!reached)
        {
            transform.position = Vector3.Lerp(towards.transform.position, transform.position, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}