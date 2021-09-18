using System.Collections.Generic;
using UnityEngine;

public class GhostsList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objs;
    [SerializeField]
    private List<float> waitTime;
    
    private List<float> _waitTime;

    void Start()
    {
        _waitTime = new List<float>(waitTime);
    }

    void Update()
    {
        for (var i = 0; i < objs.Capacity; i++)
        {
            _waitTime[i] -= Time.deltaTime;
            if (!(_waitTime[i] <= 0)) continue;
            objs[i].SetActive(true);
            _waitTime[i] = waitTime[i];
        }
    }
}
