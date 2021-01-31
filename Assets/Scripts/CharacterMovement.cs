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
    private float speedX;
    private float speedY;
    private float speedXPositive;
    private float speedYPositive;
    void Update()
    {
        // Read Player input
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");

        if (_interactionAvailable)
        {

            if (Input.GetKeyDown(InteractButton))
            {
                InvokeInteraction();
            }
        }
    }

    private void Start()
    {
        _frozenMovement = false;
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
        speedX = GetComponent<Rigidbody2D>().velocity.x;
        speedY = GetComponent<Rigidbody2D>().velocity.y;

        speedXPositive = speedX;
        speedYPositive = speedY;

        if (speedX < 0)
            speedXPositive = speedX * -1;
        if (speedY < 0)
            speedYPositive = speedY * -1;

        setAnimatorConditions(false, false, false, false);

        if (speedX <= -0.01f && speedX * (-1f) >= speedYPositive)
        {
            setAnimatorConditions(false, false, false, true);
        }
        if (speedX >= 0.01f && speedX >= speedYPositive)
        {
            setAnimatorConditions(false, true, false, false);
        }
        if (speedY >= 0.01f && speedY >= speedXPositive)
        {
            setAnimatorConditions(true, false, false, false);
        }
        if (speedY <= -0.01f && speedY * (-1f) >= speedXPositive)
        {
            setAnimatorConditions(true, false, true, false);
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
            IngameMenu.NotificationText = $"Press {InteractButton.ToString()}";
            _interactableGO = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            collision.gameObject.GetComponent<IInteractable>().Interact();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactionAvailable = false;
            IngameMenu.NotificationText = "";
            _interactableGO = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactionAvailable = true;
            IngameMenu.NotificationText = $"Press {InteractButton.ToString()}";
            _interactableGO = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            collision.gameObject.GetComponent<IInteractable>().Interact();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactionAvailable = false;
            IngameMenu.NotificationText = "";
            _interactableGO = null;
        }
    }
    private void setAnimatorConditions(bool runUp, bool runRight, bool runDown, bool runLeft)
    {
        animator.SetBool("RunRight", runRight);
        animator.SetBool("RunLeft", runLeft);
        animator.SetBool("RunUp", runUp);
        animator.SetBool("RunDown", runDown);
    }
}
