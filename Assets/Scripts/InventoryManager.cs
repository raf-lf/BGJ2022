using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int itemsCollected;

    public Animator inventoryAnimator;
    public TextMeshProUGUI itemQty;
    public static InventoryManager scriptInventory;

    private void Start()
    {
        UpdateInventory();
    }

    public void GetItem(int qty)
    {
        itemsCollected += qty;
        //inventoryAnimator.Play("itemAdd");
        inventoryAnimator.SetTrigger("itemAdd");

        if (InventoryManager.scriptInventory.itemsCollected >= FindObjectOfType<SearchableSpotManager>().totalItemsToSpawn)
            HintManager.scriptHint.ShowEndHint();
    }

    public void Awake()
    {
        scriptInventory = this;
    }

    public void UpdateInventory()
    {
        itemQty.text = itemsCollected.ToString();
    }
}
