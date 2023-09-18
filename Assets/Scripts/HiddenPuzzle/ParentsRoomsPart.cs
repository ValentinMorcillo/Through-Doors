    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsRoomsPart : HiddenPuzzlePart
{

    public override void Interact()
    {
        interactCorrectPart?.Invoke();

        if (dialoguePanel != null)
        {
            dialoguePanel.StartTyping(dialogueText);
        }

    }

}
