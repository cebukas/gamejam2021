using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public GameObject Hero;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.TimeUp += GameManager_TimeUp;
        Health.DeathFromDamage += Health_DeathFromDamage;
    }

    private void Health_DeathFromDamage(object sender, EventArgs e)
    {
        Hero.GetComponent<CharacterMovement>().Freeze();
    }

    private void GameManager_TimeUp(object sender, EventArgs e)
    {
        Hero.GetComponent<CharacterMovement>().Freeze();
    }
}
