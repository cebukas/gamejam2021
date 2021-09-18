using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event EventHandler DeathFromDamage;
    
    [SerializeField]
    private int health;

    private float _covidDelay;

    public void DoDamage()
    {
        if (health <= 0) return;
        FindObjectOfType<AudioManager>().Play("Damage");
        health--;
        if (health != 0) return;
        Debug.Log("playing dope - die mf die ");
        DeathFromDamage?.Invoke(this, new EventArgs());
    }

    public void Heal()
    {
        if(health != 3)
        {
            health++;
        }
    }

    internal int GetHealth()
    {
        return health;
    }
}
