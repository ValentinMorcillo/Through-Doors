using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPart : HiddenPuzzlePart
{
    [SerializeField] DoorControllers[] doorsToOpen;

    public override void Interact()
    {
        interactCorrectPart?.Invoke();

        cinematicManager.FreezePlayer();
        
        OpenAllDoors();

        Invoke(nameof(OpenDialoguePanel), .8f);
    }

    void OpenAllDoors()
    {
        foreach (DoorControllers dc in doorsToOpen)
        {
            dc.OpenDoor();
        }
    }

}
