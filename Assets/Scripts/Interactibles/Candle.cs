using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MouseTarget
{
    public float life;
    private float maxLife;
    public float depletionRate;
    public Window affectingWindow;
    private ParticleSystem[] ps;
    private Light candleLight;
    public float maxLightIntensity = 50;

    protected override void Awake()
    {
        base.Awake();
        maxLife = life;
        ps = GetComponentsInChildren<ParticleSystem>();
        candleLight = GetComponentInChildren<Light>();

    }

    public void LifeChange(float value)
    {
        life = Mathf.Clamp(life + value, 0, maxLife);
    }

    protected override void Update()
    {
        base.Update();
        if (affectingWindow != null)
        {
            if (affectingWindow.isOpen)
            {
                LifeChange(-depletionRate * Time.deltaTime);
            }
        }

        LifeChange(-depletionRate * Time.deltaTime);

        candleLight.intensity = maxLightIntensity * (life / maxLife);

        foreach (ParticleSystem p in ps)
        {
            p.transform.localScale = new Vector3(life / maxLife, life / maxLife, life / maxLife);
        }
        
    }
}
