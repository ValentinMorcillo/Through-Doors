using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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

        PathManager.instance.RemoveBlockingObject("BlockingBoxesStairs");

    }

    void OpenAllDoors()
    {
        foreach (InteractDoor dc in doorsToOpen)
        {
            dc.OpenDoor();
        }
    }


}
