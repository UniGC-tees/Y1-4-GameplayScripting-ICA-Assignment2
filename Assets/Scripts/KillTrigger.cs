using UnityEngine;

[RequireComponent(typeof(MeshCollider))]

public class KillTrigger : MonoBehaviour
{
    private MeshCollider joe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Killable>().Die();
    }
}
