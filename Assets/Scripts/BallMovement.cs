using System;
using UnityEngine;

public class BallMovement : MonoBehaviour, IInteractable, IControllable
{
    public Transform target;
    public float speed;
    private Vector3 position;

    public GameObject Stone;

    public static event EventHandler PlayerHitBall;

    public Animator BallAnimator;

    public bool Rolling;

    private bool _startRolling;

    public void Start()
    {
        _startRolling = false;
        position = transform.position;
    }

    public void Control()
    {
        position = target.position;
        Rolling = true;
        _startRolling = true;
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

        if (speed <= 0.0f || (transform.position == position && _startRolling))
        {
            Destroy(Stone);
        }
    }

    void FixedUpdate()
    {
        transform.LookAt(position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, position) > 1f)
        { //move if distance from target is greater than 1
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
