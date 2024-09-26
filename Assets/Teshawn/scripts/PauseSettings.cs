using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class PauseSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private TMP_Text masterVolText, musicVolText, SFXVolText;
    [SerializeField] private Slider masterVolSlider, musicSlider, SFXSlider;

    void Start()
    {
        

        float vol = 0f;

        mixer.GetFloat("Master", out vol);
        masterVolSlider.value = vol;

        mixer.GetFloat("Music", out vol);
        musicSlider.value = vol;

        mixer.GetFloat("SFX", out vol);
        SFXSlider.value = vol;
    }

    void Update()
    {
        masterVolText.text = Mathf.Round(masterVolSlider.value + 80).ToString();
        musicVolText.text = Mathf.Round(musicSlider.value + 80).ToString();
        SFXVolText.text = Mathf.Round(SFXSlider.value + 80).ToString();


    }
    #region Audio
    public void MasterVolume()
    {
        masterVolText.text = Mathf.Round(masterVolSlider.value + 80).ToString();
        mixer.SetFloat("Master",masterVolSlider.value);
        PlayerPrefs.SetFloat("Master" ,masterVolSlider.value);
    }    
    public void MusicVolume()
    {
        musicVolText.text = Mathf.Round(musicSlider.value + 80).ToString();
        mixer.SetFloat("Music", musicSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }
    public void SFXVolume()
    {
        SFXVolText.text = Mathf.Round(SFXSlider.value + 80).ToString();
        mixer.SetFloat("SFX", SFXSlider.value);
        PlayerPrefs.SetFloat("SFX", SFXSlider.value);
    }
    #endregion
}
