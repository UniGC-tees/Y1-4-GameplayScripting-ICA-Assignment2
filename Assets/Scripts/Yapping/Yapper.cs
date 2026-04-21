using System.Collections;
using TMPro;
using UnityEngine;

public class Yapper : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public string[] yap;

    private void Start()
    {
        StartCoroutine(AllIDoIsYap());
    }

    private IEnumerator AllIDoIsYap()
    {
        int i = 0;

        while (true)
        {
            tmp.text = yap[i];

            if (i < yap.Length - 1) i++;
            else i = 0;

            yield return new WaitForSeconds(3);
        }
    }
}
