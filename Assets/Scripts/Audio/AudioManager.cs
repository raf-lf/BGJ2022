using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager scriptAudio;
    
    public static float volumeCurrentBgm = .7f;
    public static float volumeCurrentSfx = .7f;

    public static float volumeSfxModifier = 1;
    public static float volumeBgmModifier = 1;
    public float volumeSfxFadeModifier = 1;
    public float volumeBgmFadeModifier = 1;
    public AudioSource sfxSource;
    public AudioSource bgmSource;

    /*
    public delegate void volumeDelegate();
    public static volumeDelegate volumeChangedEvent;
    */



    public void Awake()
    {
        scriptAudio = this;
    }

    public float ReturnBgmVolume()
    {
        return volumeCurrentBgm * volumeBgmModifier * volumeBgmFadeModifier;
    }
    public float ReturnSfxVolume()
    {
        return volumeCurrentSfx * volumeSfxModifier * volumeSfxFadeModifier;
    }

    public void PlaySfxSimple(AudioClip clip)
    {
        PlaySfx(clip, 1, Vector2.one, sfxSource);
    }

    public void PlaySfx(AudioClip clip, float volume, Vector2 pitchVariance, AudioSource source)
    {
        AudioSource usedSource = sfxSource;

        if (source != null)
            usedSource = source;

        volumeSfxModifier = volume;

        usedSource.volume = ReturnSfxVolume();
        usedSource.pitch = Random.Range(pitchVariance.x, pitchVariance.y);
        usedSource.PlayOneShot(clip);

    }

    public void PlayBgm(AudioClip music, float volume)
    {
        volumeBgmModifier = volume;
        bgmSource.volume = ReturnBgmVolume();
        bgmSource.clip = music;
        bgmSource.Play();

    }

    public void FadeBgm(float volume, float volumeChange)
    {
        StopAllCoroutines();
        StopCoroutine(FadeBgmCoroutine(volume, volumeChange));
        StartCoroutine(FadeBgmCoroutine(volume, volumeChange));
    }

    public IEnumerator FadeBgmCoroutine(float setFadeValue, float gradualChange)
    {
        while (volumeBgmFadeModifier != setFadeValue)
        {
            if (volumeBgmFadeModifier > setFadeValue)
                volumeBgmFadeModifier = Mathf.Clamp(volumeBgmFadeModifier - gradualChange, setFadeValue, 1);
            else if (volumeBgmFadeModifier < setFadeValue)
                volumeBgmFadeModifier = Mathf.Clamp(volumeBgmFadeModifier + gradualChange, 0, setFadeValue);

            bgmSource.volume = ReturnBgmVolume();

            yield return new WaitForSeconds(.1F);

            if (volumeBgmFadeModifier == setFadeValue)
                break;

        }

    }

    public void FadeSfx(float volume, float volumeChange)
    {
        StopCoroutine(FadeSfxCoroutine(volume, volumeChange));
        StartCoroutine(FadeSfxCoroutine(volume, volumeChange));
    }

    public IEnumerator FadeSfxCoroutine(float setFadeValue, float gradualChange)
    {
        while (volumeSfxFadeModifier != setFadeValue)
        {
            if (volumeSfxFadeModifier > setFadeValue)
                volumeSfxFadeModifier = Mathf.Clamp(volumeSfxFadeModifier - gradualChange, setFadeValue, 1);
            else if (volumeSfxFadeModifier < setFadeValue)
                volumeSfxFadeModifier = Mathf.Clamp(volumeSfxFadeModifier + gradualChange, 0, setFadeValue);

            // volumeChangedEvent();

            yield return new WaitForSeconds(.1F);

            if (volumeSfxFadeModifier == setFadeValue)
                break;

        }

    }

}
