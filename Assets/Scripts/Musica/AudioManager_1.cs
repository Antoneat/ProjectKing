using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager_1 : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";

    private int firstPlayInt;

    public Slider backgroundSlider, sounEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;

    public AudioSource[] BackgroundAudio;
    public AudioSource[] SoundEffectsAudio;

    private void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            backgroundFloat = .75f;
            soundEffectsFloat = .75f;

            backgroundSlider.value = backgroundFloat;
            sounEffectsSlider.value = soundEffectsFloat;

            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsFloat);

            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundSlider.value = backgroundFloat;

            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            sounEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsFloat);
    }

    public void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateBackgroundSuunds()
    {
        for(int i = 0; i < BackgroundAudio.Length; i++)
        {
            BackgroundAudio[i].volume = backgroundSlider.value;
        }
    }

    public void UpdateSoundEffects()
    {
        for (int i = 0; i < SoundEffectsAudio.Length; i++)
        {
            SoundEffectsAudio[i].volume = sounEffectsSlider.value;
        }
    }
}
