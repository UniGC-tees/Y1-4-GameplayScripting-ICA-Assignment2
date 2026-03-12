using Unity.VisualScripting;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] private GameObject bobber;

    private GameObject currentBobber;

    void OnClick()
    {
        if (currentBobber == null)
        {
            currentBobber = Instantiate(bobber, transform.position + (transform.forward * 1) + new Vector3(0,2,0), transform.rotation);
        }
    }

    void OnRightClick()
    {
        if (currentBobber  != null)
        {
            Destroy(currentBobber);
            currentBobber = null;
        }
    }
}