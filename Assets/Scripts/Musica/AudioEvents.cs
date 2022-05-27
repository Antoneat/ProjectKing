using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioEvents : MonoBehaviour
{

    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";

    public Slider backgroundSlider, sounEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;

    public AudioSource[] BackgroundAudio;
    public AudioSource[] SoundEffectsAudio;


    void Awake()
    {
        ContinueSettings();
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsFloat);
    }

    public void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);
        backgroundSlider.value = backgroundFloat;
        sounEffectsSlider.value = soundEffectsFloat;

        for (int i = 0; i < BackgroundAudio.Length; i++)
        {
            BackgroundAudio[i].volume = backgroundFloat;
        }

        for (int i = 0; i < SoundEffectsAudio.Length; i++)
        {
            SoundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
}
