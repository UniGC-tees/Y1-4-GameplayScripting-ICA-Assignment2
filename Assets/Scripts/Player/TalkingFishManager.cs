using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TalkingFishManager : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;

    [SerializeField] private Craziness craziness;
    [SerializeField] private GameObject[] talkers;

    public List<GameObject> arrows = new List<GameObject>();

    private int i = 0;

    public void Next()
    {
        if (i < talkers.Length)
        {
            ActivateTalker(talkers[i]);

            GameObject arrow = Instantiate(arrowPrefab);
            arrowLogic aLog = arrow.GetComponent<arrowLogic>();

            aLog.target.obj = talkers[i];
            aLog.pointer.obj = gameObject;
            aLog.pointer.offset = new(0, 0.6f, 0);

            arrows.Add(arrow);

            i++;
        }
        else Ending();
    }

    private void ActivateTalker(GameObject talker)
    {
        talker.SetActive(true);
        Debug.Log("activated: " + talker.name);
    }

    private void Ending()
    {
        Debug.Log("RUNNING ENDING!!");

        craziness.GoCrazy();
    }
}
