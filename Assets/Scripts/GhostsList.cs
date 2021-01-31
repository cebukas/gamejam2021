using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsList : MonoBehaviour
{
    public List<GameObject> objs;
    public List<float> waitTime;
    private List<float> _waitTime;
    // Start is called before the first frame update
    void Start()
    {
        _waitTime = new List<float>(waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objs.Capacity; i++)
        {
            _waitTime[i] -= Time.deltaTime;
            if(_waitTime[i] <= 0) {
                objs[i].SetActive(true);
                _waitTime[i] = waitTime[i];
            }
        }
    }
}
