using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HiddenPuzzlePart : MonoBehaviour, IInteractable
{
    public Action interactCorrectPart;
    public abstract void Interact();

    public abstract void Start();
}
