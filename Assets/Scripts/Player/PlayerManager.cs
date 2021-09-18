using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Hero;

    void Start()
    {
        Time.timeScale = 1.0f;
        GameManager.TimeUp += OnTimeUp;
        Health.DeathFromDamage += OnPlayerDeath;
        FallTrap.PlayerInTrap += OnPlayerDeath;
        BallMovement.PlayerHitBall += OnPlayerDeath;
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        Death("You have died");
    }

    private void OnTimeUp(object sender, EventArgs e)
    {
        Death("Time's up");
    }
    
    private void Death(string message)
    {
        Hero.transform.GetChild(1).gameObject.GetComponent<Light2D>().enabled = false;
        Hero.transform.GetChild(2).gameObject.GetComponent<Light2D>().enabled = false;
        GameManager.GameOver = true;
        IngameMenu.NotificationText = message;
        Hero.GetComponent<Animator>().SetTrigger("Death"); // TODO (Lukas): String ids
        FindObjectOfType<AudioManager>().Play("Lose");
        Hero.GetComponent<CharacterMovement>().Freeze();
        GameManager.TimeCountDown = false;
    }
}
