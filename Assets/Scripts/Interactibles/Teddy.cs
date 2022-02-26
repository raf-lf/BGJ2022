using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeddyState {normal, lonely, defiled}

public class Teddy : MouseTarget
{
    [Header ("Teddy Bear")]
    public float life = 300;
    private float maxLife;
    public float lifeThreshold = .5f;
    public float lifeDecay = 1;
    public int decayState = 0;

    public float minHugDuration = 1;
    private float hugTimer;

    public bool hugging;

    [Header("Components")]
    public Renderer teddyRenderer;
    public Texture[] teddySprites = new Texture[3];
    public Texture[] playerHuggingSprites = new Texture[3];
    private Texture playerNormalSprite;

    protected override void Awake()
    {
        base.Awake();
        maxLife = life;
    }

    public override void Interact()
    {
        base.Interact();

        Hug(true);
        interactable = false;
    }

    public void Hug(bool on)
    {
        objectAnim.SetBool("hug", on);
        objectAnim.SetInteger("decay", decayState);

        if (!hugging)
            playerNormalSprite = PlayerMovement.Player.GetComponentInChildren<Renderer>().material.mainTexture;

        hugging = on;

        PlayerMovement.Player.GetComponentInChildren<PlayerMovement>().anim.SetBool("hug", on);

        PlayerMovement.PlayerControls = !on;
        teddyRenderer.enabled = !on;

        if (decayState == 2)
        {
            SanityManager.sanityScript.curse = on;
        }
        else
        {
            SanityManager.sanityScript.recovery = on;
        }

        if (on)
        {
            hugTimer = minHugDuration;

            PlayerMovement.Player.GetComponentInChildren<Renderer>().material.mainTexture = playerHuggingSprites[decayState];

            if (decayState == 1)
                life = lifeThreshold * maxLife;
            else if (decayState == 0)
                life = maxLife;
        }
        else
            PlayerMovement.Player.GetComponentInChildren<Renderer>().material.mainTexture = playerNormalSprite;



    }


    private void Decay()
    {
        life = Mathf.Clamp(life - lifeDecay * Time.deltaTime, 0, maxLife);

        if (life <= 0)
            decayState = 2;
        else if (life <= lifeThreshold * maxLife)
            decayState = 1;
        else
            decayState = 0;

        teddyRenderer.material.mainTexture = teddySprites[decayState];

    }

    protected override void Update()
    {
        base.Update();

        if(hugging)
        {
            if (hugTimer <= 0)
            {
                //if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                if (Input.anyKey)
                {
                    Hug(false);
                    interactable = true;
                }
            }
            else
                hugTimer = Mathf.Clamp(hugTimer - Time.deltaTime, 0, Mathf.Infinity);
        }
        else
        {
            Decay();
        }

    }

}
