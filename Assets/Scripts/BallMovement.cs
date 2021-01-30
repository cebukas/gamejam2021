using UnityEngine;

public class BallMovement : MonoBehaviour
{
     public Transform target;
     public float speed;
     public bool isAccelerating;
     private Vector3 position;

     public void Start(){
        position = target.position;
     }
 
     void FixedUpdate(){
        transform.LookAt(position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, position) > 1f){ //move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0) );
        }

        if (isAccelerating)
         speed += Time.deltaTime * 3;
    }
}
