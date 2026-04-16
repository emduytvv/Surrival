using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SaiMonoBehaviour
{
    protected static AudioManager instance;
    public static AudioManager Instance => instance;
    [Header("Audio Source")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Audio Source")]
    public AudioClip background;
    public AudioClip knifeCut;
    protected override void Awake()
    {
        base.Awake();
        AudioManager.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        PlayMusicBackground();
    }
    protected void PlayMusicBackground()
    {
        audioSource.clip = background;
        audioSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
