using TMPro;
using UnityEngine;

public class RandomText : MonoBehaviour
{
    [SerializeField] private string[] randomStrings;
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = randomStrings[Random.Range(0, randomStrings.Length - 1)];
    }
}
