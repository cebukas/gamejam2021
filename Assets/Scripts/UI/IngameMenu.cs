﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour
{
    public static string NotificationText;

    [SerializeField]
    private TextMeshProUGUI _timeText;

    [SerializeField]
    private TextMeshProUGUI _liveCountText;

    [SerializeField]
    private TextMeshProUGUI _notificationTextUI;

    [SerializeField]
    private Button _restartButton;

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private GameObject _hero;

    public void EnableRestartButton()
    {
        _restartButton.gameObject.SetActive(true);
    }

    private void Start()
    {
        NotificationText = "";
        _notificationTextUI.SetText("");
        _restartButton.onClick.AddListener(RestartLevel);
        _restartButton.gameObject.SetActive(false);

        GameManager.TimeUp += GameManager_TimeUp;
        Health.DeathFromDamage += Health_DeathFromDamage;
    }

    private void Health_DeathFromDamage(object sender, EventArgs e)
    {
        EnableRestartButton();
    }

    private void GameManager_TimeUp(object sender, EventArgs e)
    {
        EnableRestartButton();
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

    void Update()
    {
        _liveCountText.SetText($"Lives: {_hero.GetComponent<Health>().GetHealth()}");
        _timeText.SetText($"Time left: {Math.Round(_gameManager.TimeLeftInSeconds).ToString()}");
        _notificationTextUI.SetText(NotificationText);
    }
}
