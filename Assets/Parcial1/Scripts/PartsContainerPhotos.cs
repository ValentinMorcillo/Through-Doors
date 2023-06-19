using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsContainerPhotos : MonoBehaviour
{
    [SerializeField] private PhotoPart[] photosParts;
    [SerializeField] private Transform[] correctPositonPhotoParts;

    [SerializeField] InventorySprites inventory;

    private void OnEnable()
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

    public bool CheckWincondition()
    {
        int count = 0;

        for (int i = 0; i < photosParts.Length - 1; i++)
        {
            if (photosParts[i].transform.position == correctPositonPhotoParts[i].position)
            {
                count++;

                if (count >= photosParts.Length - 1)
                {
                    return true;
                }
            }
            else
            {
                break;
            }
        }

        return false;
    }

    public bool CheckPhotoInCorrectPivot(PhotoPart correctPhotoPart)
    {
        int indexPhoto = correctPhotoPart.IDPart;

        if (Vector3.Distance(correctPhotoPart.transform.position, correctPositonPhotoParts[indexPhoto].position) < 0.02f)
        {
            correctPhotoPart.transform.position = correctPositonPhotoParts[indexPhoto].position;
            return true;
        }

        return false;
    }
}
