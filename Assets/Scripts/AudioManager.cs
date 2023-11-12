using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip bgMusic;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //계속해서 음악 실행
        audioSource.clip = bgMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
