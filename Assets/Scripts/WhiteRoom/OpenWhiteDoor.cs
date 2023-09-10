using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWhiteDoor : MonoBehaviour, IInteractable
{
    Animator animator;
    AudioManager am;
    
    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        am = AudioManager.Get();
    }

    public void Interact()
    {
        animator.SetTrigger("Open");
        am.PlayOpenDoorSound();
       
    }
}
