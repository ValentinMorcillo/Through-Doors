using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChloeRoomPart : HiddenPuzzlePart
{


    public override void Interact()
    {
        interactCorrectPart?.Invoke();

        cinematicManager.LookUnderBed();

        Invoke(nameof(OpenDialoguePanel), 7f);

        PathManager.instance.RemoveBlockingObject("BlockingBoxesParentsRoom");
    }

}
