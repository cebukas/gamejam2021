using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hero;
    
    private void Start()
    {
        Time.timeScale = 1.0f;
        GameManager.TimeUp += OnTimeUp;
        Health.DeathFromDamage += OnPlayerDeath;
        FallTrap.PlayerInTrap += OnPlayerDeath;
        BallMovement.PlayerHitBall += OnPlayerDeath;
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        Death("You have died"); //Hardcoded string bad for more languages
    }

    private void OnTimeUp(object sender, EventArgs e)
    {
        Death("Time's up");
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void UnsubscribeFromEvents()
    {
        GameManager.TimeUp -= OnTimeUp;
        Health.DeathFromDamage -= OnPlayerDeath;
        FallTrap.PlayerInTrap -= OnPlayerDeath;
        BallMovement.PlayerHitBall -= OnPlayerDeath;
    }
    
    private void Death(string message)
    {
        Debug.Log("Player Death()");
        hero.transform.GetChild(1).gameObject.GetComponent<Light2D>().enabled = false;
        GameManager.GameOver = true;
        IngameMenu.NotificationText = message;
        hero.GetComponent<Animator>().SetTrigger("Death"); // TODO (Lukas): String ids
        FindObjectOfType<AudioManager>().Play("Lose");
        hero.GetComponent<CharacterMovement>().Freeze();
        GameManager.TimeCountDown = false;
    }
}
