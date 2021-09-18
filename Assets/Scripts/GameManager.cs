using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event EventHandler TimeUp;
    public static bool GameOver = false;
    public static bool TimeCountDown = true;

    private bool _timeUpFired = false;

    public float timeLeftInSeconds = 900f;
    public static bool Win { get; internal set; }

    private void Start()
    {
        Win = false;
        GameOver = false;
        Time.timeScale = 1.0f;
        timeLeftInSeconds = 900f;
    }

    private void Update()
    {
        decreaseTime();
    }

    private void decreaseTime()
    {
        if (!TimeCountDown) return;
        timeLeftInSeconds -= Time.deltaTime;
        if (timeLeftInSeconds >= 0 || _timeUpFired) return;
        // Start Time's up sequence
        TimeUp?.Invoke(this, new EventArgs());
        _timeUpFired = true;
    }
}
