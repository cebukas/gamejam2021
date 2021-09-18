using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event EventHandler TimeUp;
    public static bool GameOver = false;
    public static bool TimeCountDown = true;

    public float TimeLeftInSeconds = 900f;

    private bool _timeUpFired = false;

    public static bool Win { get; internal set; }

    private void Start()
    {
        Win = false;
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
                TimeUp?.Invoke(this, new EventArgs());
                _timeUpFired = true;
            }
        }
    }
}
