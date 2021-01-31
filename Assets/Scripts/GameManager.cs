using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float TimeLeftInSeconds = 900f;
    public static event EventHandler TimeUp;
    public static bool GameOver = false;

    public static bool TimeCountDown = true;

    private bool _timeUpFired = false;

    private void Start()
    {
        GameOver = false;
        Time.timeScale = 1.0f;
        TimeLeftInSeconds = 900f;
    }

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
