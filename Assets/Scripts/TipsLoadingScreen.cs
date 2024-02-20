using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipsLoadingScreen : MonoBehaviour
{
    static int tipsLoadingScreenIndex = 0;

    [SerializeField] TextMeshProUGUI tipsText;
    [SerializeField, TextArea(6,4)] string[] tipsName;


    void Start()
    {
        SetTipLoadingScreenText();
        tipsLoadingScreenIndex++;
    }

    void SetTipLoadingScreenText()
    {
        tipsText.text = tipsName[tipsLoadingScreenIndex];
    }
}
