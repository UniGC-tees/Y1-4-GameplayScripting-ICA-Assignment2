using UnityEngine;

public class Swim : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + 10, 0);

        transform.position += -transform.forward*0.1f;
    }
}
