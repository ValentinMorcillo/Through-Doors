using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerMusicBoxParts : MonoBehaviour
{
    [SerializeField] private MusicalBoxPart[] musicalBoxParts;
    [SerializeField] private Transform[] correctPositonMusicalBoxParts;

    [SerializeField] InventorySprites inventory;
    [SerializeField] GameObject completeMusicalBox;

    public UnityEvent completePuzzleEvent;

    GameManager gameManager;
    AudioSource audioSource;

    private void Start()
    {
        gameManager = GameManager.Get();
        audioSource = GetComponent<AudioSource>();
    }

    public void CheckActivePhotos(PickableItem pickableItem)
    {
        if (pickableItem.GetItemType() == PickeableItemType.musicalBox)
        {
            for (int i = 0; i < musicalBoxParts.Length; i++)
            {
                if (musicalBoxParts[i].PhotoName == pickableItem.GetName())
                {
                    musicalBoxParts[i].IsVisualized = true;
                    gameManager.isCompleteTask?.Invoke();
                }
            }
        }
    }

    public void CheckWinCondition()
    {
        bool allPartsCorrect = true;

        for (int i = 0; i < musicalBoxParts.Length; i++)
        {
            if (musicalBoxParts[i].transform.position != correctPositonMusicalBoxParts[i].position)
            {
                allPartsCorrect = false;
                break;
            }
        }

        if (allPartsCorrect)
        {
            for (int i = 0; i < musicalBoxParts.Length; i++)
            {
                musicalBoxParts[i].gameObject.SetActive(false);
            }

            completePuzzleEvent.Invoke();
            gameManager.isCompleteTask?.Invoke();
            completeMusicalBox.SetActive(true);
            audioSource.Play();
        }
    }

    public bool CheckMusicPartInCorrectPivot(MusicalBoxPart correctItemPart)
    {
        int indexPart = correctItemPart.IDPart;

        if (Vector3.Distance(correctItemPart.transform.position, correctPositonMusicalBoxParts[indexPart].position) < 0.02f)
        {
            correctItemPart.transform.position = correctPositonMusicalBoxParts[indexPart].position;
            CheckWinCondition();
            return true;
        }

        return false;
    }
}
