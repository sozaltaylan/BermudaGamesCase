using UnityEngine;
using UnityEngine.SceneManagement;
using BermudaGamesCase.Exceptions;
using BermudaGamesCase.Managers;
using BermudaGamesCase.Signals;

public class LevelManager : MonoSingleton<LevelManager>
{
    #region Variables

    private int _levelCount = 1;

    #endregion

    #region Events
    private void OnEnable()
    {
        EventSubscription();
    }
    private void OnDisable()
    {
        EventUnsubscription();
    }

    private void EventSubscription()
    {
        CoreGameSignals.onLoadNextScene += LoadNextLevel;
    }
    private void EventUnsubscription()
    {
        CoreGameSignals.onLoadNextScene -= LoadNextLevel;
    }

    #endregion
    #region Methods

    private void Start()
    {
        UpdateLevelUI();
    }
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
            _levelCount++;
            CoreGameSignals.onSetLevelText?.Invoke(_levelCount);
        }

    }
    private void UpdateLevelUI()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int levelNumber = currentSceneIndex + 1;
        CoreGameSignals.onSetLevelText?.Invoke(levelNumber);
    }






    #endregion
}
