using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour, IInteractable
{
    public static event EventHandler PlayerInTrap;

    private bool _trapFired = false;

    public void Interact()
    {
        if(!_trapFired)
        {
            PlayerInTrap.Invoke(this, new EventArgs());
        }
    }
}
