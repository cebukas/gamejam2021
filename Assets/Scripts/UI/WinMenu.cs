using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    [SerializeField]
    private Button quitButton;
    
    [SerializeField]
    private GameObject winMenuUI;

    void Start()
    {
        quitButton.onClick.AddListener(OnMenu);
    }

    private void Update()
    {
        if(GameManager.Win)
        {
            winMenuUI.SetActive(true);
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
}
