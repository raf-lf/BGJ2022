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
    public TextMeshProUGUI sanityCounter;
    public Image sanityIconImage;
    public Image sanityRingImage;
    public Sprite[] sanityStates = new Sprite[4];

    private void Update()
    {
        sanity = Mathf.Clamp(sanity - sanityDecay * Time.deltaTime, 0, sanityMax);

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
