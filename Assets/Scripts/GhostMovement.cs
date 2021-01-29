 using UnityEngine;
 
 public class GhostMovement : MonoBehaviour {
 
     public Transform target;
     public float speed;
     public float lifeTime;
 
     void FixedUpdate(){
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, target.position) > 1f){ //move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0) );
        }


        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0){
            Destroy(this.gameObject);
        }

    }
 
}