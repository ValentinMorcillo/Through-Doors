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

    BoxCollider interactionCollider;

    private void Awake()
    {
        componentManager = GetComponentInParent<GameObjectsComponentsManager>();

        BoxCollider[] collider = GetComponents<BoxCollider>();

        foreach (BoxCollider boxCollider in collider)
        {
            if (!boxCollider.isTrigger)
            {
                interactionCollider = boxCollider;
            }
        }
    }

    private void Start()
    {
        am = AudioManager.Get();
       componentManager.ToggleComponents(isActive);
        isActive = false;
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
        am.PlayOpenDoorSound();

        hatch.transform.DORotate(openRotation, rotationDuration)
            .OnComplete(ExtendLadder);
    }

    private void ExtendLadder()
    {
        ladder.transform.DOLocalMove(ladderOffset, 1.0f)
        .SetEase(Ease.OutBounce);

        interactionCollider.enabled = false;
        componentManager.OnDisableComponents();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra");
        isActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
    }

}
