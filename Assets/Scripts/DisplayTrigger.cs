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

    [SerializeField] GameObject uiObjectOff;
    
    AudioSource audioSource;
    bool isActive;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            visualObject.SetActive(true);
            visualizingCamera.SetActive(true);

            sceneObject.SetActive(false);
            uiObjectOff.gameObject.SetActive(false);
            fpsCameraController.enabled = false;

            audioSource.Play();
            Cursor.lockState = CursorLockMode.None;
        }

        if (isActive && Input.GetKeyDown(KeyCode.Q))
        {
            visualObject.SetActive(false);
            visualizingCamera.SetActive(false);
            
            sceneObject.SetActive(true);
            fpsCameraController.enabled = true;
            uiObjectOff.gameObject.SetActive(true);
            
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
            uiObjectOff.gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
