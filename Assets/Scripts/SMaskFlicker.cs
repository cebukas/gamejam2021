using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete]
public class SMaskFlicker : MonoBehaviour
{
    [Range(0.05f, 0.2f)]
    public float FlickTime;

    [Range(0.05f, 0.2f)]
    public float AddSize;

    private float _timer = 0;
    private bool _flicked = true;
    
    void Update()
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
