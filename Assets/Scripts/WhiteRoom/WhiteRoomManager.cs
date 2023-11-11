using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class WhiteRoomManager : MonoBehaviourSingleton<WhiteRoomManager>
{
    [SerializeField] GameObject turnOn;
    [SerializeField] InteractDoor doorpart1;
    [SerializeField] InteractDoor doorpart2;

    public void CompleteFirstPart()
    {
        turnOn.SetActive(true);

        doorpart1.IsDoorEnable = false;
        doorpart2.IsDoorEnable = true ;
        doorpart2.gameObject.transform.DOLocalRotate(new Vector3(0, 20, 0), 0.5f);


    }

}
