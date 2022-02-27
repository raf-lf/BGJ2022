using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider bgmSlider;

    private void Start()
    {
        sfxSlider.value = AudioManager.volumeCurrentSfx;
        bgmSlider.value = AudioManager.volumeCurrentBgm;
        
    }

    public void UpdateVolumes()
    {
        AudioManager.volumeCurrentSfx = sfxSlider.value;
        AudioManager.volumeCurrentBgm = bgmSlider.value;

    }

    private void Update()
    {
        UpdateVolumes();
    }
}
