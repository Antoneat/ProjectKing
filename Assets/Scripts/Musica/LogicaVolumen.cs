using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{
    public Slider sliderMusica;
    public float sliderMusicaValue;

    void Start()
    {
        sliderMusica.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderMusicaValue;
    }

    public void ChangeSlider(float valor)
    {
        sliderMusicaValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderMusicaValue);
        AudioListener.volume = sliderMusica.value;
    }
}
