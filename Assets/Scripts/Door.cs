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
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
