using System;
using UnityEngine;

public class BallMovement : MonoBehaviour, IInteractable, IControllable
{
    public static event EventHandler PlayerHitBall;
    
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;
    
    [SerializeField]
    private GameObject Stone;

    [SerializeField]
    private Animator BallAnimator;

    [SerializeField]
    private bool Rolling;

    private Vector3 _position;
    
    private bool _startRolling;

    public void Start()
    {
        _startRolling = false;
        _position = transform.position;
    }
    
    private void Update()
    {
        if (speed > 0.0f && _startRolling)
        {
            BallAnimator.SetBool("Roll", true);
            Rolling = true;
        }
        else
        {
            BallAnimator.SetBool("Roll", false);
            Rolling = false;
        }

        if (speed <= 0.0f || (transform.position == _position && _startRolling))
        {
            Destroy(Stone);
        }
    }

    public void Control()
    {
        _position = target.position;
        Rolling = true;
        _startRolling = true;
    }

    void FixedUpdate()
    {
        transform.LookAt(_position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, _position) > 1f)
        { 
            //move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        if (speed >= 0.0f && _startRolling)
            speed -= Time.deltaTime;
    }

    public void Interact()
    {
        if (Rolling)
        {
            PlayerHitBall.Invoke(this, new EventArgs());
        }
    }
}
