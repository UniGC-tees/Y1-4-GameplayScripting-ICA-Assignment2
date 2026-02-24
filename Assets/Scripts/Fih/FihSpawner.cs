using UnityEditor;
using UnityEngine;

public class FihSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fihToSpawn;
    [SerializeField] private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnFih), timer, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFih()
    {
        Debug.Log("im lit spawning a fih");

        Instantiate(fihToSpawn, transform);
    }
}
