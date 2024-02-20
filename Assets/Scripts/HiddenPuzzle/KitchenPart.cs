using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPart : HiddenPuzzlePart
{
    [SerializeField] InteractDoor[] doorsToOpen;

    public override void Interact()
    {
        interactCorrectPart?.Invoke();

        cinematicManager.FreezePlayer();
        
        OpenAllDoors();
        
        actionManager.onSetHasThought?.Invoke();

        Invoke(nameof(OpenDialoguePanel), .8f);
    }

    void OpenAllDoors()
    {
        foreach (InteractDoor dc in doorsToOpen)
        {
            dc.OpenDoor();
        }
    }

}
