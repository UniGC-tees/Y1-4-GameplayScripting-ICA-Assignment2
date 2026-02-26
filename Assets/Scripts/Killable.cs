using UnityEngine;
using UnityEngine.SceneManagement;

public class Killable : MonoBehaviour
{
    public void Die()
    {
        Debug.Log("gurt: yo");
        ReloadScene();
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
