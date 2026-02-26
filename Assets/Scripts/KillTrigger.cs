using UnityEngine;

[RequireComponent(typeof(MeshCollider))]

public class KillTrigger : MonoBehaviour
{
    private MeshCollider joe;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Killable>().Die();
    }
}
