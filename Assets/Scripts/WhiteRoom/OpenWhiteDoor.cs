using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWhiteDoor : MonoBehaviour, IInteractable
{
    AudioManager am;

    public float angle = 90.0f;
    public float openDuration = 1.0f;
    private bool isOpen = false;

    private void Start()
    {
        am = AudioManager.Get();
    }

    public void Interact()
    {
        OpenDoor();
        am.PlayOpenDoorSound();
    }

    private void OpenDoor()
    {
        if (!isOpen)
        {
            transform.DOLocalRotate(new Vector3(0, angle, 0), openDuration);
            isOpen = true;
        }
    }

    private void CloseDoor()
    {
        if (isOpen)
        {
            transform.DOLocalRotate(Vector3.zero, openDuration);
            isOpen = false;
        }
    }

}
