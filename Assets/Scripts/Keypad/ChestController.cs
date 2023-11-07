using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] Transform chestTop;

    [SerializeField] float angle;
    private float openDuration = 0.5f;

    AudioManager am;

    private void Start()
    {
        am = AudioManager.Get();
    }

    public void OpenChest()
    {
        chestTop.DOLocalRotate(new Vector3(angle, 0, 0), openDuration);
        am.PlayOpenDoorSound();
    }
}
