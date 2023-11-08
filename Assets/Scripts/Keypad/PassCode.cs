using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PassCode : MonoBehaviour
{
    public UnityEvent completePuzzle;

    [SerializeField] TextMeshProUGUI uiText = null;

    AudioManager am;

    string correctCode = "4721";
    string currentCode = null;
    int charIndex = 0;

    private void Start()
    {
        am = AudioManager.Get();
    }

    public void CodeFuntion(string code)
    {
       
        if (charIndex >= 4)
        {
            am.PlayIncorrectSound();
            return;
        }

        am.PlayPressButtonPadSound();
        charIndex++;
        currentCode += code;
        uiText.text = currentCode;
    }

    public void Enter()
    {

        if (currentCode == correctCode)
        {
            am.PlayWinPuzzleSound();
            completePuzzle?.Invoke();
        }
        else
        {
            Delete();
        }
    }

    public void Delete()
    {
        am.PlayIncorrectSound();

        charIndex = 0;
        currentCode = null;
        uiText.text = currentCode;
    }
}
