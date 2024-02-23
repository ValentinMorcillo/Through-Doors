using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractFinalDoor : MonoBehaviour, IInteractable
{
    CinematicManager cm;
     bool isActive = false;

    void Start()
    {
        cm = CinematicManager.Get();
    }

    public void Interact()
    {
        if (isActive)
        {
        cm.FinalThirdPart();
        }        
    }

    public void ActiveFinalDoor() 
    {
        isActive = true;
    }
}
