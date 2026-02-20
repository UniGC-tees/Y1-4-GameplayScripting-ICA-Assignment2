using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MeshCollider))]

public class Crashable : MonoBehaviour
{

    private MeshCollider collider;
    public Object gurt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("mewo");
        Instantiate(gurt, transform);
        Invoke(nameof(LoadGameScene), 2);
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("game");
    }
}
