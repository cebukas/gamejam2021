using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // subtracting the position of the player from the mouse mous position 
        Debug.Log("Text");
        difference.Normalize(); // normalizing the vector. meaning that all the sum of the vector will be equal to 1
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //find the angle in degrees
        transform.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90 );

 }
}
