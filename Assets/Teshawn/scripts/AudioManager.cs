using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private AudioSource SFX;


    [SerializeField] private AudioSource backGroundMusic;


    void Start()
    {
        SFX = GetComponentInChildren<AudioSource>();
        backGroundMusic = GetComponent<AudioSource>(); 
        

        backGroundMusic.Play();

        if (PlayerPrefs.HasKey("Master"))
            mixer.SetFloat("Master", PlayerPrefs.GetFloat("Master"));

        if (PlayerPrefs.HasKey("SFX"))
            mixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX")); 

        if (PlayerPrefs.HasKey("Music"))
            mixer.SetFloat("Music", PlayerPrefs.GetFloat("Music"));


    }

    void Update()
    {
        if(SFX == null)
        {
            SFX = FindAnyObjectByType<AudioSource>();
        }
        
    }



    public void Sounds(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
