using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsContainerPhotos : MonoBehaviour
{
    [SerializeField] private PhotoPart[] photosParts;
    [SerializeField] private Transform[] correctPositonPhotoParts;

    [SerializeField] InventorySprites inventory;
    [SerializeField] GameObject completePhoto;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnEnable()
    {
        CheckActivePhotos();
    }

    void CheckActivePhotos()
    {
        for (int i = 0; i < inventory.PickableItemsList.Count; i++)
        {
            if (inventory.PickableItemsList[i].GetItemType() == PickeableItemType.photo)
            {
                for (int j = 0; j < photosParts.Length; j++)
                {
                    if (photosParts[j].PhotoName == inventory.PickableItemsList[i].GetName())
                    {
                        photosParts[j].IsVisualized = true;
                    }
                }
            }
        }
    }

    public void CheckWinCondition()
    {
        bool allPartsCorrect = true;

        for (int i = 0; i < photosParts.Length; i++)
        {
            if (photosParts[i].transform.position != correctPositonPhotoParts[i].position)
            {
                allPartsCorrect = false;
                break;
            }
        }

        if (allPartsCorrect)
        {
            for (int i = 0; i < photosParts.Length; i++)
            {
                photosParts[i].gameObject.SetActive(false);
            }

            completePhoto.SetActive(true);
            audioSource.Play();
        }
    }

    public bool CheckPhotoInCorrectPivot(PhotoPart correctPhotoPart)
    {
        int indexPhoto = correctPhotoPart.IDPart;

        if (Vector3.Distance(correctPhotoPart.transform.position, correctPositonPhotoParts[indexPhoto].position) < 0.02f)
        {
            correctPhotoPart.transform.position = correctPositonPhotoParts[indexPhoto].position;
            CheckWinCondition();
            return true;
        }

        return false;
    }
}
