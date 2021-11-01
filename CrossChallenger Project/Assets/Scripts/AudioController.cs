using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource theAudioSource;

    public static AudioSource instance;

    private void Awake()
    {
        instance = theAudioSource.GetComponent<AudioSource>();
    }
}
