using UnityEngine;

[CreateAssetMenu(fileName = "NewThoughtData", menuName = "ScriptableObjects/ThoughtData", order = 1)]
public class ThoughtData : ScriptableObject
{
    public string newText;
    public DialogueOf dialogueOf;
    public bool isFlshback;
    public AudioClip thoughtVoice;
}
