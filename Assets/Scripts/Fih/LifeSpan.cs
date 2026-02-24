using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    [SerializeField] float span;
    void Start()
    {
        Destroy(gameObject, span);
    }
}
