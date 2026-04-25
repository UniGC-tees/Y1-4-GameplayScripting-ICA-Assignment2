using System.Collections;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    [SerializeField] float span;

    public bool shouldDie = true;

    void Start()
    {
        StartCoroutine(WaitForTheSweetEmbraceOfDeathToTakeUsAll());
    }

    private IEnumerator WaitForTheSweetEmbraceOfDeathToTakeUsAll()
    {
        yield return new WaitForSeconds(span);
        if (shouldDie) Destroy(gameObject);
    }
}
