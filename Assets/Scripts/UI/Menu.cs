using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private string sceneNameToLoad;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject settingsMenu;
    
    public void OnPlay()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    private IEnumerator LoadYourAsyncScene()
    {
        //Hardcoding scene name since we have only one..
        sceneNameToLoad = "Level OLD"; 

        var asyncLoad = SceneManager.LoadSceneAsync(sceneNameToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void OnBack()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void OnSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
        Debug.Log("Game is exiting (only in builds)");
    }
}
