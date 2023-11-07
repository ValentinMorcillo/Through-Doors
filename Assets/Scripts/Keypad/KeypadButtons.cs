using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButtons : MonoBehaviour
{
    [SerializeField] uint number;
    [SerializeField] bool isEnter = false;

    PassCode passCode;

    private void Start()
    {
        passCode = GetComponentInParent<PassCode>();
    }

    private void OnMouseUpAsButton()
    {
        if (isEnter)
        {
            passCode.Enter();
        }
        else
        {
            passCode.CodeFuntion(number.ToString());
        }
    }

}
