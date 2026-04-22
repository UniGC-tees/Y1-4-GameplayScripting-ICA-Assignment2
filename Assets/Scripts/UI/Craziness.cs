using Unity.VisualScripting;
using UnityEngine;

public class Craziness : MonoBehaviour
{
    [SerializeField] private GameObject mySon;
    [SerializeField] private GameObject lightPrefab;
    public RectTransform CanvasRect;

    private Vector3[] corners;

    private int kids = 0;
    private const int maxKids = 60;

    private void Start()
    {
        CanvasRect = GetComponent<RectTransform>();

        corners = new Vector3[4]
        {
            new(CanvasRect.position.x,-CanvasRect.position.y,0),    //NW
            CanvasRect.position,                                    //NE
            new(-CanvasRect.position.x,CanvasRect.position.y,0),    //SE
            -CanvasRect.position,                                   //SW
        };
    }

    public void GoCrazy()
    {
        InvokeRepeating(nameof(SpawnKid), 0, 1.5f);
    }

    private void SpawnKid()
    {
        GameObject newborn = Instantiate(mySon);
        newborn.GetComponent<BouncyUI>().ownerRectT = CanvasRect;
        newborn.transform.parent = gameObject.transform;

        float randScale = Random.Range(0.7f, 1.3f);
        newborn.transform.localScale = new(randScale, randScale, randScale);
        newborn.transform.localPosition = (corners[Random.Range(0, 3)] * 3) + RandomVector3XY(700);

        kids++;
        if (kids > maxKids)
        {
            //cooked
            GameObject theLight = Instantiate(lightPrefab);
            theLight.transform.parent = gameObject.transform;
            theLight.transform.localPosition = Vector3.zero;

            Destroy(this);
            return;
        }
    }

    private Vector3 RandomVector3XY(int maxOffset)
    {
        return new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset), 0);
    }
}
