using System;
using Interfaces;
using UnityEngine;

// Do not use this class
// Ball of death needs to be reworked or scrapped completely.

[Obsolete]
public class BallMovement : MonoBehaviour, IInteractable, IControllable
{
    public static event EventHandler PlayerHitBall;
    
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;
    
    [SerializeField]
    private GameObject stone;

    [SerializeField]
    private Animator ballAnimator;

    [SerializeField]
    private bool rolling;

    private Vector3 _position;
    private bool _startRolling;

    private void Start()
    {
        _startRolling = false;
        _position = transform.position;
    }
    
    private void Update()
    {
        if (speed > 0.0f && _startRolling)
        {
            ballAnimator.SetBool("Roll", true);
            rolling = true;
        }
        else
        {
            ballAnimator.SetBool("Roll", false);
            rolling = false;
        }

        if (speed <= 0.0f || (transform.position == _position && _startRolling))
        {
            Destroy(stone);
        }
    }

    private void FixedUpdate()
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

    public void React()
    {
        Debug.Log("Ball should be moving (kinda), that's enough for now");
        _position = target.position;
        rolling = true;
        _startRolling = true;
    }

    public void Interact()
    {
        if (rolling)
        {
            PlayerHitBall.Invoke(this, new EventArgs());
        }
    }
}
