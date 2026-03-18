using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MeshCollider))]

public class Crashable : MonoBehaviour
{
    private MeshCollider col;
    public Object gurt;

    void Start()
    {
        col = GetComponent<MeshCollider>();
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
        GetComponent<MeshRenderer>().enabled = false;
    }
}
