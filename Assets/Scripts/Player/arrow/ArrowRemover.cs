using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ArrowRemover : MonoBehaviour
{
    private SphereCollider guhCollider;

    private List<GameObject> arrowsToRemoveAfter = new List<GameObject>();


    private void Start()
    {
        guhCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OVERLAP!!");

        if (collision.gameObject.TryGetComponent<TalkingFishManager>(out TalkingFishManager tfm))
        {
            Debug.Log("YOU ARE THE PLAYER!!??");
            foreach (GameObject arrow in tfm.arrows)
            {
                if (arrow.GetComponent<arrowLogic>().target.obj.name == gameObject.name)
                {
                    Debug.Log("MARKING ARROW FOR DEATH");
                    arrowsToRemoveAfter.Add(arrow);
                }
            }
            foreach (GameObject arrow in arrowsToRemoveAfter)
            {
                tfm.arrows.Remove(arrow);
                Destroy(arrow);
            }
            arrowsToRemoveAfter.Clear();

            Destroy(guhCollider);
        }
    }
}
