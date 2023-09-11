    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsRoomsPart : HiddenPuzzlePart
{

    public override void Interact()
    {
        Debug.Log("habitacion PAdres");
        interactCorrectPart?.Invoke();
    }

    public override void Start()
    {
    }
}
