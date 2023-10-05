    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsRoomsPart : HiddenPuzzlePart
{
    [SerializeField] InteractDoor[] doorsToOpen;

    BoxCollider doorCollider;

    public override void Start()
    {
        base.Start();

        BoxCollider[] colliders = GetComponents<BoxCollider>();

        foreach (BoxCollider coll in colliders)
        {
            if (!coll.isTrigger)
            {
                doorCollider = coll;
            }
        }
    }

    public override void Interact()
    {
        interactCorrectPart?.Invoke();
 
        cinematicManager.FreezePlayer();

        OpenAllDoors();
        
        Invoke(nameof(OpenDialoguePanel), 0.8f);
        doorCollider.enabled = false; //Esto se hace para que el collider no interfiera para agarrar el cuadro de adentro
    }

    void OpenAllDoors()
    {
        foreach (InteractDoor dc in doorsToOpen)
        {
            dc.OpenDoor();
        }
    }
}
