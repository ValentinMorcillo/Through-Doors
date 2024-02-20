using System;
using UnityEngine.SceneManagement;

using Utils;


public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public Action isCompleteTask;

    private void Start()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (sceneName == "FirstPuzzle" || sceneName == "ThirdPuzzle")
        {
            Invoke(nameof(StartWithDealy), 0.1f);
        }
    }

    void StartWithDealy()
    {
        ActionManager.Get().onStartThought?.Invoke();
    }

}
