using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public GameObject ControlledGameObject;

    private bool _leverEnabled = false;

    [SerializeField]
    private Sprite _leverDown;

    [SerializeField]
    private Sprite _leverUp;

    public void Interact()
    {
        SwitchState();
     
        if (ControlledGameObject != null)
        {
            ControlledGameObject.GetComponent<IControllable>().Control();
        }
        else
        {
            Debug.LogWarning("Lever doesn't control anything");
        }
    }

    private void SwitchState()
    {
        _leverEnabled = !_leverEnabled;
        if(_leverEnabled)
        {
            GetComponent<SpriteRenderer>().sprite = _leverDown;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = _leverUp;
        }
    }
}
