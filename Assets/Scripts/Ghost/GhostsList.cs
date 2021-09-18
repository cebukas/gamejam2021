using System.Collections.Generic;
using UnityEngine;

public class GhostsList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objs;
    [SerializeField]
    private List<float> waitTime;

    private void Update()
    {
        for (var i = 0; i < objs.Capacity; i++)
        {
            waitTime[i] -= Time.deltaTime;
            if (!(waitTime[i] <= 0)) continue;
            objs[i].SetActive(true);
            waitTime[i] = waitTime[i];
        }
    }
}
