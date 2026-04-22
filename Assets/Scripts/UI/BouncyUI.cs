using UnityEngine;

public class BouncyUI : MonoBehaviour
{
    public RectTransform ownerRectT;
    private RectTransform rectT;

    //private Vector3 stpidOffset = new();

    private Vector3 dir = Vector3.zero;
    private float speed = 5.5f;

    private void Start()
    {
        rectT = GetComponentInChildren<RectTransform>();

        speed = Random.Range(3, 6);
    }
    void FixedUpdate()
    {
        if (rectT.position.x > Screen.width) dir.x = -1;    // go right
        if (rectT.position.x < 0) dir.x = 1;                // go left

        if (rectT.position.y > Screen.height) dir.y = -1;   // go down
        if (rectT.position.y < 0) dir.y = 1;                // go up

        rectT.position += dir * speed;
    }
}
