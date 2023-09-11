using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPart : HiddenPuzzlePart
{


    public override void Interact()
    {
        Debug.Log("habitacion Cocina");
        interactCorrectPart?.Invoke();

    }

    public override void Start()
    {
    }
}
