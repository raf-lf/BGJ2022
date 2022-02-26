using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualCircle : MonoBehaviour
{
    public GameObject[] ritualItems;
    private Animator anim;
    private bool ritualReady;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && ritualReady)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        PlayerMovement.PlayerControls = false;
        anim.SetInteger("stage", 2);
    }

    public void UpdateItems()
    {
        for (int i = 0; i < ritualItems.Length; i++)
        {
            if (InventoryManager.scriptInventory.trinkets > i)
                ritualItems[i].SetActive(true);
            else
                ritualItems[i].SetActive(false);
        }

        if(InventoryManager.scriptInventory.trinkets >= FindObjectOfType<GameplayManager>().totalItemsToSpawn)
        {
            ritualReady = true;
            anim.SetInteger("stage", 1);

        }

    }

}
