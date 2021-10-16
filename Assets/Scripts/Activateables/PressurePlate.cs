using System;
using Interactables;
using Interfaces;
using UnityEngine;

public class PressurePlate : MonoBehaviour, IActivable
{
    [SerializeField]
    private GameObject controlledGameObject;

    private bool _pressureApplied = false;

    public void Activate()
    {
        Debug.Log("Pressure plate activates stuff");
        if (controlledGameObject != null && !_pressureApplied)
        {
            controlledGameObject.GetComponent<IControllable>().React();
            _pressureApplied = true;
        }
        else if (controlledGameObject == null)
        {
            Debug.LogWarning("Pressure plate doesn't control anything");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Activate();
        }
    }
}
