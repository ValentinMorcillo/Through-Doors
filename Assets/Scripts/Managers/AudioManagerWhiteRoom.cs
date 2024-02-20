using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class AudioManagerWhiteRoom : MonoBehaviourSingleton<AudioManagerWhiteRoom>
{
    [SerializeField] AudioSource openDoorAS;
    [SerializeField] AudioSource lockedDoorAS;
    [SerializeField] AudioSource footstepsWhiteRoomAS;


    [SerializeField] AudioSource voiceAS;

    [SerializeField] AudioSource initFlashbackAS;
    [SerializeField] AudioSource finishFlashbackAS;


    public void PlayFootstepsWhiteRoomSound()
    {

        footstepsWhiteRoomAS.PlayOneShot(footstepsWhiteRoomAS.clip);

        //if (!footstepsWhiteRoomAS.isPlaying)
        //{
        //    footstepsWhiteRoomAS.Play();
        //}
    }

    public void PlayOpenDoorSound()
    {
        openDoorAS.Play();
    }
    public void PlayLockedDoorSound()
    {
        lockedDoorAS.Play();
    }


    public void PlayThoughtVoice(AudioClip voice)
    {
        voiceAS.clip = voice;
        voiceAS.Play();
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
