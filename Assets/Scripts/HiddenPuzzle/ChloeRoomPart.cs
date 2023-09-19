using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChloeRoomPart : HiddenPuzzlePart
{


    public override void Interact()
    {
        interactCorrectPart?.Invoke();

        OpenDialoguePanel();
    }

    void OpenDialoguePanel()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.StartTyping(dialogueText);
        }
    }

}
