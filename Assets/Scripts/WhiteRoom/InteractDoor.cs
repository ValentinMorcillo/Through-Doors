using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour, IInteractable
{
    AudioManagerWhiteRoom amWhiteRoom;
    AudioManager am;

    [SerializeField] bool isWhiteRoom = false;
    [SerializeField] bool isDoorEnable = true;

    DoorIsActive doorIsActive;


    public float angle = 90.0f;
    public float openDuration = 1.0f;
    private bool isOpen = false;
    private bool isShaking = false;

    private void Start()
    {
        amWhiteRoom = AudioManagerWhiteRoom.Get();
        am = AudioManager.Get();

        doorIsActive = GetComponentInParent<DoorIsActive>();
    }

    public void Interact()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            if (isDoorEnable)
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

                if (doorIsActive)
                {
                    doorIsActive.OnDisableDoor(); //Temporal para desactivar las puertas que se abren
                }
            }
            else
            {
                Shake();

                if (isWhiteRoom)
                {
                    amWhiteRoom.PlayLockedDoorSound();
                }
                else
                {
                    am.PlayLockedDoorSound();
                }
            }
        }
    }

    private void Shake()
    {
        float shakeDuration = 0.5f;
        float shakeStrength = 1.5f;

        if (!isShaking)
        {
            isShaking = true;

            Vector3 initialPosition = transform.position;

            transform.DOShakeRotation(shakeDuration, new Vector3(0f, shakeStrength, 0f))
                .OnComplete(() =>
                {
                    transform.position = initialPosition;
                    isShaking = false;
                });
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
