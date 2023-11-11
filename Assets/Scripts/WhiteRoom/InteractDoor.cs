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
    [SerializeField] bool isSlidingDoor = false;

    [Space]

    [SerializeField] float angle = 90.0f;
    [SerializeField] float openDuration = 1.0f;
    [SerializeField] float slidingDoorOffSetZ;

    GameObjectsComponentsManager doorIsActive;

    private bool isOpen = false;
    private bool isShaking = false;

    public bool IsDoorEnable
    {
        get { return isDoorEnable; }
        set { isDoorEnable = value; }
    }

    private void Start()
    {
        amWhiteRoom = AudioManagerWhiteRoom.Get();
        am = AudioManager.Get();

        doorIsActive = GetComponentInParent<GameObjectsComponentsManager>();
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
                if (!isSlidingDoor)
                {
                    transform.DOLocalRotate(new Vector3(0, angle, 0), openDuration);
                }
                else
                {
                    transform.DOLocalMoveZ(slidingDoorOffSetZ, openDuration);
                }

                isOpen = true;
                PlayDoorSound();

                if (doorIsActive)
                {
                    doorIsActive.OnDisableComponents(); //Temporal para desactivar las puertas que se abren
                }
            }
            else
            {
                Shake();
                PlayLockedDoorSound();
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

    private void PlayDoorSound()
    {
        if (isWhiteRoom)
        {
            amWhiteRoom.PlayOpenDoorSound();
        }
        else
        {
            am.PlayOpenDoorSound();
        }
    }

    private void PlayLockedDoorSound()
    {
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
