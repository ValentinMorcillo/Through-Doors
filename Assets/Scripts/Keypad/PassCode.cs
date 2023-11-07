using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PassCode : MonoBehaviour
{
    public UnityEvent completePuzzle;
    [SerializeField] TextMeshProUGUI uiText = null;
    string correctCode = "1234";
    string currentCode = null;
    int charIndex = 0;

    public void CodeFuntion(string code)
    {
        if (charIndex >= 4)
        {
            return;
        }
        charIndex++;
        currentCode += code;
        uiText.text = currentCode;
    }

    public void Enter()
    {
        if (currentCode == correctCode)
        {
            completePuzzle?.Invoke();
        }
        else
        {
            Delete();
        }
    }

    public void Delete()
    {
        charIndex = 0;
        currentCode = null;
        uiText.text = currentCode;
    }
}
