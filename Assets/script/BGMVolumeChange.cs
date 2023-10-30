using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMVolumeChange : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider slider;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Volume");
        slider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void SoundSliderOnValueChange(float newSliderValue)
    {
        audioSource.volume = newSliderValue;
        PlayerPrefs.SetFloat("Volume", newSliderValue);
        PlayerPrefs.Save();
    }
}