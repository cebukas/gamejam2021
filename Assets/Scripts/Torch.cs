using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, IInteractable
{
    [Range(0.05f, 0.2f)]
    public float FlickTime;

    [Range(0.05f, 0.2f)]
    public float AddSize;

    private float _timer = 0;
    private bool _flicked = true;

    [SerializeField]
    private Sprite _torchLit;

    [SerializeField]
    private Sprite _torchUnlit;

    private bool _torchIsLit = false;
    
    [SerializeField]
    private GameObject _sMask;

    public void Interact()
    {
        SwitchState();
    }

    private void SwitchState()
    {
        _torchIsLit = !_torchIsLit;
        if (_torchIsLit)
        {
            GetComponent<SpriteRenderer>().sprite = _torchLit;
            _sMask.SetActive(true);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = _torchUnlit;
            _sMask.SetActive(false);
        }
    }

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _torchUnlit;
        _torchIsLit = false;
        _sMask.SetActive(false);
    }

    public void Update()
    {
        if (_torchIsLit)
        {
            _timer += Time.deltaTime;

            if (_timer > FlickTime)
            {
                if (_flicked)
                {
                    transform.localScale = new Vector3(transform.localScale.x + AddSize, transform.localScale.y + AddSize, transform.localScale.z);
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x - AddSize, transform.localScale.y - AddSize, transform.localScale.z);
                }

                _timer = 0;
                _flicked = !_flicked;
            }
        }
    }
}
