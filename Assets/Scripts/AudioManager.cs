using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : Observer
{
    AudioSource effectsSource;

    public static AudioManager instance { get; private set; } = null;
    private PlayerMovement playerMovement;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip clip)
    {
        effectsSource.clip = clip;
        effectsSource.Play();
    }

    public override void Notify(Subject subject)
    {
        if (!playerMovement) playerMovement = subject.GetComponent<PlayerMovement>();

        if (playerMovement)
        {
            if (playerMovement.isDead)
            {
                Play(playerMovement.deathSFX);
            }
            else if (playerMovement.grounded == false)
            {
                Play(playerMovement.jumpSFX);
            }
        }
    }
}
