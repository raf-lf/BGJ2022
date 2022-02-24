using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableSpot : MouseTarget
{
    [Header("Searchable Spot")]

    public string parameterName = "open";
    public bool alreadyUsed;
    public bool itemInside;
    public float delay = .25f;
    public ParticleSystem vfxItem;
    public ParticleSystem vfxNoItem;

    public override void Interact()
    {
        base.Interact();

        if (!alreadyUsed)
        { 
            objectAnim.SetBool(parameterName, true);
            alreadyUsed = true;
            interactable = false;

            StartCoroutine(Execute(itemInside));

            if (itemInside)
            {
                itemInside = false;
                if (GetComponentInParent<SearchableSpotManager>().spawnMechanics == itemSpawnType.waitPickup)
                    GetComponentInParent<SearchableSpotManager>().itemSpawned = false;
            }

            //DELETE ME AFTER TESTING
            Invoke(nameof(ResetObject),3);
        }
        
    }

    public IEnumerator Execute(bool item)
    {
        yield return new WaitForSeconds(delay);

        if (item)
        {
            vfxItem.Play();
            InventoryManager.scriptInventory.GetItem(1);

        }
        else
            vfxNoItem.Play();

    }

    public void ResetObject()
    {
        objectAnim.SetBool(parameterName, false);
        alreadyUsed = false;
        interactable = true;
    }

}
