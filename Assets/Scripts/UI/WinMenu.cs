using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    [SerializeField]
    private Button _quitButton;
    
    [SerializeField]
    private GameObject _winMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        _quitButton.onClick.AddListener(OnMenu);
    }

    private void Update()
    {
        if(GameManager.Win)
        {
            _winMenuUI.SetActive(true);
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
