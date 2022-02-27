using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioSource radinho;
    public AudioClip[] radioMusic;
    private int lastClip = 0;
    private float pitchRangeVariation = .25f;
    private float timer;
    private float timerStart = 3f;

    private void Awake()
    {
        radinho = GetComponent<AudioSource>();
    }

    private void Start()
    {
        timer = timerStart;
        lastClip = Random.Range(0, radioMusic.Length);
        radinho.clip = RandomMusic();
        radinho.Play();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (!radinho.isPlaying)
        {
            radinho.clip = RandomMusic();
            radinho.Play();
        }

        if(timer <= 0)
        {
            ChangePitch();
            timer = timerStart;
        }
    }

    private void ChangePitch()
    {
        radinho.volume = 0.25f + Random.Range(-pitchRangeVariation, pitchRangeVariation);
        radinho.pitch = 1 + Random.Range(-pitchRangeVariation, pitchRangeVariation);
    }

    public AudioClip RandomMusic()
    {
        int indice = lastClip;

        while (indice == lastClip)
        {
            indice = Random.Range(0, radioMusic.Length);
        }

        return radioMusic[indice];
    }
}
