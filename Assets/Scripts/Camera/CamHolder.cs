using System.Collections;
using UnityEngine;

public class CamHolder : MonoBehaviour
{
    public void ChangeCamOwner(Transform newParent)
    {
        transform.parent = newParent;
        StartCoroutine(TravelToParent());
    }

    private IEnumerator TravelToParent()
    {
        Vector3 start = transform.localPosition;
        Vector3 goal = new(0, 1.375f, 0);
        float alpha = 0;

        while (alpha < 1)
        {
            transform.localPosition = Vector3.Lerp(start, goal, alpha);
            alpha += 0.1f;

            yield return new WaitForSeconds(0.01f);
        }
        transform.localPosition = goal;
    }
}
