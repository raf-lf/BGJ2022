using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum sanityStage { high, medium, low, none }

public class SanityManager : MonoBehaviour
{
    public static SanityManager sanityScript;
    [Header("Sanity States")]
    public bool illusion;
    public bool curse;
    public bool recovery;
    public static int lightLevel;

    [Header("State Modifiers")]
    public float illusionModifier = 1;
    public float curseModifier = 5;
    public float recoveryModifier = -1;
    private float modifier = 1;

    [Header("Sanity Atribute")]
    public float sanity = 100;
    private float sanityMax = 100;
    public float sanityDecay = 1;
    public float[] sanityThreshold = { .66f, .33f };
    public static sanityStage currentSanityStage;
    private bool gameOverFlag = false;

    [Header("HUD Elements")]
    public Renderer insanityShader;
    public TextMeshProUGUI sanityCounter;
    public Image sanityRingImage;
    public Animator evilEyeAnim;
    public Animator lightMeterAnim;
    public AudioSource sfxLoop;

    private void Awake()
    {
        sanityScript = this;
    }

    private void Update()
    {

        lightMeterAnim.SetInteger("level", lightLevel);
        lightMeterAnim.SetBool("illusion", illusion);
        lightMeterAnim.SetBool("curse", curse);
        lightMeterAnim.SetBool("recovery", recovery);

        if (recovery)
            modifier = recoveryModifier;
        else if (curse)
            modifier = curseModifier;
        else if (illusion)
            modifier = illusionModifier;
        else if (lightLevel <= 0)
            modifier = 1;
        else
            modifier = 0;

        sanity = Mathf.Clamp(sanity - (sanityDecay * modifier) * Time.deltaTime, 0, sanityMax);
 
        if (insanityShader != null)
        {
            insanityShader.material.SetFloat("Vector1_b661a3301f8e4505ab0b8de3842c7c18", 1 - (sanity / sanityMax));
            insanityShader.material.SetFloat("Vector1_d4899e5ce8674ce593462513c44d13bd", 1 - (sanity / sanityMax));
        }

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
            evilEyeAnim.SetInteger("sanity", 0);
        }
        else if (sanity / sanityMax > sanityThreshold[1])
        {
            currentSanityStage = sanityStage.medium;
            evilEyeAnim.SetInteger("sanity", 1);
        }
        else if (sanity / sanityMax > 0)
        {
            currentSanityStage = sanityStage.low;
            evilEyeAnim.SetInteger("sanity", 2);
        }
        else
        {
            currentSanityStage = sanityStage.none;
            evilEyeAnim.SetInteger("sanity", 3);
        }

        sanityCounter.text = (int)sanity + " / " + (int)sanityMax;

        sanityRingImage.fillAmount = sanity / sanityMax;

        if(sanity <= 0 && !gameOverFlag)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverFlag = true;
        PlayerMovement.PlayerControls = false;
        GameOverManager.SetGameOverCondition("Lose");

        // Make the animations of Players Crazy;

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
