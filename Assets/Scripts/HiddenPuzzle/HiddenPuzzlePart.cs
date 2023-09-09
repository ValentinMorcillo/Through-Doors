using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HiddenPuzzlePart : MonoBehaviour, IInteractable
{
    public abstract void Interact();
}
