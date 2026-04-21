using UnityEngine;

public class FaceThis : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        if (target == null)
        {
            Debug.Log("FACE THIS: TARGET IS NULL!!! SET THE TARGET SILLY!!!!");
            return;
        }

        transform.eulerAngles = target.transform.eulerAngles;
    }
}