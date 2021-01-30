using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IControllable
{
    private bool _opened = false;
    public void Control()
    {
        Open();
    }

    private void Open()
    {
        _opened = !_opened;

        if (_opened)
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
