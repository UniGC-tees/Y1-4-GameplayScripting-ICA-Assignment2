using UnityEditor;
using UnityEngine;

public class FihSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fihToSpawn;
    [SerializeField] private GameObject spawnParticle;
    [SerializeField] private float startTime;
    [SerializeField] private float timer;
    private GameObject lastSpawnedFih;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFih), startTime, timer);
    }

    void SpawnFih()
    {
        lastSpawnedFih = Instantiate(fihToSpawn, transform);
        lastSpawnedFih.transform.eulerAngles = new Vector3(0, Random.Range(-180,180), 0);

        Instantiate(spawnParticle, lastSpawnedFih.transform);
    }
}
