using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class WhiteRoomActionManager : MonoBehaviourSingleton<WhiteRoomActionManager>
{
    [SerializeField] DialoguePanelController dialoguePanel;
    [SerializeField] ThoughtData[] thoughtData;
    public Action onCompleteCameraTransition;

    private void Start()
    {
        onCompleteCameraTransition += () => StartThought(0);
    }

    void StartThought(int thougthIndex)
    {
        dialoguePanel.StartTyping(thoughtData[thougthIndex].newText, thoughtData[thougthIndex].dialogueOf, thoughtData[thougthIndex].isFlshback, thoughtData[thougthIndex].thoughtVoice);
    }
}
