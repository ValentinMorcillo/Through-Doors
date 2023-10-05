using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HiddenPuzzlePart : MonoBehaviour, IInteractable
{
    [SerializeField] protected DialoguePanelController dialoguePanel;
    [SerializeField, TextArea(4, 6)] protected string dialogueText;
    protected CinematicManager cinematicManager;


    public Action interactCorrectPart;
    public abstract void Interact();

    public virtual void Start()
    {
        cinematicManager = CinematicManager.Get();
    }

   protected void OpenDialoguePanel()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.StartTyping(dialogueText, DialogueOf.chloe, true);
            GameManager.Get().isCompleteTask?.Invoke();
        }
    }
}
