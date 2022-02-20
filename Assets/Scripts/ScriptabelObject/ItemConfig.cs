 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Create Scriptable Objects/Create Item")]
public class ItemConfig : ScriptableObject
{    
    public string itemName;

    public States.ItemShape shape;
    public States.ItemMaterial material;
    public States.ItemColor color;
}
