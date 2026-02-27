using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rate = 1;
    private void FixedUpdate()
    {
       gameObject.transform.eulerAngles = new Vector3 (gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + rate, gameObject.transform.eulerAngles.z); 
    }
}
