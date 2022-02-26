using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager scriptInventory;

    [Header("Items")]
    public int trinkets = 0;
    public int candleCharges = 3;

    [Header("Components")]
    public Animator[] itemAnim = new Animator[2];
    public TextMeshProUGUI[] itemQty = new TextMeshProUGUI[2];

    public void Awake()
    {
        scriptInventory = this;
    }

    private void Start()
    {
        UpdateAllItemCount();
    }

    public bool SpendCharge()
    {
        if (candleCharges > 0)
        {
            ChangeItem(1, -1);
            return true;
        }
        else
        {
            itemAnim[1].SetTrigger("missing");
            return false;
        }

    }

    public void AddTrinket(int qty)
    {
        ChangeItem(0,qty);

        if (InventoryManager.scriptInventory.trinkets >= FindObjectOfType<GameplayManager>().totalItemsToSpawn)
            HintManager.scriptHint.ShowEndHint();
    }

    public void ChangeItem(int id, int qty)
    {
        if (qty > 0)
            itemAnim[id].SetTrigger("add");
        else if (qty < 0)
            itemAnim[id].SetTrigger("remove");

        switch (id)
        {
            case 0:
                trinkets += qty;
                break;
            case 1:
                candleCharges += qty;
                break;
        }

    }

    public void UpdateAllItemCount()
    {
        itemQty[0].text = trinkets.ToString();
        itemQty[1].text = candleCharges.ToString();
        FindObjectOfType<RitualCircle>().UpdateItems();

    }
}
