using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private KeyCode interactButton = KeyCode.E;
    [SerializeField]
    private Animator animator;

    private bool _frozenMovement = false;
    private bool _interactionAvailable = false;
    private GameObject _interactableGO = null;
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    
    private void Start()
    {
        _frozenMovement = false;
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        //TODO (Lukas): String ids
        animator.SetFloat("Horizontal", _movement.x);
        animator.SetFloat("Vertical", _movement.y);
        animator.SetFloat("Speed", _movement.sqrMagnitude);
        if (_interactionAvailable)
        {
            if (Input.GetKeyDown(interactButton))
            {
                InvokeInteraction();
            }
        }
        
        if(GameManager.Win)
        {
            Freeze();
        }
    }

    private void FixedUpdate()
    {
        if(!GetComponent<AudioSource>().isPlaying){
                GetComponent<AudioSource>().Play();
        }
        if(_movement.x == 0 && _movement.y == 0){
               GetComponent<AudioSource>().Stop();
        }

        if (!_frozenMovement)
        {
            _rigidbody.velocity = new Vector2(_movement.x * speed, _movement.y * speed);
        } else
        {
            _movement.x = 0f;
            _movement.y = 0f;
            _rigidbody.velocity = _movement;
        }
    }

    private void InvokeInteraction()
    {
        if (_interactableGO == null) return;
        var interactable = _interactableGO.GetComponent<IInteractable>();
        interactable.Interact();
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
            IngameMenu.NotificationText = $"Press {interactButton.ToString()}";
            _interactableGO = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            collision.gameObject.GetComponent<IInteractable>().Interact();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Interactable")) return;
        _interactionAvailable = false;
        IngameMenu.NotificationText = "";
        _interactableGO = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            _interactionAvailable = true;
            IngameMenu.NotificationText = $"Press {interactButton.ToString()}";
            _interactableGO = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            collision.gameObject.GetComponent<IInteractable>().Interact();
        }

        if (collision.gameObject.CompareTag("Ghost"))
        {
            GetComponent<Health>().DoDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Interactable")) return;
        _interactionAvailable = false;
        IngameMenu.NotificationText = "";
        _interactableGO = null;
    }
}
