using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingLight : MonoBehaviour
{
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        var rotZ = GetAnglesBetweenCenterAndMousePosition();
        transform.eulerAngles = new Vector3(0f, 0f, rotZ);
    }

    // Update is called once per frame
    void Update()
    {
        var rotZ = GetAnglesBetweenCenterAndMousePosition();
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    // return angles needed to rotate light
    private float GetAnglesBetweenCenterAndMousePosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        mousePos.Normalize();
        return Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
    }
}
