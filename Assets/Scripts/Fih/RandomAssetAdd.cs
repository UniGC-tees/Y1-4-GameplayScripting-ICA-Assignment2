using UnityEngine;

public class RandomAssetAdd : MonoBehaviour
{

    [SerializeField] private GameObject [] prefabs; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        Component.Instantiate(prefabs[Random.Range(0,prefabs.Length)], transform);
    }
}
