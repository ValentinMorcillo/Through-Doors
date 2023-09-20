    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsRoomsPart : HiddenPuzzlePart
{
    [SerializeField] DoorControllers[] doorsToOpen;

    public override void Interact()
    {
        interactCorrectPart?.Invoke();
 
        cinematicManager.FreezePlayer();

        OpenAllDoors();
        
        Invoke(nameof(OpenDialoguePanel), 0.8f);
    }

    void OpenAllDoors()
    {
        foreach (DoorControllers dc in doorsToOpen)
        {
            dc.OpenDoor();
        }
    }
}
