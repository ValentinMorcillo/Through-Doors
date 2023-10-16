using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnsweringMachineBehavior : MonoBehaviour, IInteractable
{
    [SerializeField] DialoguePanelController dialoguePanel;
    [SerializeField] GameObject sfxAnswerMachine;

    [SerializeField, TextArea(4, 6)] protected string dialogueText;
    protected CinematicManager cinematicManager;
    GameManager gameManager;
    private bool hasInteracted = false;

    public virtual void Start()
    {
        cinematicManager = CinematicManager.Get();
        gameManager = GameManager.Get();
    }

    public void Interact()
    {
        if (!hasInteracted)
        {
            OpenDialoguePanel();
            Destroy(sfxAnswerMachine);
            hasInteracted = true;
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
