using UnityEditor;
using UnityEngine;

public class FihSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fihToSpawn;
    [SerializeField] private float timer;
    private GameObject lastSpawnedFih;

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

        lastSpawnedFih = Instantiate(fihToSpawn, transform);
        lastSpawnedFih.transform.eulerAngles = new Vector3(0, Random.Range(-180,180), 0);
    }
}
