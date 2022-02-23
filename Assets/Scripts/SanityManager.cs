using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum sanityStage { high, medium, low, none }

public class SanityManager : MonoBehaviour
{   
    [Header ("Sanity Atribute")]
    public float sanity = 100;
    private float sanityMax = 100;
    public float sanityDecay = 10;
    public float[] sanityThreshold = { .66f, .33f };
    public static sanityStage currentSanityStage;

    [Header("HUD Elements")]
    public Renderer insanityShader;
    public TextMeshProUGUI sanityCounter;
    public Image sanityIconImage;
    public Image sanityRingImage;
    public Sprite[] sanityStates = new Sprite[4];
    public AudioSource sfxLoop;

    private void Update()
    {
        sanity = Mathf.Clamp(sanity - sanityDecay * Time.deltaTime, 0, sanityMax);

        insanityShader.material.SetFloat("Vector1_b661a3301f8e4505ab0b8de3842c7c18",  1 - (sanity / sanityMax));
        insanityShader.material.SetFloat("Vector1_d4899e5ce8674ce593462513c44d13bd",  1 - (sanity / sanityMax));

        if (sanity / sanityMax <= .5f)
        {
            sfxLoop.volume = 1 - (sanity / (sanityMax / 2));
            //sfxLoop.pitch = sanity / (sanityMax / 2);
        }
        else
        {
            sfxLoop.volume = 0;
            //sfxLoop.pitch = 1;
        }

        if (sanity / sanityMax > sanityThreshold[0])
        {
            currentSanityStage = sanityStage.high;
            sanityIconImage.sprite = sanityStates[3];
        }
        else if (sanity / sanityMax > sanityThreshold[1])
        {
            currentSanityStage = sanityStage.medium;
            sanityIconImage.sprite = sanityStates[2];
        }
        else if (sanity / sanityMax > 0)
        {
            currentSanityStage = sanityStage.low;
            sanityIconImage.sprite = sanityStates[1];
        }
        else
        {
            currentSanityStage = sanityStage.none;
            sanityIconImage.sprite = sanityStates[0];
        }

        sanityCounter.text = (int)sanity + " / " + (int)sanityMax;

        sanityRingImage.fillAmount = sanity / sanityMax;
    }

}
