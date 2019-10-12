using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[]  swordClashes;
    public AudioClip[]  unitDying;

    AudioSource source;

    void Awake()
    {
        source = GetComponent< AudioSource >();
        DontDestroyOnLoad(this);
        instance = this;
    }

    void PlayRandomAudioClip(AudioClip[] clips)
    {
        var clip = clips.Skip(Random.Range(0, swordClashes.Length)).First();

        source.PlayOneShot(clip);
    }

    public void PlaySwordClash() => PlayRandomAudioClip(swordClashes);
    public void PlayUnitDying() => PlayRandomAudioClip(unitDying);

    void Update()
    {
        
    }
}
