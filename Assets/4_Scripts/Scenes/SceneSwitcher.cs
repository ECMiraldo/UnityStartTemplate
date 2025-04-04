using Eflatun.SceneReference;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;


public class SceneSwitcher : Singleton<SceneSwitcher>
{
    [Header("Key Scene References")]
    [SerializeField] private SceneReference startup;
    [SerializeField] private SceneReference mainMenu;
    [SerializeField] private SceneReference uiScene;
    [SerializeField] private List<SceneReference> gameplayScenes;

    [Header("Behaviour")]
    [SerializeField] private UILoadingScreen loadingScreen;
    [SerializeField] private float delayOnLoad;
    private void Start()
    {
        LoadMainMenu();
    }

    private void LoadMainMenu()
    {
        AsyncOperation[] op = { SceneManager.LoadSceneAsync(mainMenu.BuildIndex, LoadSceneMode.Additive) };
        StartCoroutine(ProcessCalls(op));
    }
    public void StartGameplaySession()
    {
        AsyncOperation[] ops = {
            SceneManager.LoadSceneAsync(gameplayScenes[0].BuildIndex, LoadSceneMode.Additive),
            SceneManager.LoadSceneAsync(uiScene.BuildIndex, LoadSceneMode.Additive),
            SceneManager.UnloadSceneAsync(mainMenu.LoadedScene)
        };
        StartCoroutine(ProcessCalls(ops));
    }
    public void ReturnToMainMenu()
    {
        AsyncOperation[] ops = {
            SceneManager.LoadSceneAsync(mainMenu.BuildIndex, LoadSceneMode.Additive),
            SceneManager.UnloadSceneAsync(gameplayScenes[0].LoadedScene),
            SceneManager.UnloadSceneAsync(uiScene.LoadedScene),
            
        };
        StartCoroutine(ProcessCalls(ops));
    }
    private IEnumerator ProcessCalls(AsyncOperation[] ops)
    {
        SceneManager.SetActiveScene(startup.LoadedScene);
        loadingScreen.Show();   
        while (ops.Any(op => !op.isDone))
        {
            Logger.LogScenes($"Load operation started with {ops.Length} calls");
            float totalProgress = ops.Sum(op => op.progress) / ops.Length > 0 ? ops.Length : 1;
            Logger.LogScenes($"Progress is : {totalProgress}");
            loadingScreen.UpdateValue(totalProgress);
            yield return null;
        }
        Logger.LogScenes($"Load operation finished");

        yield return new WaitForSecondsRealtime(delayOnLoad);
        Logger.LogScenes("Loading screen cleared");
        loadingScreen.Hide();
    }
}
