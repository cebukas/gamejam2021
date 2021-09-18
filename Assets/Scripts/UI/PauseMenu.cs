using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField]
    private Button _resumeButton;

    [SerializeField]
    private Button _quitButton;

    [SerializeField]
    private GameObject _pauseMenuUI;

    private void Start()
    {
        _resumeButton.onClick.AddListener(TogglePause);
        _quitButton.onClick.AddListener(OnMenu);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameManager.GameOver)
        {
            TogglePause();
        }
    }

    private void OnMenu()
    {
        StartCoroutine(QuitToMenu());
    }

    private IEnumerator QuitToMenu()
    {
        var sceneLoad = SceneManager.LoadSceneAsync("Menu");

        while (!sceneLoad.isDone)
        {
            yield return null;
        }
    }

    private void TogglePause()
    {
        if(Mathf.Approximately(Time.timeScale, 0.0f))
        {
            _pauseMenuUI.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            _pauseMenuUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
