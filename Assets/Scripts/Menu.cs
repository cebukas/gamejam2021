using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string sceneNameToLoad;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public void onPlay()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNameToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void onBack()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void onSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void onExit()
    {
        Application.Quit();
        Debug.Log("Game is exiting (only in builds)");
    }
}
