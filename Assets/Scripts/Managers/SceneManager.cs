using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class SceneManager : MonoBehaviourSingleton<SceneManager>
{
    [SerializeField] private MMF_Player mmfPlayer;

    private MMF_LoadScene loadScene;

    private const string gameplaySceneName = "Gameplay";

    void Start()
    {
        loadScene = mmfPlayer.GetFeedbackOfType<MMF_LoadScene>();
    }

    public void LoadScene(string scene)
    {
        Time.timeScale = 1;
        loadScene.DestinationSceneName = scene;
        mmfPlayer.PlayFeedbacks();
    }

    public void LoadGameplay()
    {
        Time.timeScale = 1;
        loadScene.DestinationSceneName = gameplaySceneName;
        mmfPlayer.PlayFeedbacks();
    }

    void Update()
    {
        
    }
}
