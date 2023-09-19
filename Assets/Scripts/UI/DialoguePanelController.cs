using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialoguePanelController : MonoBehaviour
{
    [SerializeField] GameObject PostProcessingVolume;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;

    CinematicManager cinematicManager;

    private string fullText = "";
    private string currentText = "";
    private int currentIndex = 0;
    public float typingSpeed = 0.05f;
    private bool isTyping = false;
    private bool shouldComplete = false; // Nueva variable para controlar la finalización.

    private void Start()
    {
        cinematicManager = CinematicManager.Get();

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    public void StartTyping(string newText)
    {
        cinematicManager.FreezePlayer();
        PostProcessingVolume.SetActive(true);

        fullText = newText;
        currentText = "";
        currentIndex = 0;

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true);
        }

        isTyping = true;
        shouldComplete = false; // Inicializa shouldComplete en false.
        StartCoroutine(TypeText());
    }

    private void Update()
    {
        if (isTyping)
        {
            // Si se presiona la tecla "E", establece shouldComplete en true.
            if (Input.GetKeyDown(KeyCode.E))
            {
                shouldComplete = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && dialoguePanel != null)
            {
                dialoguePanel.SetActive(false);
                PostProcessingVolume.SetActive(false);
                cinematicManager.ReanudePlayer();
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
}

