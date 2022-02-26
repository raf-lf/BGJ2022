using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaipirotoSpawn : MonoBehaviour
{
    private List<Window> windows = new List<Window>();

    public float spawnCountdown;
    [SerializeField]
    private float spawnTimer;
    [SerializeField]
    private float windowsMultiplier;
    private bool caipirotoSpawned;
    public GameObject caipiroto;


    private void Start()
    {
        spawnTimer = spawnCountdown;

        foreach (var item in GameManager.rooms)
        {
            windows.AddRange(item.GetComponentsInChildren<Window>());
        }
    }

    public void SpawnCaipiroto()
    {
        caipirotoSpawned = true;
        caipiroto.SetActive(true);

    }

    private void Update()
    {
        if(Time.frameCount % 60 == 0 && !caipirotoSpawned)
        {
            int openWindows = 0;

            foreach (var item in windows)
            {
                if (item.isOpen)
                    openWindows++;
            }

            windowsMultiplier = openWindows;
        }

        if (spawnTimer <= 0 && !caipirotoSpawned)
            SpawnCaipiroto();
        else
            spawnTimer = Mathf.Clamp(spawnTimer - (Time.deltaTime * windowsMultiplier), 0, Mathf.Infinity);
    }

}
