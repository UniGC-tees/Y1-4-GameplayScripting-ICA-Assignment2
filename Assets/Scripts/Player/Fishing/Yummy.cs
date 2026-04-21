using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Yummy : MonoBehaviour
{
    [SerializeField] private GameObject[] thisIsAFih;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Swim>(out Swim swim))
        {
            Debug.Log("fih in range");
            swim.freaky = false;
            swim.GoCrazy(transform.parent.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Swim>(out Swim swim))
        {
            Debug.Log("fih out of range");
            swim.freaky = true;
        }
    }
}