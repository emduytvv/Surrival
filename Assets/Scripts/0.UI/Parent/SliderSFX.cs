using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SliderSFX : BaseSlider
{
    [SerializeField] protected AudioMixer audioMixer;
    protected override void Start()
    {
        base.Start();
        if (PlayerPrefs.HasKey("MusicSFX"))
        {
            LoadVolume();
        }
        else
        {
            SetSFXVolume();
        }

    }
    protected override void OnValueChange(float value)
    {
        SetSFXVolume();
    }
    private void SetSFXVolume()
    {
        float volume = slider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicSFX", volume);
    }
    private void LoadVolume()
    {
        slider.value = PlayerPrefs.GetFloat("MusicSFX");
        SetSFXVolume();
    }
}
