using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource soundSource;
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    AudioClip[] soundClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {
        int index = Random.Range(0, clips.Length);
        audioSource.clip = clips[index];
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
        soundSource.Stop();
    }

    public void PlaySounds()
    {
        int index = Random.Range(0, clips.Length);
        soundSource.PlayOneShot(soundClips[index]);
    }
}