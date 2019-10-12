using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    public AudioClip    start;
    public AudioClip    loop;
    AudioSource         source;

    void Start()
    {
        source = GetComponent< AudioSource >();

        source.clip = start;
        source.loop = false;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (source.clip == start && !source.isPlaying)
        {
            source.clip = loop;
            source.Play();
            source.loop = true;
        }
    }
}
