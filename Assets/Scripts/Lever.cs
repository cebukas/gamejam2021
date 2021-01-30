using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public GameObject[] ControlledGameObjects;

    private bool _leverEnabled = false;

    [SerializeField]
    private Sprite _leverDown;

    [SerializeField]
    private Sprite _leverUp;

    public void Interact()
    {
        SwitchState();

        if (ControlledGameObjects != null)
        {
            foreach(var controlledObject in ControlledGameObjects)
            {
                controlledObject.GetComponent<IControllable>().Control();
            }
        }
        else
        {
            Debug.LogWarning("Lever doesn't control anything");
        }
    }

    private void SwitchState()
    {
        _leverEnabled = !_leverEnabled;
        if (_leverEnabled)
        {
            GetComponent<SpriteRenderer>().sprite = _leverDown;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = _leverUp;
        }
    }
}
