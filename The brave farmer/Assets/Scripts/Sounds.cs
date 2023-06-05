using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
   [SerializeField] List<AudioClip> listMusic = new List<AudioClip>();
   [SerializeField] List<AudioClip> listSounds = new List<AudioClip>();



    public AudioSource musicAudio;
    public AudioSource soundsAudio;
    [SerializeField]int index = 0;

    static Sounds sounds;



    private void Start()
    {
        if (sounds != null)
        {       
            Destroy(this.gameObject);
        }
        else
        {
            sounds = this;
        }

        musicAudio = GetComponent<AudioSource>();
        soundsAudio = transform.GetChild(0).GetComponent<AudioSource>();
        musicAudio.PlayOneShot(listMusic[0]);
        index++;
        DontDestroyOnLoad(gameObject);

    }

    public void PlaySound(int index)
    {
        if (index < listSounds.Count)
        {
            if (index == 3 || index == 2 || index == 5) { if (!soundsAudio.isPlaying) soundsAudio.PlayOneShot(listSounds[index]); }
            else
            {
                soundsAudio.PlayOneShot(listSounds[index]);
            }
        }
    }

    private void Update()
    {
        if(musicAudio != null && !musicAudio.isPlaying)
        {
            musicAudio.PlayOneShot(listMusic[index]);
            if (index >= listMusic.Count - 1) index = 0;
            else index++;
        }
    }
}
