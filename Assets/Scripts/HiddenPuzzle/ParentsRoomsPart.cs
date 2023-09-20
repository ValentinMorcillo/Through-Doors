    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsRoomsPart : HiddenPuzzlePart
{

    public override void Interact()
    {
        interactCorrectPart?.Invoke();

        Invoke(nameof(OpenDialoguePanel), 2f);
    }

}
