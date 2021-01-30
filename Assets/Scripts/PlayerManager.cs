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
    }

    private void Health_DeathFromDamage(object sender, EventArgs e)
    {
        IngameMenu.NotificationText = "You have died!";
        GameManager.GameOver = true;
        Hero.GetComponent<CharacterMovement>().Freeze();
        Time.timeScale = 0.0f;
        FindObjectOfType<AudioManager>().Play("Lose");
    }

    private void GameManager_TimeUp(object sender, EventArgs e)
    {
        GameManager.GameOver = true;
        IngameMenu.NotificationText = "Time's up!";
        Hero.GetComponent<CharacterMovement>().Freeze();
        Time.timeScale = 0.0f;
    }
}
