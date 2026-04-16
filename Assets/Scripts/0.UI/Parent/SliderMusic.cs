using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SliderMusic : BaseSlider
{
    [SerializeField] protected AudioMixer audioMixer;
    protected override void Start()
    {
        base.Start();
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }

    }
    protected override void OnValueChange(float value)
    {
        SetMusicVolume();
    }
    private void SetMusicVolume()
    {
        float volume = slider.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    private void LoadVolume()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume();
    }
}
