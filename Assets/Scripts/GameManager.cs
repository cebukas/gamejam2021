using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //TODO: Show timer in UI
    public static float TimeLeftInSeconds = 900f;
    public static event EventHandler TimeUp;
    public bool TimeCountDown = true;

    private bool _timeUpFired = false;

    void Update()
    {
        if (TimeCountDown)
        {
            TimeLeftInSeconds -= Time.deltaTime;
            if (TimeLeftInSeconds <= 0 && !_timeUpFired)
            {
                // Start Time's up sequence
                TimeUp.Invoke(this, new EventArgs());
                _timeUpFired = true;
            }
        }
    }
}
