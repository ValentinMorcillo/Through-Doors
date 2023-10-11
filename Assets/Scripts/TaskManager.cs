using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI taskText;
    [SerializeField, TextArea(3, 6)] string[] tasks;
    AudioManager audioManager;

    bool isFirstTask = true;
    private int currentTaskIndex = 0;

    private void Start()
    {
        GameManager.Get().isCompleteTask += CompleteCurrentTask;
        audioManager = AudioManager.Get();
        ShowCurrentTask();
    }

    private void ShowCurrentTask()
    {
        if (currentTaskIndex < tasks.Length)
        {
            if (isFirstTask)
            {
                isFirstTask = false; // Desactiva el bloque de audio para la primera tarea.
            }
            else
            {
                audioManager.PlayAnnotateSound(); // Activa el bloque de audio para las tareas subsiguientes.
            }

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