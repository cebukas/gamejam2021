using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float Speed = 10f;
    public KeyCode InteractButton = KeyCode.E;

    private bool _frozenMovement = false;
    private bool _interactionAvailable = false;
    private GameObject _interactableGO = null;
    private Rigidbody2D _rigidbody;

    public Animator animator;
    private Vector2 movement;
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (_interactionAvailable)
        {
            if (Input.GetKeyDown(InteractButton))
            {
                InvokeInteraction();
            }
        }
        
        if(GameManager.Win)
        {
            Freeze();
        }
    }

    private void Start()
    {
        _frozenMovement = false;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(!GetComponent<AudioSource>().isPlaying){
                GetComponent<AudioSource>().Play();
        }
        if(movement.x == 0 && movement.y == 0){
               GetComponent<AudioSource>().Stop();
        }

        if (!_frozenMovement)
        {
            _rigidbody.velocity = new Vector2(movement.x * Speed, movement.y * Speed);
        } else
        {
            movement.x = 0f;
            movement.y = 0f;
            _rigidbody.velocity = movement;
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
}
