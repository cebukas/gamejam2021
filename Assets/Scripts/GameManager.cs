using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float TimeLeftInSeconds = 900f;
    public static event EventHandler TimeUp;

    private bool _timeUpFired = false;

    void Update()
    {
        TimeLeftInSeconds -= Time.deltaTime;
        if(TimeLeftInSeconds <= 0 && !_timeUpFired)
        {
            // Start Time's up sequence
            TimeUp.Invoke(this, new EventArgs());
            _timeUpFired = true;
        }
    }
}
