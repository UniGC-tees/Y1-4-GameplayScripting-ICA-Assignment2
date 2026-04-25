using System.Collections;
using UnityEngine;

public class arrowLogic : MonoBehaviour
{
    [System.Serializable] public struct GameObjectOffset
    {
        public GameObject obj;
        public Vector3 offset;
    }

    public GameObjectOffset pointer;
    public GameObjectOffset target;

    private void Start()
    {
        StartCoroutine(Bouncing());
    }

    private void Update()
    {
        if (target.obj != null) transform.LookAt(target.obj.transform.position + target.offset);
    }

    private IEnumerator Bouncing()
    {
        GameObjectOffset travelingTo = target;
        GameObjectOffset travelingFrom = pointer;

        GameObjectOffset temp;

        float lerpA = 0.2f;

        while (true)
        {
            transform.localPosition = Vector3.Lerp(travelingFrom.obj.transform.position + travelingFrom.offset, travelingTo.obj.transform.position + travelingTo.offset, lerpA);

            lerpA += 0.01f;

            if (lerpA > 0.8f)
            {
                temp = travelingTo;
                travelingTo = travelingFrom;
                travelingFrom = temp;

                lerpA = 0.2f;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
