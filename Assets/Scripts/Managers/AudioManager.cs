using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    [SerializeField] AudioSource voiceAS;
    [SerializeField] AudioClip[] dialogueVoice;
    int dialogueIndex = 0;

    [SerializeField] AudioSource initFlashbackAS;
    [SerializeField] AudioSource finishFlashbackAS;

    [SerializeField] AudioSource footstepsAS;
    [SerializeField] AudioSource pickUpItemAS;
    [SerializeField] AudioSource openDoorAS;
    [SerializeField] AudioSource bendAS;
    [SerializeField] AudioSource getUpAS;
    [SerializeField] AudioSource lockedDoorAS;
    [SerializeField] AudioSource annotateAS;
    public void PlayBendSound()
    {
        bendAS.Play();
    }

    public void PlayPickUpItemSound()
    {
        pickUpItemAS.Play();
    }
    public void PlayGetUpSound()
    {
        getUpAS.Play();
    }

    public void PlayFootstepsSound()
    {
        if (!footstepsAS.isPlaying)
        {
            footstepsAS.Play();
        }
    }

    public void PlayOpenDoorSound()
    {
        openDoorAS.Play();
    }

    public void PlayLockedDoorSound()
    {
        lockedDoorAS.Play();
    }

    public void PlayAnnotateSound()
    {
        annotateAS.Play();
    }

    public void PlayVoiceSound()
    {
        if (dialogueVoice[dialogueIndex] != null)
        {
            voiceAS.clip = dialogueVoice[dialogueIndex];
            voiceAS.Play();
            dialogueIndex++;
        }
    }

    public void StopVoiceSound()
    {
        voiceAS.Stop();
    }

    public void PlayFinishFlashbackSound()
    {
        finishFlashbackAS.Play();
    }
    public void PlayInitFlashbackSound()
    {
        initFlashbackAS.Play();
    }
}
