using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquina : MonoBehaviour
{
    public ItemConfig[] possibleItem;
    private ItemConfig correctItem;
    public ItemConfig presentItem;

    [ContextMenu("Check Item")]
    public void CheckItem()
    {
        string debug = "";

        if(presentItem == null)
        {
            debug += "Não há item para ser avaliado. \n";
            return;
        }

        debug += presentItem.shape == correctItem.shape ? "- Possui o mesmo formato. \n" : "- Não possui o mesmo formado. \n";
        debug += presentItem.material == correctItem.material ? "- Possui o mesmo material. \n" : "- Não possui o mesmo material. \n";
        debug += presentItem.color == correctItem.color ? "- Possui a mesma cor. \n" : "- Não possui a mesma cor. \n";

        if(presentItem == correctItem)
        {
            debug += "-- Parabéns! Você achou o item correto! -- \n";
        }

        Debug.Log(debug);
    }

    [ContextMenu("Pegar Item Aleatório")]
    public void RandomizeItem()
    {
        int randomIndice = (int)Random.Range(0, possibleItem.Length);

        correctItem = possibleItem[randomIndice];

        Debug.Log("== Item Aleatorizado!");
    }

    [ContextMenu("Revelar Item")]
    public void ShowItem()
    {
        Debug.Log(correctItem.itemName);
    }
}
