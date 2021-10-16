/*
 * This Class must contains data about player life status - is he dead or alive, what should
 * happen with the player on level start etc.
 */

using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField] 
    private GameObject Spawner;

    private void Start()
    {
        Time.timeScale = 1.0f;
        // Maybe invert these events? Instead of subscribing to them, make these objects affect PlayerManager?
        GameManager.TimeUp += OnTimeUp;
        Health.DeathFromDamage += OnPlayerDeath;
        FallTrap.PlayerInTrap += OnPlayerDeath;
        BallMovement.PlayerHitBall += OnPlayerDeath;
        PutOnSpawner();
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        Death("You have died"); //Hardcoded string bad for more languages
    }

    private void OnTimeUp(object sender, EventArgs e)
    {
        Death("Time's up");
    }
    
    private void Death(string message)
    {
        Player.transform.GetChild(1).gameObject.GetComponent<Light2D>().enabled = false;
        GameManager.GameOver = true;
        IngameMenu.NotificationText = message;
        Player.GetComponent<Animator>().SetTrigger("Death"); // TODO (Lukas): String ids
        FindObjectOfType<AudioManager>().Play("Lose");
        Player.GetComponent<CharacterMovement>().Freeze();
        GameManager.TimeCountDown = false;
    }

    private void PutOnSpawner()
    {
        Player.transform.position = Spawner.transform.position;
    }
}
