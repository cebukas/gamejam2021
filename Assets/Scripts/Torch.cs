using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Sprite _torchLit;

    [SerializeField]
    private Sprite _torchUnlit;

    private bool _torchIsLit = false;

    [SerializeField]
    private GameObject _lightSource;
    
    public void Interact()
    {
        SwitchState();
    }

    private void SwitchState()
    {
        _torchIsLit = !_torchIsLit;
        if (_torchIsLit)
        {
            _lightSource.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = _torchLit;
        }
        else
        {
            _lightSource.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = _torchUnlit;
        }
    }

    public void Start()
    {
        _lightSource.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = _torchUnlit;
        _torchIsLit = false;
    }
}
