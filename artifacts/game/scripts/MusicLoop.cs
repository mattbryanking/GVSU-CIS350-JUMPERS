using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioClip musicStart;

    void Start()
    {
        // plays music intro once in title sequence
        musicSource.PlayOneShot(musicStart);

        // infinitely loops main music section in title sequence
		musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }
}
