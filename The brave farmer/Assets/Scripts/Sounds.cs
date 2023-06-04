using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
   [SerializeField] List<AudioClip> list = new List<AudioClip>();



    public AudioSource audioSource;
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

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(list[0]);
        index++;
        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(list[index]);
            if (index >= list.Count - 1) index = 0;
            else index++;
        }
    }
}
