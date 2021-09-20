﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        GameManager.TimeUp += OnRestart;
        Health.DeathFromDamage += OnRestart;
        FallTrap.PlayerInTrap += OnRestart;
        BallMovement.PlayerHitBall += OnRestart;
    }
    
    private void Update()
    {
        if (GameManager.Win) return;
        liveCountText.text = $"Lives: {hero.GetComponent<Health>().GetHealth()}"; //TODO: hardcoded string bad more more languages
        timeText.text = $"Time left: {Math.Round(gameManager.timeLeftInSeconds).ToString()}";
        notificationTextUI.text = NotificationText;
    }

    private void OnRestart(object sender, EventArgs a)
    {
        EnableRestartButton();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void UnsubscribeFromEvents()
    {
        GameManager.TimeUp -= OnRestart;
        Health.DeathFromDamage -= OnRestart;
        FallTrap.PlayerInTrap -= OnRestart;
        BallMovement.PlayerHitBall -= OnRestart;
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
