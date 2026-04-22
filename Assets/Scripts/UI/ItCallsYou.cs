using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItCallsYou : MonoBehaviour
{
    private RawImage img;

    private void Start()
    {
        img = GetComponent<RawImage>();
        StartCoroutine(BeconingLight());
    }

    private IEnumerator BeconingLight()
    {
        float alpha = 0;

        Debug.Log("here comes the sun.. dodododo");
        while (alpha < 1)
        {
            img.color = new(img.color.r, img.color.g, img.color.b, alpha);

            alpha += 0.0025f;

            yield return new WaitForSeconds(0.04f);
        }
        img.color = Color.white;
        Debug.Log("then the player poofs");
        Application.Quit();
    }
}
