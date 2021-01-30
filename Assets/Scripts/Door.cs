using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IControllable
{
    public void Control()
    {
        Debug.Log("Door is controlled!");
    }
}
