using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MouseTarget
{
    [Header ("Candle")]
    public float life;
    private float maxLife;
    public float depletionRate;
    public ParticleSystem vfxRekindle;
    public PlaySfx sfxRekindle;

    [Header("Sizes")]
    public float area = 10;
    //public float lightRadiusRatio = 5;
    public float lightIntensityRatio = 1;
    public float ringEmissionRatio = 20;
    public float haloSizeRatio = 1;
    public float sizePower = 1;

    [Header("Components")]
    public Light candleLight;
    public SphereCollider lightCollider;
    public ParticleSystem[] psFlame;
    public ParticleSystem psRadius;
    public ParticleSystem psHalo;
    private ParticleSystem.MainModule psHaloMain;
    private ParticleSystem.ShapeModule psRadiusShape;
    private ParticleSystem.EmissionModule psRadiusEmission;

    protected override void Awake()
    {
        base.Awake();
        maxLife = life;
        psRadiusShape = psRadius.shape;
        psRadiusEmission = psRadius.emission;
        psHaloMain = psHalo.main;

    }

    public override void Interact()
    {
        base.Interact();

        if (InventoryManager.scriptInventory.SpendCharge())
        {
            sfxRekindle.PlayInspectorSfx();
            vfxRekindle.Play();
            LifeChange(maxLife);
        }
    }

    public void LifeChange(float value)
    {
        life = Mathf.Clamp(life + value, 0, maxLife);
    }

    public void DecayCandle()
    {
        LifeChange(-depletionRate * Time.deltaTime);
    }

    protected override void Update()
    {
        base.Update();

        //candleLight.intensity = maxLightIntensity * (life / maxLife);
        lightCollider.radius = area * (life / maxLife);
        candleLight.intensity = (area * lightIntensityRatio) * (life / maxLife);
        //candleLight.range = (area * lightRadiusRatio) * (life / maxLife);
        psRadiusShape.radius = area * (life / maxLife);
        psRadiusEmission.rateOverTime = (area * ringEmissionRatio) * (life / maxLife);
        psHaloMain.startSize = (area * haloSizeRatio) * (life / maxLife);


        foreach (ParticleSystem p in psFlame)
        {
            float ratio = Mathf.Pow(life / maxLife, sizePower);

            p.transform.localScale = new Vector3(ratio, ratio, ratio);
        }
        
    }
}
