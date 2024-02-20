using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class ActionManager : MonoBehaviourSingleton<ActionManager>
{
    [SerializeField] DialoguePanelController dialoguePanel;
    [SerializeField] ThoughtData[] thoughtData;

    public Action onStartThought;

    public Action onSetHasThought;
    bool hasStartThought = true;

    int thougthIndex = 0;

    private void Start()
    {
        onStartThought += () => StartThought(thougthIndex);

        onSetHasThought += () => hasStartThought = true;
    }

    void StartThought(int thougthIndex)
    {
        if (hasStartThought && thougthIndex >= 0 && thougthIndex < thoughtData.Length   )
        {
            dialoguePanel.StartTyping(thoughtData[thougthIndex].newText, thoughtData[thougthIndex].dialogueOf, thoughtData[thougthIndex].isFlshback, thoughtData[thougthIndex].thoughtVoice);
            this.thougthIndex++;
            hasStartThought = false;
        }
    }

}
