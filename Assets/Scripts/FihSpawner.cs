using UnityEngine;

public class FihSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnFih), 6, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFih()
    {
        Debug.Log("im lit spawning a fih");
    }
}
