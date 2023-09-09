using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWhiteDoor : MonoBehaviour, IInteractable
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void Interact()
    {
        animator.SetTrigger("Open");
    }
}
