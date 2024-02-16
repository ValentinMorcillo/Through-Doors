using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class WhiteRoomManager : MonoBehaviour
{
    [SerializeField] MenuController menuController;

    [SerializeField] GameObject[] turnOn;
    [SerializeField] InteractDoor doorpart1;
    [SerializeField] InteractDoor doorpart2;

    WhiteRoomActionManager actionManager;

    static int stageNumber = -1;
    
    private void Start()
    {
        actionManager = new WhiteRoomActionManager();

        stageNumber++;

        switch (stageNumber)
        {
            case 0:

                Invoke(nameof(OnEnbleMenu), 0.1f);
                break;

            case 1:

                Invoke(nameof(OnDisableMenu), 0.05f);
                CompleteFirstPart();

                break;

            default:

                Debug.Log("Fuera de rango el StageNumber: " + stageNumber);
                break;
        }
    }

    public void CompleteStage()
    {
        stageNumber++;
    }

    public void CompleteFirstPart()
    {
        foreach (GameObject turnOnGO in turnOn )
        {
            turnOnGO.SetActive(true);
        }

        doorpart1.IsDoorEnable = false;
        doorpart2.IsDoorEnable = true;
        doorpart2.gameObject.transform.DOLocalRotate(new Vector3(0, 20, 0), 0.5f);

        actionManager.onReturnToWhiteRoom?.Invoke();
    }

    void OnEnbleMenu()
    {
        menuController.EnableMenu();
    }

    void OnDisableMenu()
    {
        menuController.DisableMenu();
    }
}
