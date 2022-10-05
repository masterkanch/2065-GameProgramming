using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips deathAudioClips;
    
    public void PlayJumpSound(){
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClip());
    }
    
    public void PlayWalkSound(){
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip());
    }

    public void PlayDeathSound(){
        audioSource.PlayOneShot(deathAudioClips.GetAudioClip());
    }
}
