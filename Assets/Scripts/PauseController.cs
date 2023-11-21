using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject gameplayCanvas;
    [SerializeField] GameObject controlsCanvas;
    [SerializeField] GameObject pauseCanvas;

    [SerializeField] Button resumeButton;
    [SerializeField] Button controlsButton;
    [SerializeField] Button returnButton;
    [SerializeField] Button exitButton;

    private void Start()
    {
        resumeButton.onClick.AddListener(OnClickResumeButton);
        controlsButton.onClick.AddListener(OnClickControlsButton);
        returnButton.onClick.AddListener(OnClickReturnButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickResumeButton()
    {
        DisablePause();
    }

    public void OnClickReturnButton()
    {
        pauseCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }

    public void OnClickControlsButton()
    {
        pauseCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void DisablePause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

        pauseCanvas.SetActive(false);
        gameplayCanvas.SetActive(true);

    }

    public void EnablePause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;

        pauseCanvas.SetActive(true);
        gameplayCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnablePause();
        }
    }

}
