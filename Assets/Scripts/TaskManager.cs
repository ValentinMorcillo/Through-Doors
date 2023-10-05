using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI taskText;      
    [SerializeField, TextArea(3,6)] string[] tasks; 


    private int currentTaskIndex = 0; 

    private void Start()
    {
        ShowCurrentTask();
        GameManager.Get().isCompleteTask += CompleteCurrentTask;
    }

    private void ShowCurrentTask()
    {
        if (currentTaskIndex < tasks.Length)
        {
            taskText.text = tasks[currentTaskIndex];
        }
        else
        {
            taskText.text = "¡Todas las tareas han sido completadas!";
        }
    }

    public void CompleteCurrentTask()
    {
        if (currentTaskIndex < tasks.Length)
        {
            currentTaskIndex++;
            ShowCurrentTask();
        }
    }
}