using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnsweringMachineBehavior : MonoBehaviour, IInteractable
{
    [SerializeField] DialoguePanelController dialoguePanel;
    [SerializeField] GameObject sfxAnswerMachine;
    [SerializeField] TextMeshProUGUI messageCount;
    [SerializeField] PickableItem[] photoParts;
    [SerializeField] private GameObject[] photoGO;
 

    [SerializeField, TextArea(4, 6)] protected string dialogueText;
    protected CinematicManager cinematicManager;
    GameObjectsComponentsManager componentsManager;
    private bool hasInteracted = false;



    public virtual void Start()
    {
        cinematicManager = CinematicManager.Get();
        componentsManager = GetComponent<GameObjectsComponentsManager>();
    }
    public void Update()
    {
        if (!hasInteracted)
        {
            for (int i = 0; i < photoGO.Length; i++)
            {
                photoGO[i].SetActive(false);
            }
        }
    }

    public void Interact()
    {
        if (!hasInteracted)
        {
            OpenDialoguePanel();
            ActivePhotoInteractions();
            messageCount.text = "0";
            ActionManager.Get().onSetHasThought?.Invoke();
            Destroy(sfxAnswerMachine); //Destruyo el pitido
            componentsManager.OnDisableComponents();
            
            GameManager.Get().isCompleteTask?.Invoke();
            hasInteracted = true;
            for (int i = 0; i < photoGO.Length; i++)
            {
                photoGO[i].SetActive(true);
            }
        }
    }

    void ActivePhotoInteractions()
    {
        foreach (PickableItem pi in photoParts)
        {
            pi.SetIfActive(true);
        }
    }

    void OpenDialoguePanel()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.StartTyping(dialogueText, DialogueOf.answerMachine, false);
        }
    }

  
}
