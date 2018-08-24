using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource eatSoundAudioSource;
    public AudioSource loseEatAudioSource;

    public void PlayEatSound()
    {
        eatSoundAudioSource.Play();
    }

    public void PlayLoseEatSound()
    {
        loseEatAudioSource.Play();
    }

}
