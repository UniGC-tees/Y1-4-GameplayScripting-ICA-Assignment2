using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killable : MonoBehaviour
{
    [SerializeField] private Transform spawnpoint;

    public void Die()
    {
        Debug.Log("gurt: yo");

        CharacterController controller = GetComponent<CharacterController>();
        
        controller.enabled = false;
        transform.position = spawnpoint.position;
        controller.enabled = true;
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
