using UnityEngine;

[CreateAssetMenu(fileName = "NewThoughtData", menuName = "ScriptableObjects/ThoughtData", order = 1)]
public class ThoughtData : ScriptableObject
{
    [TextArea(6,4)] public string newText;
    public DialogueOf dialogueOf;
    public bool isFlshback;
    public AudioClip thoughtVoice;
}
