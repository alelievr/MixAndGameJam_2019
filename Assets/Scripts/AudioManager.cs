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
    public AudioClip[]  invalidActions;
    public AudioClip[]  arrowShoot;
    public AudioClip[]  tankShooting;
    public AudioClip[]  griffinAttack;

    AudioSource source;

    void Awake()
    {
        source = GetComponent< AudioSource >();
        instance = this;
    }

    void PlayRandomAudioClip(AudioClip[] clips, float overrideVolume = 1)
    {
        var clip = clips.OrderBy(b => Random.value).First();

        source.PlayOneShot(clip, overrideVolume);
    }

    public void PlaySwordClash() => PlayRandomAudioClip(swordClashes);
    public void PlayUnitDying() => PlayRandomAudioClip(unitDying, 0.9f);
    public void PlayInvalidActionSound() => PlayRandomAudioClip(invalidActions, 0.3f);
    public void PlayArrowShooting() => PlayRandomAudioClip(arrowShoot);
    public void PlayTankShooting() => PlayRandomAudioClip(tankShooting);
    public void PlayGriffinAttack() => PlayRandomAudioClip(griffinAttack);
}
