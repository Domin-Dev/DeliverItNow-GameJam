using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] Slider slider1;
    [SerializeField] Slider slider2;

    Sounds sounds;
    private void Start()
    {
        sounds = FindObjectOfType<Sounds>();
       if(sounds.musicAudio != null) slider1.value = sounds.musicAudio.volume;
       if(sounds.soundsAudio != null) slider2.value = sounds.soundsAudio.volume;

    }

    public void ChangeVolumeMusic()
    {
        sounds.musicAudio.volume = slider1.value;
    }

    public void ChangeVolumeSounds()
    {
        sounds.soundsAudio.volume = slider2.value;
    }
}
