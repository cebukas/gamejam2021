using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour
{
    public static string NotificationText;

    [SerializeField]
    private Text timeText;

    [SerializeField]
    private Text liveCountText;

    [SerializeField]
    private Text notificationTextUI;

    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject hero;

    private void Start()
    {
        NotificationText = "";
        notificationTextUI.text = "";
        restartButton.onClick.AddListener(RestartLevel);
        restartButton.gameObject.SetActive(false);

        GameManager.TimeUp += ShouldRestart;
        Health.DeathFromDamage += ShouldRestart;
        FallTrap.PlayerInTrap += ShouldRestart;
        BallMovement.PlayerHitBall += ShouldRestart;
    }
    
    private void Update()
    {
        if (GameManager.Win) return;
        liveCountText.text = $"Lives: {hero.GetComponent<Health>().GetHealth()}"; //TODO: hardcoded string bad more more languages
        timeText.text = $"Time left: {Math.Round(gameManager.timeLeftInSeconds).ToString()}";
        notificationTextUI.text = NotificationText;
    }

    private void ShouldRestart(object sender, EventArgs a)
    {
        EnableRestartButton();
    }

    private void EnableRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }
    
    private void RestartLevel()
    {
        StartCoroutine(RestartLevelScene());
    }

    private IEnumerator RestartLevelScene()
    {
        var sceneLoad = SceneManager.LoadSceneAsync("Menu");

        while (!sceneLoad.isDone)
        {
            yield return null;
        }
    }
}
