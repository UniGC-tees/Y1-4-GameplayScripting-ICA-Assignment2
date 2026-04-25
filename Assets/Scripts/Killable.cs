using UnityEngine;
using UnityEngine.SceneManagement;

public class Killable : MonoBehaviour
{
    [SerializeField] private GameObject spawnpoint;

    public void Die()
    {
        Debug.Log("gurt: yo");
        //GetComponent<CharacterController>(). = new(0,1000,0);
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
