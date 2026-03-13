using UnityEngine;

public class Shrink : MonoBehaviour
{
    private float modifier = 1;
    public bool done = false;

    void Update()
    {
        transform.localScale *= modifier;

        modifier -= 0.001f * Time.deltaTime;

        if (modifier <= 0.99474 )
        {
            done = true;
        }
    }
}
