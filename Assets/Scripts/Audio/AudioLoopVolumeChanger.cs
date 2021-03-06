using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoopVolumeChanger : MonoBehaviour
{
    public enum AudioType {sfx, bgm }

    public AudioType type;
    public AudioSource loopSource;

    private void Awake()
    {
        if (loopSource == null && GetComponent<AudioSource>())
            loopSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (loopSource.clip != null)
        {
            switch (type)
            {
                case AudioType.sfx:
                    loopSource.volume = AudioManager.scriptAudio.ReturnSfxVolume();
                    break;
                case AudioType.bgm:
                        loopSource.volume = AudioManager.scriptAudio.ReturnBgmVolume();
                    break;
            }
        }
    }

}
