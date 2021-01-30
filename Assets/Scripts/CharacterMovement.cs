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

    private bool _frozenMovement = false;
    private bool _interactionAvailable = false;
    private GameObject _interactableGO = null;
    public Animator animator;

    void Update()
    {
        // Read Player input
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");

        if (_interactionAvailable)
        {
            //TODO: Show "Press E" in the UI
            Debug.Log($"Press {InteractButton.ToString()}");

            if (Input.GetKeyDown(InteractButton))
            {
                InvokeInteraction();
            }
        }
        animator.SetFloat("SpeedX", GetComponent<Rigidbody2D>().velocity.x);
        animator.SetFloat("SpeedY", GetComponent<Rigidbody2D>().velocity.y);
    }

    private void FixedUpdate()
    {
        if (_inputX != 0 && _inputY != 0)
        {
            // Movement is diagonal
            _inputX *= DiagonalMovementSpeedCoeff;
            _inputY *= DiagonalMovementSpeedCoeff;
        }

        if (!_frozenMovement)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(_inputX * MovementSpeed, _inputY * MovementSpeed);
        }
        else
        {
            _inputX = 0f;
            _inputY = 0f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
    }

    private void InvokeInteraction()
    {
        if (_interactableGO != null)
        {
            var interactable = _interactableGO.GetComponent<IInteractable>();
            interactable.Interact();
        }
    }

    public void Freeze()
    {
        _frozenMovement = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactionAvailable = true;
            _interactableGO = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactionAvailable = false;
            _interactableGO = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactionAvailable = true;
            _interactableGO = collision.gameObject;
        }

        if(collision.gameObject.CompareTag("Trap"))
        {
            collision.gameObject.GetComponent<IInteractable>().Interact();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactionAvailable = false;
            _interactableGO = null;
        }
    }
}
