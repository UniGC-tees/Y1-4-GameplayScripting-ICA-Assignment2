using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MeshCollider))]

public class Crashable : MonoBehaviour
{

    private MeshCollider col;
    public Object gurt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("mewo");
        Instantiate(gurt, transform);
        Invoke(nameof(HideMesh), 0.2f);
        Invoke(nameof(LoadGameScene), 2);
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("game");
    }

    private void HideMesh()
    {
        // gameObject.SetActive(false);
        GetComponent<MeshRenderer>().enabled = false;
    }
}
