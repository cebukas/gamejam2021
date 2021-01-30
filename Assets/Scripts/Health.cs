using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private float covidDelay;
    public void DoDamage(){
        health--;
        if(health == 0){
            Debug.Log("playing dope - die mf die ");
        }
    }
    public void Heal(){
        if(health != 3)
            health++;
    }
}
