using System;

using Utils;


public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public Action isCompleteTask;

    private void Start()
    {
        Invoke(nameof(StartWithDealy), 0.1f);
    }

    void StartWithDealy()
    {
        ActionManager.Get().onStartThought?.Invoke();
    }

}
