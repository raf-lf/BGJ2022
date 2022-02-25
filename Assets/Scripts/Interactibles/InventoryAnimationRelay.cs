using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnimationRelay : MonoBehaviour
{
    public void RelayUpdateItemCount()
    {
        InventoryManager.scriptInventory.UpdateAllItemCount();
    }
}
