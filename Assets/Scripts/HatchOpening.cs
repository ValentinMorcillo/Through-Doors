using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchOpening : MonoBehaviour, IInteractable
{
    [SerializeField] bool isActive;

    GameObjectsComponentsManager componentManager;
    AudioManager am;

    [SerializeField] GameObject hatch;
    [SerializeField] GameObject ladder;
    [SerializeField] float rotationDuration = 1.0f;
    [SerializeField] Vector3 openRotation = new Vector3(0, 90, 0);
    [SerializeField] Vector3 ladderOffset = new Vector3(-3, 0, 0);

    private bool isOpen = false;

    private void Awake()
    {
        componentManager = GetComponentInParent<GameObjectsComponentsManager>();
        am = AudioManager.Get();
    }

    private void Start()
    {
       componentManager.ToggleComponents(isActive);
    }

    public void Interact()
    {
        if (isActive)
        {
            OpenHatch();
        }
    }

    private void OpenHatch()
    {
        isOpen = true;

        am.PlayOpenDoorSound();
        hatch.transform.DORotate(openRotation, rotationDuration)
            .OnComplete(ExtendLadder);
    }

    private void ExtendLadder()
    {
        ladder.transform.DOLocalMove(ladderOffset, 1.0f)
        .SetEase(Ease.OutBounce);

        componentManager.OnDisableComponents();
    }


}
