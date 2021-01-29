using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float DiagonalMovementSpeedCoeff = 0.7f;
    public float MovementSpeed = 10f;

    public KeyCode InteractButton = KeyCode.E;

    private float _inputX;
    private float _inputY;
    void Update()
    {
        // Read Player input
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");

        if(Input.GetKey(InteractButton))
        {
            InvokeInteraction();
        }
    }

    private void FixedUpdate()
    {
        CheckInteraction();

        if (_inputX != 0 && _inputY != 0)
        {
            // Movement is diagonal
            _inputX *= DiagonalMovementSpeedCoeff;
            _inputY *= DiagonalMovementSpeedCoeff;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(_inputX * MovementSpeed, _inputY * MovementSpeed);
    }

    private void CheckInteraction()
    {
        // Launch 4 RayCasts, check if one of them hits interactable
    }

    private void InvokeInteraction()
    {
        Debug.Log("Still not implemented!");
    }
}
