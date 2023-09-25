using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    [SerializeField] AudioSource footstepsAS;
    [SerializeField] AudioSource pickUpItemAS;
    [SerializeField] AudioSource bendAS;
    [SerializeField] AudioSource getUpAS;

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
}
