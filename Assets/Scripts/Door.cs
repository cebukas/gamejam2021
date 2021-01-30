using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IControllable
{
    public bool Opened;

    void Start()
    {
        FlipOpen();
    }

    public void Control()
    {
        FlipOpen();
    }

    private void FlipOpen()
    {
        Opened = !Opened;

        if (Opened)
        {
            foreach(var s in GetComponentsInChildren<SpriteRenderer>())
                s.enabled = false;
            foreach(var c in GetComponentsInChildren<Collider2D>())
                c.isTrigger = true;
        }
        else
        {
            foreach(var s in GetComponentsInChildren<SpriteRenderer>())
                s.enabled = true;
            foreach(var c in GetComponentsInChildren<Collider2D>())
                c.isTrigger = false;
        }
    }
}
