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

    [SerializeField] GameObject uiObjectOff;
    [SerializeField] GameObject uiItemOff;
    
    [SerializeField] bool switchTaskWhileInteracting = false;

    AudioManager am;
    CinematicManager cm;
    bool isActive;

    private void Start()
    {
        am = AudioManager.Get();
        cm = CinematicManager.Get();
    }

    private void Update()
    {

        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            visualObject.SetActive(true);
            visualizingCamera.SetActive(true);

            sceneObject.SetActive(false);
            uiObjectOff.gameObject.SetActive(false);
            cm.FreezePlayer();

            if (uiItemOff)
            {
                uiItemOff.gameObject.SetActive(false);
            }

            if (switchTaskWhileInteracting)
            {
                GameManager.Get().isCompleteTask?.Invoke();
                switchTaskWhileInteracting = false;
            }


            am.PlayCoinSound();
            Cursor.lockState = CursorLockMode.None;
        }

        if (isActive && Input.GetKeyDown(KeyCode.Q))
        {
            DisableVisualObject();
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

            DisableVisualObject();
        }
    }

    public void DisableVisualObject()
    {
        visualObject.SetActive(false);
        visualizingCamera.SetActive(false);

        sceneObject.SetActive(true);
        cm.ReanudePlayer();
        uiObjectOff.gameObject.SetActive(true);
        if (uiItemOff)
        {
            uiItemOff.gameObject.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.Locked;
    }
}
