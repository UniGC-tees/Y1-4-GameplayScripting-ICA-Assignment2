using UnityEngine;

public class TalkingFishManager : MonoBehaviour
{
    [SerializeField] private Craziness craziness;
    [SerializeField] private GameObject[] talkers;

    private int i = 0;

    public void Next()
    {
        if (i < talkers.Length)
        {
            ActivateTalker(talkers[i]);
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
