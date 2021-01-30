using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public Tilemap DarkMap;
    public Tilemap BlurredMap;
    public Tilemap BackgroundMap;
    public Tilemap WallMap;

    public Tile DarkTile;
    public Tile BlurredTile;

    //TODO: Show timer in UI
    public static float TimeLeftInSeconds = 900f;
    public static event EventHandler TimeUp;
    public bool TimeCountDown = true;

    private bool _timeUpFired = false;

    private void Start()
    {
        DarkMap.origin = BlurredMap.origin = BackgroundMap.origin = WallMap.origin;
        DarkMap.size = BlurredMap.size = BackgroundMap.size = WallMap.size;

        foreach (var p in DarkMap.cellBounds.allPositionsWithin)
        {
            DarkMap.SetTile(p, DarkTile);
        }

        foreach (var p in BlurredMap.cellBounds.allPositionsWithin)
        {
            BlurredMap.SetTile(p, BlurredTile);
        }
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
