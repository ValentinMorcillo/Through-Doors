using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class AudioManagerWhiteRoom : MonoBehaviourSingleton<AudioManagerWhiteRoom>
{
    [SerializeField] AudioSource openDoorAS;
    [SerializeField] AudioSource footstepsWhiteRoomAS;

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
}
