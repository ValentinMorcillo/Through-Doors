using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    [SerializeField] AudioSource openDoorAS;
    [SerializeField] AudioSource footstepsAS;
    [SerializeField] AudioSource footstepsWhiteRoomAS;

    public void PlayFootstepsWhiteRoomSound()
    {
        footstepsWhiteRoomAS.PlayOneShot(footstepsWhiteRoomAS.clip);

        //if (!footstepsWhiteRoomAS.isPlaying)
        //{
        //    footstepsWhiteRoomAS.Play();
        //}
    }
    public void PlayFootstepsSound()
    {
        footstepsAS.Play();
    }
    public void PlayOpenDoorSound()
    {
        openDoorAS.Play();
    }
}
