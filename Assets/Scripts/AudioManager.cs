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
        //����ؼ� ���� ����
        audioSource.clip = bgMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
