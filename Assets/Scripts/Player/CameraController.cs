using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject objectToFollow;
    
    public float speed = 2.0f;
    
    private void Update () {
        var interpolation = speed * Time.deltaTime; // oh boi
        
        var position = transform.position; // oooh boi
        position.y = Mathf.Lerp(transform.position.y, objectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(transform.position.x, objectToFollow.transform.position.x, interpolation);
        
        transform.position = position;
    }
}