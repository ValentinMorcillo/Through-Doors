using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour, IInteractable
{
    AudioManagerWhiteRoom amWhiteRoom;
    AudioManager am;

    [SerializeField] bool isWhiteRoom = false;

    public float angle = 90.0f;
    public float openDuration = 1.0f;
    private bool isOpen = false;

    private void Start()
    {
        amWhiteRoom = AudioManagerWhiteRoom.Get();
        am = AudioManager.Get();
    }

    public void Interact()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            transform.DOLocalRotate(new Vector3(0, angle, 0), openDuration);
            isOpen = true;

            if (isWhiteRoom)
            {
                amWhiteRoom.PlayOpenDoorSound();
            }
            else
            {
                am.PlayOpenDoorSound();
            }

           // transform.GetComponentInParent<DoorIsActive>().OnDisableDoor(); //Temporal para desactivar las puertas que se abren
        }
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            transform.DOLocalRotate(Vector3.zero, openDuration);
            isOpen = false;
        }
    }

}
