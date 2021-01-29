using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float TimeLeftInSeconds = 900f;

    public GameObject Hero;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeftInSeconds -= Time.deltaTime;
        if(TimeLeftInSeconds <= 0)
        {
            // Start Time's up sequence
            Debug.Log("Oy, Time's up!");
        }
    }
}
