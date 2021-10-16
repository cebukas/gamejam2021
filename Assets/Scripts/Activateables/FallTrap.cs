using System;
using Interactables;
using UnityEngine;

public class FallTrap : MonoBehaviour, IActivable
{
    public static event EventHandler PlayerInTrap;

    public void Activate()
    {
        //TODO: Remove the event when Player object is reworked.
        PlayerInTrap?.Invoke(null, null); 
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Activate();
        }
    }

}
