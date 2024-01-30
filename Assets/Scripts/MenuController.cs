using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button controlsButton;
    [SerializeField] Button returnButton;
    [SerializeField] Button exitButton;

    [SerializeField] GameObject gameplayCanvas;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject controlsCanvas;

    [SerializeField] GameObject menuCamera;
    [SerializeField] EvolveGames.PlayerController playerController;


    private void Start()
    {
        playButton.onClick.AddListener(OnClickPlayButton);
        controlsButton.onClick.AddListener(OnClickControlsButton);
        returnButton.onClick.AddListener(OnClickReturnButton);
        exitButton.onClick.AddListener(OnClickExitButton);

        // Invoke(nameof(EnableMenu), 0.1f);
    }

    public void OnClickPlayButton()
    {
        DisableMenu();
    }

    public void OnClickReturnButton()
    {
        menuCanvas.SetActive(true);
        controlsCanvas.SetActive(false);
    }

    public void OnClickControlsButton()
    {
        menuCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void DisableMenu()
    {
        LockedMouse();

        menuCamera.SetActive(false);
        menuCanvas.SetActive(false);
        gameplayCanvas.SetActive(true);

        Invoke(nameof(ActiveCameraMovement), 2.0f);
    }

    void ActiveCameraMovement()
    {
        playerController.canRotateCamera = true;
    }

    public void EnableMenu()
    {
        UnlockedMouse();

        playerController.canRotateCamera = false;
        menuCamera.SetActive(true);
        menuCanvas.SetActive(true);
        gameplayCanvas.SetActive(false);
    }

    public void LockedMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockedMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
