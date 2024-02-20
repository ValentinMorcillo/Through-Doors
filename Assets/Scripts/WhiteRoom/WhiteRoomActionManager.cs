using EvolveGames;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class WhiteRoomActionManager : MonoBehaviourSingleton<WhiteRoomActionManager>
{
    [SerializeField] ThoughtData[] thoughtData;
    public Action onCompleteCameraTransition;
    public Action onReturnToWhiteRoom;

    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject dialoguePanel;

    [SerializeField] Image dialogueSprite;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialogueText;

    [SerializeField] Sprite kathImage;
    [SerializeField] Sprite chloeImage;
    [SerializeField] Sprite answerMachineImage;

    AudioManagerWhiteRoom audioManager;


    private string fullText = "";
    private string currentText = "";
    private int currentIndex = 0;
    public float typingSpeed = 0.05f;

    private bool isTyping = false;
    private bool shouldComplete = false;
    private bool hasInteract = false;

   static int thoughtIndex = 0;

    private void Start()
    {
        audioManager = AudioManagerWhiteRoom.Get();

        onCompleteCameraTransition += () => StartThought(thoughtIndex);
       // onReturnToWhiteRoom += () => StartThought(thoughtIndex);
    }

    void StartThought(int thougthIndex)
    {
        StartTyping(thoughtData[thougthIndex].newText, thoughtData[thougthIndex].dialogueOf, thoughtData[thougthIndex].isFlshback, thoughtData[thougthIndex].thoughtVoice);
        thoughtIndex++;
    }

    public void StartTyping(string newText, DialogueOf dialogueOf, bool isFlshback, AudioClip thoughtVoice = null)
    {
        SetupDialoguePanel(dialogueOf, isFlshback);

        if (thoughtVoice)
        {
            audioManager.PlayThoughtVoice(thoughtVoice);
        }

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
        FreezePlayer();
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
                audioManager.PlayFinishFlashbackSound();
                ReanudePlayer();
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

    public void FreezePlayer()
    {
        playerController.enabled = false;
    }

    public void ReanudePlayer()
    {
        playerController.enabled = true;
    }
    public bool IsTyping()
    {
        return isTyping;
    }
}
