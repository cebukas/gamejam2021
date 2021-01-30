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
        Time.timeScale = 1.0f;
        GameManager.TimeUp += GameManager_TimeUp;
        Health.DeathFromDamage += Health_DeathFromDamage;
        FallTrap.PlayerInTrap += FallTrap_PlayerInTrap;
    }

    private void FallTrap_PlayerInTrap(object sender, EventArgs e)
    {
        Death("You have died!");
    }

    private void Health_DeathFromDamage(object sender, EventArgs e)
    {
        Death("You have died!");
    }

    private void GameManager_TimeUp(object sender, EventArgs e)
    {
        Death("Time's up!");
    }

    private void Death(string message)
    {
        GameManager.GameOver = true;
        IngameMenu.NotificationText = message;
        Hero.GetComponent<Animator>().SetTrigger("Death");
        FindObjectOfType<AudioManager>().Play("Lose");
        Hero.GetComponent<CharacterMovement>().Freeze();
        GameManager.TimeCountDown = false;
    }
}
