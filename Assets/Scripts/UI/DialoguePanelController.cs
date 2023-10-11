using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum DialogueOf
{
    kath, chloe, answerMachine
}

public class DialoguePanelController : MonoBehaviour
{
    [SerializeField] GameObject PostProcessingVolume;
    [SerializeField] GameObject dialoguePanel;

    [SerializeField] Image dialogueSprite;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialogueText;

    [SerializeField] Sprite kathImage;
    [SerializeField] Sprite chloeImage;
    [SerializeField] Sprite answerMachineImage;

    CinematicManager cinematicManager;
    GameManager gameManager;
    AudioManager audioManager;

    private string fullText = "";
    private string currentText = "";
    private int currentIndex = 0;
    public float typingSpeed = 0.05f;

    private bool isTyping = false;
    private bool shouldComplete = false;
    private bool hasInteract = false;


    private void Start()
    {
        cinematicManager = CinematicManager.Get();
        gameManager = GameManager.Get();
        audioManager = AudioManager.Get();

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    public void StartTyping(string newText, DialogueOf dialogueOf, bool isFlshback)
    {
        SetupDialoguePanel(dialogueOf, isFlshback);

        audioManager.PlayVoiceSound();

        fullText = newText;
        currentText = "";
        currentIndex = 0;

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true);
        }

        isTyping = true;
        hasInteract = false;    
        shouldComplete = false; 
        StartCoroutine(DelayInDetectingInput());
        StartCoroutine(TypeText());
    }

    private IEnumerator DelayInDetectingInput()
    {
        yield return new WaitForEndOfFrame(); // Espera al final del frame

        hasInteract = true;
    }

    void SetupDialoguePanel(DialogueOf dialogueOf, bool isFlashback)
    {
        cinematicManager.FreezePlayer();
        PostProcessingVolume.SetActive(isFlashback);
        audioManager.PlayInitFlashbackSound();

        switch (dialogueOf)
        {
            case DialogueOf.kath:

                dialogueSprite.sprite = kathImage;
                nameText.text = "Kath";

                break;
            case DialogueOf.chloe:
                
                dialogueSprite.sprite = chloeImage;
                nameText.text = "Chloe";
                
                break;
            case DialogueOf.answerMachine:

                dialogueSprite.sprite = answerMachineImage;
                nameText.text = "Answer Machine";

                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (isTyping && hasInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                shouldComplete = true;
                audioManager.StopVoiceSound();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && dialoguePanel.activeSelf && hasInteract)
            {

                dialoguePanel.SetActive(false);
                PostProcessingVolume.SetActive(false);
                audioManager.PlayFinishFlashbackSound();
                cinematicManager.ReanudePlayer();

                CompleteTask();
            }
        }
    }

    private IEnumerator TypeText()
    {
        while (currentIndex < fullText.Length)
        {
            currentText += fullText[currentIndex];
            dialogueText.text = currentText;
            currentIndex++;

            // Verifica si shouldComplete es true para finalizar la escritura.
            if (shouldComplete)
            {
                currentText = fullText; // Establece el texto completo.
                dialogueText.text = currentText;
                break; // Sale del bucle.
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public bool IsTyping()
    {
        return isTyping;
    }

    void CompleteTask()
    {
        gameManager.isCompleteTask?.Invoke();
    }
}

