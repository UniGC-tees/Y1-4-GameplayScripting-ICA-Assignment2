using UnityEngine;

public class FaceThis : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        transform.eulerAngles = target.transform.eulerAngles;
    }
}