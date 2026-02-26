using UnityEngine;

public class RandomAssetAdd : MonoBehaviour
{
    [SerializeField] private GameObject [] prefabs; 

    void Start()
    {
        Component.Instantiate(prefabs[Random.Range(0,prefabs.Length)], transform);
    }
}