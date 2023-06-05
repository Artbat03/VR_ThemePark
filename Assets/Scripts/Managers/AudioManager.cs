using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Variables
    public static AudioManager instance;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicVagoneta;

    public AudioClip[] listaAudio;
    
    private void OnValidate()
    {
        if (musicSource == null)
        {
            musicSource = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioSource>();
        }

        if (sfxSource == null)
        {
            sfxSource = GameObject.FindGameObjectWithTag("SFXSource").GetComponent<AudioSource>();
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    
    public void PlayMusicVagoneta(AudioClip clip)
    {
        musicVagoneta.clip = clip;
        musicVagoneta.Play();
    }
    public void StopMusicVagoneta()
    {
        musicVagoneta.Stop();
    }
}
