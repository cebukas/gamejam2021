﻿using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject objectToFollow;
    
    public float speed = 2.0f;
    
    void Update () {
        float interpolation = speed * Time.deltaTime; // oh boi
        
        Vector3 position = this.transform.position; // oooh boi
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
        
        this.transform.position = position;
    }
}