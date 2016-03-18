using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AudioManager : SingletonBehaviour<AudioManager> {

    public List<AudioClip> randomAudioClips = new List<AudioClip>();
    public List<AudioClip> deathAudioClips = new List<AudioClip>();

    public AudioSource audioSource;

    public AudioClip Random1Audio;
    public AudioClip Random2Audio;
    public AudioClip Random3Audio;
    public AudioClip Random4Audio;
    public AudioClip Random5Audio;

    public AudioClip Death1Audio;
    public AudioClip Death2Audio;
    public AudioClip Death3Audio;
    public AudioClip Death4Audio;
    public AudioClip Death5Audio;
    public AudioClip Death6Audio;

    //Handles all the audio clips
    public void PlaySound(AudioSource source, AudioClip clip, float volume) {
        source.PlayOneShot(clip, volume);
    }

    public void RandomAudioSound() {
        int randNum = Random.Range(0, 5);
        PlaySound(audioSource, randomAudioClips[randNum], 1.0f);
    }

    public void DeathAudioSound() {
        int randNum = Random.Range(0, 6);
        PlaySound(audioSource, deathAudioClips[randNum], 0.3f);
    }
}

