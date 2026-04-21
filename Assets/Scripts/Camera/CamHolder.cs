using UnityEngine;

public class CamHolder : MonoBehaviour
{
    public void ChangeCamOwner(Transform newParent)
    {
        transform.parent = newParent;
        transform.localPosition = new Vector3(0, 1.375f, 0);
    }
}
