using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioEvents : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider sliderMusic;
    private float value;

    void Start()
    {
        mixer.GetFloat("volume", out value);
        sliderMusic.value = value;
    }

    public void SetVolumenMusic()
    {
        mixer.SetFloat("volume", sliderMusic.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
