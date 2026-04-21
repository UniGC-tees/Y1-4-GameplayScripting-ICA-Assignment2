using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Swim : MonoBehaviour
{
    public LayerMask mask;

    private float swimAngle;
    [SerializeField] private float swimSpeed;
    [HideInInspector] public bool freaky = true;
    [HideInInspector] public bool shouldMove = true;
    private GameObject bob;

    private void Start()
    {
        swimAngle = Random.Range(-10, 10);

        InvokeRepeating(nameof(Nudge), 0, 0.2f);
    }

    private void FixedUpdate()
    {
        if (shouldMove)
        {
            if (freaky) // freaky == not in range of a bobber
            {
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + swimAngle, 0);
            }
            else
            {
                if (bob == null)
                {
                    Debug.Log("bobber removed by player");
                    freaky = true;
                    return;
                }

                Quaternion r = transform.rotation;
                transform.LookAt(bob.transform.position);
                Quaternion goalR = transform.rotation * new Quaternion(0,-1,0,0);

                transform.rotation = Quaternion.Lerp(r, goalR, 0.07f);
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
        if (Physics.Raycast(transform.position + new Vector3(0,10000,0), Vector3.down, out hit, 30000f, mask, QueryTriggerInteraction.Collide))
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
        Debug.Log("i am being pulled");

        gameObject.AddComponent<Rotate>();
        Shrink shrinkScript = gameObject.AddComponent<Shrink>();

        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, towards.transform.position + new Vector3(0,2,0), 0.02f);

            if (shrinkScript.done)
            {
                break;
            }

            yield return new WaitForSeconds(0.01f);
        }
        Debug.Log("i am done being pulled");

        towards.GetComponent<TalkingFishManager>().Next();

        Destroy(gameObject);
    }
}