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
       if(sounds.audioSource != null) slider1.value = sounds.audioSource.volume;

    }

    public void ChangeVolumeMusic()
    {
        sounds.audioSource.volume = slider1.value;
    }
}
