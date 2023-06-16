using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayTrigger : MonoBehaviour
{
    [SerializeField] GameObject visualObject;
    [SerializeField] GameObject descriptionObject;
    [SerializeField] GameObject visualizingCamera;
    [SerializeField] GameObject sceneObject;
    [SerializeField] FPSCameraController fpsCameraController;


    [SerializeField] Canvas uiCanvas;
    bool isActive;


    private void Update()
    {

        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            visualObject.SetActive(true);
            visualizingCamera.SetActive(true);

            sceneObject.SetActive(false);
            uiCanvas.gameObject.SetActive(false);
            fpsCameraController.enabled = false;

            Cursor.lockState = CursorLockMode.None;
        }

        if (isActive && Input.GetKeyDown(KeyCode.Q))
        {
            visualObject.SetActive(false);
            visualizingCamera.SetActive(false);
            
            sceneObject.SetActive(true);
            fpsCameraController.enabled = true;
            uiCanvas.gameObject.SetActive(true);
            
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = false;

            visualObject.SetActive(false);
            visualizingCamera.SetActive(false);

            sceneObject.SetActive(true);
            fpsCameraController.enabled = true;
            uiCanvas.gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
